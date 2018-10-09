/*using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolupiaWebClient
{
    public class VolupiaWebCallBack
    {
    }
}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VolupiaInterfaces;
using System.IO;

namespace VolupiaWebClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class VolupiaWebCallBack : IClient
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
                    VolupiaWebClient._Default.AddUserToList(userName);
                    break;
                case 1:
                    VolupiaWebClient._Default.RemoveUserFromList(userName);
                    break;
            }
        }
    }
}
