using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VolupiaInterfaces;

namespace VolupiaWPFClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, AutomaticSessionShutdown = false, IncludeExceptionDetailInFaults = true)]
    public class VolupiaWPFClientCallBack : IClient
    {
        
        public void GetAudioMessage(MemoryStream ms, string userName)
        {
            ((Chat)Application.Current.MainWindow).TakeAudioMessage(ms, userName);
        }

        public void GetMessage(string message, string userName)
        {
            var program = (Chat)Application.Current.MainWindow;
            program.TakeMessage(message, userName);
            //.TakeMessage(message, userName);
        }

        public void GetUpdate(int value, string userName)
        {
            switch (value)
            {
                case 0:
                    ((Chat)Application.Current.MainWindow).AddUserToList(userName);
                    break;
                case 1:
                    ((Chat)Application.Current.MainWindow).RemoveUserFromList(userName);
                    break;
            }
        }

        public void SendResponse()
        {
            throw new NotImplementedException();
        }
    }
}
