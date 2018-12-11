using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;
using VolupiaChat.Controls;

namespace VolupiaChat
{
    public partial class InviteForm : Form
    {
        public InviteForm()
        {
            InitializeComponent();

            BackColor = Theme.GetBackColor();
            PersonFlowLayoutPanel.BackColor = Theme.GetBackColor();
            IconsFlowLayoutPanel.BackColor = Theme.GetBackColor();

            SearchPanel.Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, SearchPanel.Width, SearchPanel.Height, 60, 60));
        }

        private void SearchRtb_TextChanged(object sender, EventArgs e)
        {
            if (!HasElement())
            {
                foreach (Control c in PersonFlowLayoutPanel.Controls)
                    c.Dispose();
                foreach (Control c in IconsFlowLayoutPanel.Controls)
                    c.Dispose();
            }
            else
                UsersLbl.Visible = false;

            SearchPerson();
        }

        private void SearchRtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private bool HasElement()
        {
            if (PersonFlowLayoutPanel.Controls.Count > 0)
            {
                foreach (Control c in PersonFlowLayoutPanel.Controls)
                {
                    if (c.Name.Contains(SearchRtb.Text))
                        return true;
                }
            }
            return false;
        }

        private void SearchPerson()
        {
            if (SearchRtb.Text.Length > 3)
            {

                if (SearchRtb.Text != "Buscar...")
                {
                    if (!HasElement())
                    {
                        if (LoginForm.ServerConnectionState == LoginForm.VConnectionState.Connected)
                        {
                            //Traz uma lista de clients que contenham nome da caixa de busca
                            var list = LoginForm.Server.FindByName(SearchRtb.Text);

                            if (list != null)
                            {
                                if (list.Count > 0)
                                {
                                    //para cada pessoa na lista de pessoas com nome = a caixa de busca
                                    foreach (var item in list)
                                    {
                                        var person = JsonConvert.DeserializeObject<Client>(item);

                                        if (person.Username != Chat.myUserName)
                                        {
                                            PersonFlowLayoutPanel.Controls.Add(InvitationComponent.CreateBlock(person.Name, person.Username));
                                            IconsFlowLayoutPanel.Controls.Add(InvitationComponent.CreateAddIcon(person.Username));
                                            UsersLbl.Visible = true;

                                            if (LoginForm.Server.IsFriendOrInvited(Chat.myUserId, person.Id))
                                            {
                                                foreach (PictureBox pb in IconsFlowLayoutPanel.Controls)
                                                {
                                                    if (pb.Name.Equals(person.Username))
                                                        pb.BackgroundImage = Properties.Resources.correct1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SearchRtb_Enter(object sender, EventArgs e)
        {
            SearchRtb.Text = string.Empty;
            SearchRtb.ForeColor = Color.Black;
        }

        private void SearchRtb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchRtb.Text))
            {
                SearchRtb.ForeColor = Color.LightGray;
                SearchRtb.Text = "Buscar...";
            }
        }

        private void PersonFlowLayoutPanel_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

    }
    public class Friend
    {
        private int id;
        private int userId;
        private int friendId;
        private bool accepted;

        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public int FriendId { get => friendId; set => friendId = value; }
        public bool Accepted { get => accepted; set => accepted = value; }
    }
}
