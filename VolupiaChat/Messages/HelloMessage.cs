using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolupiaChat.Controls;

namespace VolupiaChat.MessageBox
{
    public partial class HelloMessage : Form
    {
        static public Chat ChatWindow;
        private Client myUser;

        public HelloMessage(Client MyUser)
        {
            InitializeComponent();
            Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, Width, Height, 90, 80));
            myUser = MyUser;
            NameRtb.Text += myUser.Name;
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
