using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace VolupiaChat.Controls
{
    public class NotificationComponent
    {
        private static int Id { get; set; }

        public static Panel CreateBlock(string name, int id)
        {
            Id = id;

            Panel Body = new Panel()
            {
                Name = name,
                Size = new Size(351, 56),
                Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, 351, 56, 6, 6)),
                Dock = DockStyle.Left,
                BackColor = Color.White,
                //BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox ImageBox = new PictureBox
            {

            };

            RoundButton AcceptBtn = new RoundButton()
            {
                Name = "aI" + id.ToString(),
                Size = new Size(28, 23),
                BackgroundImage = Properties.Resources.Accept,
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new Point(320, 3),
                Text = string.Empty,
                FlatStyle = FlatStyle.Flat
            };
            AcceptBtn.FlatAppearance.BorderSize = 0;
            AcceptBtn.Click += AcceptBtn_Click;

            RoundButton RejectBtn = new RoundButton()
            {
                Name = "rI" + id.ToString(),
                Size = new Size(28, 23),
                BackgroundImage = Properties.Resources.Reject,
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new Point(320, 29),
                Text = string.Empty,
                FlatStyle = FlatStyle.Flat
            };
            RejectBtn.FlatAppearance.BorderSize = 0;
            RejectBtn.Click += RejectBtn_Click;

            Body.Controls.Add(new Label
            {
                AutoSize = false,
                Size = new Size(Body.Size.Width - 100, 16),
                Location = new Point(63, 5),
                Text = "Solicitação de amizade",
                Font = new Font("Tahoma", 10, FontStyle.Regular),
                ForeColor = Color.Black
            });

            Body.Controls.Add(new LeftLabel
            {
                AutoSize = false,
                Size = new Size(155, 13),
                Location = new Point(60, 31),
                Text = "Convite de amizade de " + name,
                Font = new Font("Tahoma", 8, FontStyle.Regular),
                ForeColor = Color.Black
            });

            Body.Controls.Add(AcceptBtn);
            Body.Controls.Add(RejectBtn);

            return Body;
        }

        private static void RejectBtn_Click(object sender, EventArgs e)
        {
            if (LoginForm.ServerConnectionState == LoginForm.VConnectionState.Connected)
            {
                var name = ((RoundButton)sender).Name.Split('I');
                LoginForm.Server.Reject(Convert.ToInt16(name[1]));
                ((RoundButton)sender).Parent.Dispose();
            }
        }

        private static void AcceptBtn_Click(object sender, EventArgs e)
        {
            if (LoginForm.ServerConnectionState == LoginForm.VConnectionState.Connected)
            {
                var name = ((RoundButton)sender).Name.Split('I');
                LoginForm.Server.Accept(Convert.ToInt16(name[1]));
                ((RoundButton)sender).Parent.Dispose();
                Chat.GetContacts();
            }

        }
    }
}
