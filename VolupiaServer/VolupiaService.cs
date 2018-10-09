using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using VolupiaInterfaces;

namespace VolupiaServer
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "VolupiaService" no arquivo de código e configuração ao mesmo tempo.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, AutomaticSessionShutdown = false)]
    public class VolupiaService : IVolupiaService
    {
        public ConcurrentDictionary<string, ConnectedClient> _connectedClients = new ConcurrentDictionary<string, ConnectedClient>();

        public int Login(string userName)
        {
            //esta alguem logado com meu nome?
            foreach (var client in _connectedClients)
            {
                if (client.Key.ToLower() == userName.ToLower())
                {
                    //se sim
                    return 1;
                }
            }

            var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();

            ConnectedClient newClient = new ConnectedClient
            {
                connection = establishedUserConnection,
                Username = userName,
                Connected = true
            };

            _connectedClients.TryAdd(userName, newClient);

            UpdateHelper(0, userName);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} {1} se conectou", DateTime.Now.ToString(), newClient.Username);
            Logger.ServerLog(newClient.Username + " se conectou");
            Console.ResetColor();

            //se nao
            return 0;
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

        public bool CheckAccount(string userName, string password)
        {
            Logger.ServerLog(userName + " solicitou acesso.");
            return VolupiaDAO.CheckAccount(userName, password);
        }

        public string[] GetAccount(string userName, string password)
        {
            Logger.ServerLog(userName + " acesso validado.");
            return VolupiaDAO.Login(userName, password);
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
                if (client.Key.ToLower() != userName.ToLower())
                {
                    if (client.Key.ToLower().Equals(subject))
                    {
                        client.Value.connection.GetMessage(message, userName);
                        if (message.Length > 55)
                            message = message.Remove(55);
                    }
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
                    if (!client.Value.Connected)
                    {
                        _connectedClients.TryRemove(client.Key, out ConnectedClient removedeClient);
                        UpdateHelper(1, removedeClient.Username);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("{0} {1} time out.", DateTime.Now.ToString(), removedeClient.Username);
                        Logger.ServerLog(removedeClient.Username + " time out.");
                        Console.ResetColor();
                    }
                }   
            }
        }
        
        public void GetResponse(string userName)
        {
            ConnectedClient client = GetMyClient();
            if (client != null)
            {
                client.Connected = true;
            }
        }

        public void SendMessageToALL(string message, string userName)
        {
            foreach (var client in _connectedClients)
            {
                if (client.Key.ToLower() != userName.ToLower())
                {
                    client.Value.connection.GetMessage(message, userName);
                    if (message.Length > 55)
                        message = message.Remove(55);
                }
            }
            //Logger.LogWrite(userName + ": " + message);
        }

        public void SendAudioMessageToAll(MemoryStream ms, string userName, string meta)
        {
            foreach (var client in _connectedClients)
            {
                if (client.Key.ToLower() != userName.ToLower())
                {
                    client.Value.connection.GetAudioMessage(ms, userName, meta);
                }
            }
            //Logger.LogWrite(userName + " enviou um áudio.");
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

        public List<string> GetFriends(int id)
        {
            return VolupiaDAO.GetFriendsById(id);
        }

        public void UserLogWrite(string userName, string logText)
        {
            Logger.ServerLog("Username: " + userName + "\n " + logText);
        }

        public bool InsertUser(string userName, string password, string mail, string name)
        {
            //return VolupiaDAO.InsertUser(userName, password, mail, name);
            return false;
        }

        public bool ValidateUser(string loginEntry, string password)
        {
            return false;
            //return VolupiaDAO.ValidateUser(loginEntry, password);
        }

        public string[] GetUser(string loginEntry, string password)
        {
            // return VolupiaDAO.GetUser(loginEntry, password);
            return null;
        }
    }
}
