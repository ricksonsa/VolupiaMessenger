using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
        void SendResponse();
    }
}
