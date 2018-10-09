using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolupiaMessenger_WFA_Final
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        /*private void loginTxtBox_TextChanged(object sender, EventArgs e)
        {
            Main frm = new Main(loginTxtBox.Text);
            int returnvalue = Main.Server.Login(loginTxtBox.Text);
            if (returnvalue == 1)
            {
                MessageBox.Show("Você já está logado!", "Erro!");
            }
            else
            {
                MessageBox.Show("Você está logado!", "Logado!");
                frm.Show();
                this.Close();
            }
        }*/
    }
}
