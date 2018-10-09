using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolupiaInterfaces;
using VolupiaMessenger;

namespace VolupiaChat
{
    public partial class Form1 : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public static DuplexChannelFactory<IVolupiaService> _channelFactory;
        public static IVolupiaService Server;

        [Flags]
        public enum VConnectionState
        {
            Disconnected = 1,
            Connected = 2,
            Faulted = 3,
        }

        public static VConnectionState ServerConnectionState { get; set; }

        public Form1()
        {
            InitializeComponent();

            ServerConnectionState = VConnectionState.Disconnected;

            #region AutoLogin
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupialog.temp"))
            {
                string[] data = new string[2];
                FileInfo file = new FileInfo(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupialog.temp");
                if (file.Length > 0)
                {
                    RememberUserCB.Checked = true;
                    data = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupialog.temp");
                    LoginRtb.Text = data[0];
                    passMTextBox.Text = data[1];
                }
            }

            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupia.temp"))
            {
                var result = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupia.temp");
                if (result == "1")
                {
                    if (!string.IsNullOrEmpty(LoginRtb.Text))
                        LoginBtn_Click(null, null);
                }
            }
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static void CreateChannel()
        {
            _channelFactory = new DuplexChannelFactory<IVolupiaService>(new VolupiaClientCallBack(), "VolupiaServiceEndPoint");
            Server = _channelFactory.CreateChannel();        
            if (_channelFactory.State == CommunicationState.Opened || _channelFactory.State == CommunicationState.Created)
                ServerConnectionState = VConnectionState.Connected;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            bool userValidated = false;

            try
            {
                CreateChannel();
                userValidated = Server.CheckAccount(LoginRtb.Text, passMTextBox.Text);
            }
            catch (EndpointNotFoundException)
            {
                System.Windows.Forms.MessageBox.Show("O servidor não está disponível no momento, tente novamente mais tarde.", "Volupia Messenger");
                return;
            }
            if (userValidated)
            {
                var MyUser = Server.GetAccount(LoginRtb.Text, passMTextBox.Text);
                try
                {
                    int returnvalue = Server.Login(MyUser[2]);
                    if (returnvalue == 1)
                    {
                        System.Windows.Forms.MessageBox.Show("Você já está logado!", "Volupia Messenger");
                    }
                    else
                    {
                        MessageBox.HelloMessage frm2 = new MessageBox.HelloMessage(MyUser);
                        frm2.Show();
                        frm2.Focus();
                        this.Size = new Size(10, 10);
                        this.Visible = false;
                        //this.Close();
                    }
                }
                catch (FaultException)
                {
                    System.Windows.Forms.MessageBox.Show("O cliente não conseguiu se comunicar com o servidor", "Volupia Messenger");
                }
                catch (CommunicationObjectFaultedException)
                {
                    System.Windows.Forms.MessageBox.Show("O cliente não conseguiu se comunicar com o servidor", "Volupia Messenger");
                }
            }
            else
            {
                //Server.LogWrite(LoginRtb.Text, "Acesso negado");
                System.Windows.Forms.MessageBox.Show("Usuário não encontrado ou senha incorreta.", "Volupia Messenger");
                this.Focus();
            }

            /*if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupia.temp"))
            {
                File.CreateText(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupia.temp");
                File.CreateText(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupialog.temp");
            }*/

            if (RememberUserCB.Checked)
            {
                string[] data = new string[2];
                data[0] = LoginRtb.Text;
                data[1] = passMTextBox.Text;
                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupialog.temp", data);
            }
            else
            {
                File.Delete(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupialog.temp");
            }

            if (AutoLoginCB.Checked)
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupia.temp", "1");
            else
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupia.temp", "0");
        }

        private void _channelFactory_Faulted(object sender, EventArgs e)
        {
            Server = _channelFactory.CreateChannel();
        }

        private void UserTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                LoginBtn_Click(sender, e);
            }
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.Location = new Point(37, 247);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.Location = new Point(37, 245);
        }

        private void LoginRtb_Enter(object sender, EventArgs e)
        {
            if (LoginRtb.Text == "Email ou Username")
                LoginRtb.Text = string.Empty;
        }

        private void PassRtb_Enter(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CloseX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PassRtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginBtn_Click(sender, e);
        }

        private void passMTextBox_TabIndexChanged(object sender, EventArgs e)
        {
            passMTextBox.SelectAll();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.Show();
        }
    }
}
