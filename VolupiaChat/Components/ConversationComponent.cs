using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace VolupiaChat.Controls
{
    class ConversationComponent
    {
        public static Panel CreateBlock(string name, string text, string time)
        {
            Panel Body = new Panel()
            {
                Name = name,
                Size = new Size(288, 73),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Theme.GetBackColor()
            };

            PictureBox UserPic = new PictureBox()
            {

            };

            Body.Controls.Add(new Label()
            {
                AutoSize = false,
                Size = new Size(Body.Width - 120, 16),
                Location = new Point(73, 6),
                Font = new Font("Tahoma",10,FontStyle.Bold),
                Text = name,
                ForeColor = Theme.GetForeColor()
            });

            Body.Controls.Add(new Label()
            {
                Name = "text",
                AutoSize = false,
                Size = new Size(Body.Width - 40, 13),
                Location = new Point(73, 37),
                Font = new Font("Tahoma", 8, FontStyle.Regular),
                Text = text,
                ForeColor = Theme.GetForeColor()
            });

            Body.Controls.Add(new Label()
            {
                Name="time",
                Size = new Size(60, 13),
                Location = new Point(250, 55),
                Text = time,
                ForeColor = Color.Gray
            });

            RoundButton Count = new RoundButton()
            {
                Name = "count",
                Enabled = false,
                Size = new Size(27, 24),
                Location = new Point(257, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGreen,
                ForeColor = Color.White,
                Text = "1",
                Visible = true
            };
            Count.FlatAppearance.BorderSize = 0;
            Body.Controls.Add(Count);

            Panel Cover = new Panel()
            {
                Size = new Size(288, 73),
                BorderStyle = BorderStyle.None,
                BackColor = Color.Transparent,
            };
            Cover.MouseEnter += Cover_MouseEnter;
            Cover.MouseLeave += Cover_MouseLeave;
            Cover.Click += Cover_Click;
            Body.Controls.Add(Cover);

            return Body;
        }

        private static void Cover_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).Parent.BackColor = Theme.GetBackColor();
        }

        private static void Cover_Click(object sender, EventArgs e)
        {
            Chat.SetConversation(((Control)sender).Parent.Name);
        }

        private static void Cover_MouseEnter(object sender, EventArgs e)
        {
            Theme.HoverControl(((Control)sender).Parent);
        }
    }
}
