using System;
using System.ServiceModel;
using System.Windows;
using VolupiaInterfaces;

namespace VolupiaWPFClient
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private DuplexChannelFactory<IVolupiaService> _channelFactory;
        private IVolupiaService Server;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = UserEntryTB.Text, password = PasswordTB.Password.ToString();
            try
            {
                _channelFactory = new DuplexChannelFactory<IVolupiaService>(new VolupiaWPFClientCallBack(), "VolupiaServiceEndPoint");
                Server = _channelFactory.CreateChannel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Volupia Messenger");
            }
            if (Server.ValidateUser(login, password))
            {
                var MyUser = Server.GetUser(login, password);
                Chat chatWindow = new Chat(MyUser, Server);
                try
                {
                    int returnvalue = Chat.Server.Login(MyUser[2]);
                    if (returnvalue == 1)
                    {
                        MessageBox.Show("Você já está logado!", "Erro!");
                    }
                    else
                    {
                        chatWindow.Show();
                        chatWindow.Activate();
                        ((MainWindow)Application.Current.MainWindow).Close();
                    }
                }
                catch (System.ServiceModel.EndpointNotFoundException)
                {
                    MessageBox.Show("O servidor está offline no momento, tente novamente mais tarde.", "Volupia Messenger");
                }
                catch (System.ServiceModel.CommunicationObjectFaultedException)
                {
                    MessageBox.Show("O cliente não conseguiu se comunicar com o servidor", "Volupia Messenger");
                }
            }
            else
            {
                MessageBox.Show("Usuário não encontrado ou senha incorreta.", "Volupia Messenger");
                this.Focus();
            }
        }
    }
}
