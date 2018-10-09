using System;
using System.ServiceModel;
using VolupiaInterfaces;
using VolupiaChat;
using System.IO;

namespace VolupiaMessenger
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, AutomaticSessionShutdown = false, IncludeExceptionDetailInFaults = true)]
    public class VolupiaClientCallBack : IClient
    {
        public void GetAudioMessage(MemoryStream ms, string userName, string meta)
        {
            if (Form1._channelFactory.State == CommunicationState.Opened)
            {
                try
                {
                    Chat.TakeAudioMessage(ms, userName, meta);
                }
                catch (Exception ex)
                {
                    Form1.Server.UserLogWrite(Chat.myUserName, "[Erro em GetAudioMessage(" + userName + ") [ClientCallback] -> " + ex.ToString());
                }  
            }      
        }

        public void GetMessage(string message, string userName)
        {
            if (Form1._channelFactory.State == CommunicationState.Opened)
            {
                try
                {
                    Chat.TakeMessage(message, userName);
                }
                catch (Exception ex)
                {
                    Form1.Server.UserLogWrite(Chat.myUserName, "[Erro em GetMessage("+userName+") [ClientCallback] -> " + ex.ToString());
                }
            }      
        }

        public void SendResponse()
        {
            Chat.SendResponse();
        }

        public void GetUpdate(int value, string userName)
        {
            if (Form1._channelFactory.State == CommunicationState.Opened)
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
}
