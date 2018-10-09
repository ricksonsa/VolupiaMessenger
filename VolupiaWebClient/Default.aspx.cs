using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolupiaInterfaces;

namespace VolupiaWebClient
{
    public partial class _Default : Page
    {
        public static IVolupiaService VServer;
        private static string myUserName;
        private static TextBox DisplayTxtBoxT = new TextBox();
        private static ListBox UserListT = new ListBox();

        private static DuplexChannelFactory<IVolupiaService> _channelFactory;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserListT.TextChanged += UserListT_TextChanged;
            _channelFactory = new DuplexChannelFactory<IVolupiaService>(new VolupiaWebCallBack(), "VolupiaServiceEndPoint");
            VServer = _channelFactory.CreateChannel();
            DisplayTxtBox = new TextBox
            {
                Text = DisplayTxtBoxT.Text
            };

        }

        private void UserListT_TextChanged(object sender, EventArgs e)
        {
            UserListBox.Text = UserListT.Text;
        }


        public static void TakeMessage(string message, string userName)
        {
            DisplayTxtBox.Text += userName + ": " + message;
            DisplayTxtBoxT.Text = DisplayTxtBox.Text;
            //DisplayTxtBox.SelectionStart = DisplayTxtBox.Text.Length;
            //DisplayTxtBox.ScrollToCaret();
        }

        public static void AddUserToList(string userName)
        {
            foreach (var item in UserListT.Items)
            {
                if (item.ToString().Equals(userName))
                    return;
                UserListT.Items.Add(userName);
            }
        }

        public static void RemoveUserFromList(string userName)
        {
            foreach (var item in UserListT.Items)
            {
                if (item.ToString().Equals(userName))
                    return;
                UserListT.Items.Remove(userName);
            }
        }

        protected void SendTxtBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InputTxtBox.Text))
            {
                try
                {
                    VServer.SendMessageToALL(InputTxtBox.Text, myUserName);
                    TakeMessage(InputTxtBox.Text, "Você");
                    InputTxtBox.Text.Remove(0, InputTxtBox.Text.Length);
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void DisplayTxtBox_TextChanged(object sender, EventArgs e)
        {
            DisplayTxtBox.Text += '\n';
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            int returnvalue = VServer.Login(LoginTxtBox.Text);
            if (returnvalue == 1)
            {
                Response.Write("<script>alert('Você já está logado!');</script>");
                myUserName = LoginTxtBox.Text;
            }
            else
            {
                /*LoginTxtBox.Visible = false;
                LoginBtn.Visible = false;
                DisplayTxtBox.Visible = true;
                UserListBox.Visible = true;
                InputTxtBox.Visible = true;
                SendTxtBtn.Visible = true;*/
            }
        }
    }
}