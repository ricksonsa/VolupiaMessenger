using System;
using System.Drawing;
using System.Windows.Forms;

namespace VolupiaChat.Controls
{
    public class InvitationComponent
    {
        public static Panel CreateBlock(string name, string username)
        {
            Panel BodyPanel = new Panel
            {
                Name = username,
                Size = new Size(417, 41),
                Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0,0,417,41,30,30)),
                BackColor = Color.White
            };

            Label UserNameLabel = new Label
            {
                Text = username,
                Dock = DockStyle.Right,
                AutoSize = false,
                Font = new Font("Tahoma", 12, FontStyle.Regular),
                ForeColor = Theme.GetForeColor()
            };

            Label NameLabel = new Label
            {
                Text = name,
                Dock = DockStyle.Left,
                AutoSize = false,
                Size = new Size(BodyPanel.Size.Width / 2, UserNameLabel.Size.Height),
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                ForeColor = Theme.GetForeColor()
            };

            BodyPanel.Controls.Add(NameLabel);
            BodyPanel.Controls.Add(UserNameLabel);

            return BodyPanel;
        }

        public static PictureBox CreateAddIcon(string username)
        {
            PictureBox AddIcon = new PictureBox
            {
                Name = username,
                Size = new Size(59, 41),
                BackgroundImage = Properties.Resources.plus,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            //var invites = LoginForm.Server.GetInvites(Chat.myUserId);

            AddIcon.Click += AddIcon_Click;
            AddIcon.MouseEnter += AddIcon_MouseEnter;
            AddIcon.MouseLeave += AddIcon_MouseLeave;

            return AddIcon;
        }

        private static void AddIcon_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Transparent;
        }

        private static void AddIcon_MouseEnter(object sender, EventArgs e)
        {
            Theme.HoverControl((Control)sender);
        }

        private static void AddIcon_Click(object sender, EventArgs e)
        {
            if(((PictureBox)sender).BackgroundImage != Properties.Resources.correct1)
            {
                if (LoginForm.ServerConnectionState == LoginForm.VConnectionState.Connected)
                {
                    LoginForm.Server.InviteFriend(Chat.myUserId, ((PictureBox)sender).Name);
                }
                ((PictureBox)sender).BackgroundImage = Properties.Resources.correct1;
            }
        }
    }
}
