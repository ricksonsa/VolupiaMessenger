using System;
using System.Drawing;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VolupiaChat.Controls;

namespace VolupiaChat
{
    public partial class SingUp : Form
    {
        public SingUp()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            UserNameTB.ForeColor = Theme.GetForeColor();
            UserNameTB.Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, UserNameTB.Width, UserNameTB.Height, 10, 10));
            PassordMTB.ForeColor = Theme.GetForeColor();
            PassordMTB.Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, UserNameTB.Width, UserNameTB.Height, 10, 10));
            MailTextBox.ForeColor = Theme.GetForeColor();
            MailTextBox.Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, UserNameTB.Width, UserNameTB.Height, 10, 10));
            NameTextBox.ForeColor = Theme.GetForeColor();
            NameTextBox.Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, UserNameTB.Width, UserNameTB.Height, 10, 10));
            TitleLbl.ForeColor = Theme.GetForeColor();
            PanelButton.Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, PanelButton.Width, PanelButton.Height, 10, 10));

            try
            {
                LoginForm.CreateChannel();
            }
            catch (Exception)
            {

            }
        }

        private void SingUp_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {   
            try
            {
                if (ValidateForm())
                {
                    var userName = UserNameTB.Text;
                    var password = PassordMTB.Text;
                    var mail = MailTextBox.Text;
                    var name = NameTextBox.Text;

                    var User = new Client(userName, password.GetHashCode().ToString(), name, mail);
                    if (LoginForm.Server.Register(Newtonsoft.Json.JsonConvert.SerializeObject(User)))
                    {
                        System.Windows.Forms.MessageBox.Show("Cadastro realizado", "Volupia Messenger");
                        Close();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Nao foi possivel cadastrar", "Volupia Messenger");
                    }
                }
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
            catch (FaultException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message,"Volupia Messenger");
            }
        }

        private void CloseX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelButton_Click(object sender, EventArgs e)
        {
            AcceptBtn_Click(sender, e);
        }

        private void PanelButton_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserNameTB_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length >= 4)
            {
                ErrorUserNameLengthLbl.Visible = false;
                if (LoginForm.ServerConnectionState == LoginForm.VConnectionState.Connected)
                {
                    if (LoginForm.Server.HasUser(((TextBox)sender).Text))
                        ErrorHasUserLbl.Visible = true;
                    else
                        ErrorHasUserLbl.Visible = false;
                }
            }
            else
                ErrorUserNameLengthLbl.Visible = true;
        }

        private bool ValidateForm()
        {
            

            if (PassordMTB.Text.Length >= 6 &&
                UserNameTB.Text.Length >= 4 &&
                //IsValidMail() &&
                !ErrorHasMailLbl.Visible &&
                !ErrorHasUserLbl.Visible)
                return true;

            return false;
        }

        private bool IsValidMail()
        {
            var regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            var match = regex.Match(PassordMTB.Text);
            if (match.Success)
                return true;
            else
                return false;
        }

        private void MailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length >= 4)
            {
                if (LoginForm.ServerConnectionState == LoginForm.VConnectionState.Connected)
                {
                    if (LoginForm.Server.HasMail(((TextBox)sender).Text))
                        ErrorHasMailLbl.Visible = true;
                    else
                        ErrorHasMailLbl.Visible = false;
                }
                if (!IsValidMail())
                    ErrorInvalidEmailLabl.Visible = true;
                else
                    ErrorInvalidEmailLabl.Visible = false;
            }
        }

        private void PassordMTB_TextChanged(object sender, EventArgs e)
        {
            if (((MaskedTextBox)sender).Text.Length >= 6)
                ErrorPassLbl.Visible = false;
            else
                ErrorPassLbl.Visible = true;
        }
    }
}
