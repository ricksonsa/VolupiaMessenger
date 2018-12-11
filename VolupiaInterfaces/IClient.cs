using System.IO;
using System.ServiceModel;

namespace VolupiaInterfaces
{
    public interface IClient
    {
        [OperationContract]
        void GetMessage(string message, string userName);

        [OperationContract]
        void GetAudioMessage(MemoryStream ms, string userName, string meta);

        [OperationContract]
        void GetUpdate(int value, string userName);

        [OperationContract]
        void GetInvites();

        [OperationContract]
        void IniviteAccepted();

        [OperationContract]
        void SendResponse();
    }
}
