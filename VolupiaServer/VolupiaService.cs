using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using VolupiaInterfaces;

namespace VolupiaServer
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "VolupiaService" no arquivo de código e configuração ao mesmo tempo.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, AutomaticSessionShutdown = false, IncludeExceptionDetailInFaults = true)]
    public class VolupiaService : IVolupiaService
    {
        public ConcurrentDictionary<string, ConnectedClient> _connectedClients = new ConcurrentDictionary<string, ConnectedClient>();

        public string Login(string userName, string password)
        {
            string json;
            if (ValidateUser(userName, password))
            {
                json = GetUser(userName, password);
                var user = JsonConvert.DeserializeObject<Client>(json);
                //esta alguem logado com meu nome?
                foreach (var client in _connectedClients)
                {
                    if (client.Key.ToLower() == user.Username.ToLower())
                    {
                        throw new FaultException("Você ja está logado.");
                    }
                }

                var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();

                ConnectedClient newClient = new ConnectedClient
                {
                    connection = establishedUserConnection,
                    Id = user.Id,
                    Username = user.Username,
                    Name = user.Name,
                    Email = user.Email,
                    TryingToConnect = true,
                    Connected = false
                };

                _connectedClients.TryAdd(user.Username, newClient);

                UpdateHelper(0, user.Username);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} {1} se conectando...", DateTime.Now.ToString(), newClient.Username);
                Logger.ServerLog(newClient.Username + " se conectando...");
                Console.ResetColor();

                //Deu certo
                return json;
            }
            else
                throw new FaultException("Senha inválida ou usuário inexistente.");
        }

        public void Connected()
        {
            var current = GetMyClient();
            current.TryingToConnect = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} {1} se conectou", DateTime.Now.ToString(), current.Username);
            Logger.ServerLog(current.Username + " se conectou");
            Console.ResetColor();

        }

        public void Logout()
        {
            ConnectedClient client = GetMyClient();
            if (client != null)
            {
                _connectedClients.TryRemove(client.Username, out ConnectedClient removedeClient);

                UpdateHelper(1, removedeClient.Username);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0} {1} se desconectou", DateTime.Now.ToString(), removedeClient.Username);
                Logger.ServerLog(removedeClient.Username + " se desconectou");
                Console.ResetColor();
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            return VolupiaDAO.ValidateUser(userName, password);
        }

        public bool HasUser(string entry)
        {
            return VolupiaDAO.HasUser(entry);
        }

        public bool HasMail(string entry)
        {
            return VolupiaDAO.HasMail(entry);
        }

        private string GetUser(string userName, string password)
        {
            return VolupiaDAO.GetUser(userName, password);
        }

        public ConnectedClient GetMyClient()
        {
            var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();
            foreach (var client in _connectedClients)
            {
                if (client.Value.connection == establishedUserConnection)
                {
                    return client.Value;
                }
            }
            return null;
        }
        //Helper para organizar
        private void UpdateHelper(int value, string userName)
        {
            foreach (var client in _connectedClients)
            {
                if (client.Value.Username.ToLower() != userName.ToLower())
                {
                    client.Value.connection.GetUpdate(value, userName);
                }
            }
        }
        //Implementar isto
        public void SendMessageToUser(string message, string subject, string userName)
        {
            foreach (var client in _connectedClients)
            {
                if (client.Value.Name.Equals(subject))
                {
                    client.Value.connection.GetMessage(message, userName);
                }
            }
        }

        public void SendAudioMessageToUser(MemoryStream ms, string userName, string subject, string meta)
        {
            foreach (var client in _connectedClients)
            {
                if (client.Value.Name.Equals(subject))
                {
                    client.Value.connection.GetAudioMessage(ms, userName, meta);
                }
            }
        }

        public void SendRequestToAll()
        {
            foreach (var client in _connectedClients)
            {
                client.Value.Connected = false;

                try
                {
                    client.Value.connection.SendResponse();
                }
                catch (Exception)
                {
                    client.Value.Connected = false;
                }
                finally
                {
                    if (!client.Value.Connected && !client.Value.TryingToConnect)
                    {
                        _connectedClients.TryRemove(client.Key, out ConnectedClient removedeClient);
                        UpdateHelper(1, removedeClient.Username);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("{0} {1} timed out.", DateTime.Now.ToString(), removedeClient.Username);
                        Logger.ServerLog(removedeClient.Username + " timed out.");
                        Console.ResetColor();
                    }
                }
            }
        }

        public void GetResponse()
        {
            ConnectedClient client = GetMyClient();
            if (client != null)
            {
                client.Connected = true;
            }
        }

        public List<string> GetCurrentUsers()
        {
            List<string> listOfUsers = new List<string>();
            foreach (var client in _connectedClients)
            {
                listOfUsers.Add(client.Value.Username);
            }
            return listOfUsers;
        }

        public void UserLogWrite(string userName, string logText)
        {
            Logger.ServerLog("Username: " + userName + "\n " + logText);
        }

        public bool Register(string user)
        {
            return VolupiaDAO.InsertUser(user);
        }

        #region Friend
        public bool InviteFriend(int userId, string friendName)
        {
            bool result = FriendDAO.Invite(userId, friendName);

            if (result)
            {
                foreach (var client in _connectedClients)
                {
                    if (client.Key.ToLower() == friendName.ToLower())
                    {
                        client.Value.connection.GetInvites();
                    }
                }
            }
            return result;
        }

        public void Accept(int id)
        {
            FriendDAO.Accept(id);
        }

        public void Reject(int id)
        {
            FriendDAO.Reject(id);
        }

        public List<string> GetContacts(int userId)
        {
            return FriendDAO.GetContacts(userId);
        }

        public List<string> GetInvites(int userId)
        {
            return FriendDAO.GetInvites(userId);
        }

        public List<string> GetInvited(int userId)
        {
            return FriendDAO.GetInvited(userId);
        }

        public List<string> FindByName(string name)
        {
            return FriendDAO.Find(name);
        }

        public string FindById(int id)
        {
            return FriendDAO.FindById(id);
        }

        public bool IsFriendOrInvited(int userId, int friendId)
        {
            return FriendDAO.IsFriendOrInvited(userId, friendId);
        }
        #endregion


        //public bool HasUser(string loginEntry)
        //{
        //    return VolupiaDAO.HasUser(loginEntry);
        //}
    }
}
