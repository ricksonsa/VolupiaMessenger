using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VolupiaInterfaces;
using VolupiaMessenger;
using System.IO;

namespace VolupiaMessenger
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class VolupiaClientCallBack : IClient
    {
        public void GetAudioMessage(MemoryStream ms, string userName)
        {
            //VolupiaWebClient.TakeAudioMessage(ms, userName);
        }

        public void GetMessage(string message, string userName)
        {
           VolupiaWebClient._Default.TakeMessage(message, userName);
        }

        public void GetUpdate(int value, string userName)
        {
            switch (value)
            {
                case 0:
                    Chat.AddUserToList(userName);
                    break;
                case 1:
                    Chat.RemoveUserFromList(userName);
                    break;
            }
        }
    }
}
