using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using VolupiaChat.Controls;
using VolupiaInterfaces;
using VolupiaMessenger;

namespace VolupiaChat
{
    public partial class LoginForm : Form
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

        public LoginForm()
        {
            Theme.SetTheme();

            InitializeComponent();
            ApplyTheme();

            ServerConnectionState = VConnectionState.Disconnected;

            //#region AutoLogin
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupialog.temp"))
            {
                FileInfo file = new FileInfo(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupialog.temp");
                if (file.Length > 0)
                {
                    RememberUserCB.Checked = true;
                    var data = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupialog.temp");
                    LoginRtb.Text = data[0];
                    passMTextBox.Text = data[1];
                }
            }

            //if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupia.temp"))
            //{
            //    var result = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupia.temp");
            //    if (result == "1")
            //    {
            //        if (!string.IsNullOrEmpty(LoginRtb.Text))
            //        {
            //            ButtonLogin.Enabled = false;
            //            button1.Enabled = false;
            //            Thread.Sleep(2000);
            //            try
            //            {
            //                CreateChannel();
            //                GetAccount(Server.ValidateUser(LoginRtb.Text, passMTextBox.Text));
            //            }
            //            catch (EndpointNotFoundException)
            //            {
            //                System.Windows.Forms.MessageBox.Show("O servidor não está disponível no momento, tente novamente mais tarde.", "Volupia Messenger");
            //                return;
            //            }

            //            if (RememberUserCB.Checked)
            //            {
            //                string[] data = new string[] { LoginRtb.Text, passMTextBox.Text };
            //                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupialog.temp", data);
            //            }
            //            else
            //            {
            //                File.Delete(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupialog.temp");
            //            }

            //            if (AutoLoginCB.Checked)
            //                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupia.temp", "1");
            //            else
            //                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\volupia.temp", "0");

            //            ButtonLogin.Enabled = true;
            //            button1.Enabled = true;
            //        }

            //    }
            //}
            //#endregion
        }

        private void ApplyTheme()
        {
            BackColor = Theme.GetBackColor();

            foreach (var rtb in Controls)
            {
                if (rtb.GetType().Equals(typeof(RichTextBox)))
                {
                    ((RichTextBox)rtb).BackColor = Theme.GetBackColor();
                    ((RichTextBox)rtb).ForeColor = Theme.GetForeColor();
                }

                if (rtb.GetType().Equals(typeof(Label)))
                {
                    ((Label)rtb).ForeColor = Theme.GetForeColor();
                }

                if (rtb.GetType().Equals(typeof(CheckBox)))
                {
                    ((CheckBox)rtb).ForeColor = Theme.GetForeColor();
                }

            }

            TitleLbl.ForeColor = Theme.GetForeColor();
            passMTextBox.BackColor = Theme.GetBackColor();
            passMTextBox.ForeColor = Theme.GetForeColor();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ButtonLogin.Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, ButtonLogin.Width, ButtonLogin.Height, 25, 25));
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
            ButtonLogin.Enabled = false;
            ButtonLogin.Visible = false;
            button1.Visible = false;
            ConnectingLbl.Visible = true;
            UseWaitCursor = true;

            try
            {
                CreateChannel();
                var password = passMTextBox.Text.GetHashCode();
                var MyUser = JsonConvert.DeserializeObject<Client>(Server.Login(LoginRtb.Text, password.ToString()));
                var frm2 = new MessageBox.HelloMessage(MyUser);
                frm2.Show();
                frm2.Focus();
                this.Size = new Size(10, 10);
                this.Visible = false;
            }
            catch (EndpointNotFoundException)
            {
                System.Windows.Forms.MessageBox.Show("O servidor não está disponível no momento, tente novamente mais tarde.", "Volupia Messenger");
                return;
            }
            catch (CommunicationObjectFaultedException)
            {
                System.Windows.Forms.MessageBox.Show("O cliente não conseguiu se comunicar com o servidor", "Volupia Messenger");
            }
            catch (FaultException fex)
            {
                System.Windows.Forms.MessageBox.Show(fex.Message, "Volupia Messenger");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Volupia Messenger");
            }

            finally
            {
                ButtonLogin.Enabled = true;
                ButtonLogin.Visible = true;
                ConnectingLbl.Visible = false;
                UseWaitCursor = false;
            }

            if (RememberUserCB.Checked)
            {
                string[] data = new string[] { LoginRtb.Text, passMTextBox.Text };
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
            CreateChannel();
        }

        private void UserTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                LoginBtn_Click(sender, e);
            }
        }

        #region Visuals
        //private void panel1_MouseHover(object sender, EventArgs e)
        //{
        //    
        //}

        //private void panel1_MouseLeave(object sender, EventArgs e)
        //{
        //    
        //}

        private void LoginRtb_Enter(object sender, EventArgs e)
        {
            if (LoginRtb.Text == "Email ou Username")
                LoginRtb.Text = string.Empty;
        }
        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void PassRtb_Enter(object sender, EventArgs e)
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

        private void passMTextBox_MouseEnter(object sender, EventArgs e)
        {
            passMTextBox.SelectAll();
        }

        private void ButtonLogin_MouseEnter(object sender, EventArgs e)
        {
            Theme.HoverControl((Control)sender);
        }

        private void ButtonLogin_MouseLeave(object sender, EventArgs e)
        {
            Theme.LeaveControl((Control)sender);
        }

        private void ButtonLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonLogin.Location = new Point(37, 247);
        }

        private void ButtonLogin_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonLogin.Location = new Point(37, 245);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Theme.HoverControl((Control)sender);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Theme.LeaveControl((Control)sender);
        }

        private void CloseX_MouseEnter(object sender, EventArgs e)
        {
            Theme.HoverControl((Control)sender);
        }

        private void CloseX_MouseLeave(object sender, EventArgs e)
        {
            Theme.LeaveControl((Control)sender);
        }
    }
}
