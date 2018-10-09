using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolupiaServer;

namespace VolupiaChat
{
    public partial class SingUp : Form
    {
        public SingUp()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            UserNameTextBlock.ForeColor = Color.White;
            PassordMTB.ForeColor = Color.White;
            MailTextBox.ForeColor = Color.White;
            NameTextBox.ForeColor = Color.White;
        }

        private void SingUp_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            var userName = UserNameTB.Text;
            var password = PassordMTB.Text;
            var mail = MailTextBox.Text;
            var name = NameTextBox.Text;
            bool uResult = false;

            Form1.CreateChannel();

            //try
            //{
                //uResult = Form1.Server.InsertUser(userName, password, mail, name);
               // uResult = VolupiaServer.VolupiaDAO.InsertUser(userName, password, mail, name);
            //}
            //catch (Exception ex)
            //{
            //    Form1.Server.UserLogWrite(userName, ex.ToString());
            //}

            //if (uResult)
            //{
                System.Windows.Forms.MessageBox.Show("Cadastro realizado.", "Volupia Messenger");
                this.Close();
            //}
            //else
            //    System.Windows.Forms.MessageBox.Show("Não foi possível realizar o cadastro.", "Volupia Messenger");
        }

        private void CloseX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
