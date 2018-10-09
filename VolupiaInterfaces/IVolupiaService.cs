using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace VolupiaInterfaces
{
    [ServiceContract(CallbackContract = typeof(IClient),SessionMode = SessionMode.Allowed)]
    public interface IVolupiaService
    {
        [OperationContract]
        int Login(string userName);

        [OperationContract] 
        void SendMessageToALL(string message, string userName);

        [OperationContract]
        void SendMessageToUser(string message, string subject, string userName);

        [OperationContract]
        void SendAudioMessageToAll(MemoryStream ms, string userName, string meta);

        [OperationContract]
        void Logout();

        [OperationContract]
        List<string> GetCurrentUsers();

        [OperationContract]
        bool CheckAccount(string userName, string password);

        [OperationContract]
        string[] GetAccount(string userName, string password);

        [OperationContract]
        void GetResponse(string userName);

        [OperationContract]
        void UserLogWrite(string userName, string logText);

        [OperationContract]
        List<string> GetFriends(int id);

        [OperationContract]
        bool InsertUser(string userName, string password, string mail, string name);

        [OperationContract]
        bool ValidateUser(string loginEntry, string password);

        [OperationContract]
        string[] GetUser(string loginEntry, string password);
    }
}
