using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolupiaChat.MessageBox
{
    public partial class HelloMessage : Form
    {
        static public Chat ChatWindow;
        private string[] myUser;

        public HelloMessage(string[] MyUser)
        {
            InitializeComponent();
            myUser = MyUser;
            NameRtb.Text += myUser[1];
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChatWindow = new Chat(myUser);
            ChatWindow.Show();
            ChatWindow.Focus();
            this.Visible = false;
            timer1.Stop();
        }
    }
}
