using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace VolupiaInterfaces
{
    [ServiceContract(CallbackContract = typeof(IClient), SessionMode = SessionMode.Allowed)]
    public interface IVolupiaService
    {
        [OperationContract]
        string Login(string userName, string password);

        #region User responses to the server
        [OperationContract]
        void Connected();

        [OperationContract]
        void GetResponse();
        #endregion

        [OperationContract]
        void SendMessageToUser(string message, string subject, string userName);

        [OperationContract]
        void SendAudioMessageToUser(MemoryStream ms, string userName, string subject, string meta);

        [OperationContract]
        void Logout();

        [OperationContract]
        List<string> GetCurrentUsers();

        [OperationContract]
        void UserLogWrite(string userName, string logText);

        [OperationContract]//json user
        bool Register(string user);

        [OperationContract]
        bool HasUser(string entry);

        [OperationContract]
        bool HasMail(string entry);

        [OperationContract]
        bool InviteFriend(int userId, string friendName);

        [OperationContract]
        void Accept(int id);

        [OperationContract]
        void Reject(int id);

        [OperationContract]
        List<string> GetContacts(int userId);

        [OperationContract]
        List<string> GetInvites(int userId);

        [OperationContract]
        List<string> GetInvited(int userId);

        [OperationContract]
        List<string> FindByName(string name);

        [OperationContract]
        bool IsFriendOrInvited(int userId, int friendId);

        [OperationContract]
        string FindById(int id);
    }
}
