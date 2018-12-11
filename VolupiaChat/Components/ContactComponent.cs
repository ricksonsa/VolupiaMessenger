using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolupiaChat.Controls
{
    class ContactComponent
    {
        public static Panel CreateBlock(string name, string status)
        {
            Panel Body = new Panel()
            {
                Name = name,
                Size = new Size(288, 62),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Theme.GetBackColor()
            };

            PictureBox UserPic = new PictureBox()
            {

            };

            Body.Controls.Add(new Label()
            {
                Location = new Point(73, 6),
                Font = new Font("Tahoma",12,FontStyle.Regular),
                Text = name,
                ForeColor = Theme.GetForeColor()
            });

            Body.Controls.Add(new Label()
            {
                Size = new Size(60, 13),
                Font = new Font("Tahoma", 7, FontStyle.Regular),
                Location = new Point(88, 37),
                Text = "Hello there, I'm new in Volupia Messenger!",
                ForeColor = Theme.GetForeColor()
            });

            Panel Cover = new Panel()
            {
                Size = new Size(288, 62),
                BorderStyle = BorderStyle.None,
                BackColor = Color.Transparent,
            };
            Cover.MouseEnter += Cover_MouseEnter;
            Cover.MouseLeave += Cover_MouseLeave;
            Cover.MouseDoubleClick += Cover_Click;
            Body.Controls.Add(Cover);

            return Body;
        }

        private static void Cover_Click(object sender, EventArgs e)
        {
            Chat.SetConversation(((Control)sender).Parent.Name);
        }

        private static void Cover_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).Parent.BackColor = Theme.GetBackColor();
        }

        private static void Cover_MouseEnter(object sender, EventArgs e)
        {
            Theme.HoverControl(((Control)sender).Parent);
        }
    }
}
