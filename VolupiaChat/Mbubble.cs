using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolupiaChat
{
    class Mbubble
    {
        public string AudioFile { get; set; }
        public DateTime Time { get; set; }

        private void Body_ContentsResized(object sender, ContentsResizedEventArgs e, RichTextBox ea, Panel panel)
        {
            ea.Height = e.NewRectangle.Height + 5;
            ea.Width = e.NewRectangle.Width + 2;
            panel.Height = ea.Height + 49;
        }

        public Panel CreateLeftTextBubble(string text, string userName)
        {
            RichTextBox Body = new RichTextBox()
            {
                Name = DateTime.Now.ToString("HHmmssfff"),
                Size = new Size(278, 81),//258 120
                Location = new Point(28, 15),//28,15
                BorderStyle = BorderStyle.FixedSingle,
                ScrollBars = RichTextBoxScrollBars.None,
                Anchor = AnchorStyles.Top,
                WordWrap = true,
                ReadOnly = true,
                BackColor = Color.Azure,
                ForeColor = Color.Black,
                Font = new Font("Tahoma", 12, FontStyle.Regular),
                Text = " " + text
            };
            Label Info = new Label()
            {
                BackColor = Color.Transparent,
                Location = new Point(196, 99),//Original 31, 138
                ForeColor = Color.Black,
                Anchor = AnchorStyles.Bottom,
                Text = DateTime.Now.ToString("HH:mm")
            };
            Panel BodyPanel = new Panel()
            {
                Size = new Size(729, 130),//Original 729, 168
                Margin = new Padding(20, 0, 0, 0),
                Dock = DockStyle.Left,
                /*BorderStyle = BorderStyle.Fixed3D,
                BackgroundImage = VolupiaChat.Properties.Resources.LeftBaloon,
                BackgroundImageLayout = ImageLayout.Stretch*/
                BackColor = Color.Azure
            };
            Body.ContentsResized += (sender, e) => Body_ContentsResized(sender, e, Body, BodyPanel);
            BodyPanel.Controls.Add(Body);
            BodyPanel.Controls.Add(Info);

            return BodyPanel;
        }

        public Panel CreateRightTextBubble(string text, string userName)
        {
            RichTextBox Body = new RichTextBox()
            {
                Size = new Size(278, 81),//258.120
                Location = new Point(440, 20),//440.20
                BorderStyle = BorderStyle.FixedSingle,
                ScrollBars = RichTextBoxScrollBars.None,
                Anchor = AnchorStyles.Top,
                ReadOnly = true,
                BackColor = Color.Azure,
                ForeColor = Color.Black,
                Font = new Font("Tahoma", 12, FontStyle.Regular),
                Text = text
            };
            Label Info = new Label()
            {
                BackColor = Color.Transparent,
                Location = new Point(613, 104),//450.140
                ForeColor = Color.Black,
                Anchor = AnchorStyles.Bottom,
                Text = DateTime.Now.ToString("HH:mm")
            };
            Panel BodyPanel = new Panel()
            {
                Size = new Size(729, 130),
                Margin = new Padding(70, 0, 0, 0),
                Dock = DockStyle.Right,
                /*BackgroundImage = VolupiaChat.Properties.Resources.RightBaloon1,
                BackgroundImageLayout = ImageLayout.Stretch*/
                BackColor = Color.Azure
            };
            Body.ContentsResized += (sender, e) => Body_ContentsResized(sender, e, Body, BodyPanel);
            BodyPanel.Controls.Add(Body);
            BodyPanel.Controls.Add(Info);

            return BodyPanel;
        }

        public Panel CreateLeftAudioBubble(string text, string userName)
        {
            Panel BodyPanel = new Panel()
            {
                Size = new Size(729, 130),//Original 729, 168
                Margin = new Padding(20, 0, 0, 0),
                Dock = DockStyle.Left,
                /*BorderStyle = BorderStyle.Fixed3D,
                BackgroundImage = VolupiaChat.Properties.Resources.LeftBaloon,
                BackgroundImageLayout = ImageLayout.Stretch*/
                BackColor = Color.Azure
            };
            Panel AudioPanel = new Panel()
            {
                Name = AudioFile,
                Size = new Size(253, 81),
                Location = new Point(31, 15),
                BorderStyle = BorderStyle.FixedSingle
            };
            Label Info = new Label()
            {
                BackColor = Color.Transparent,
                Location = new Point(196, 99),//450.140
                ForeColor = Color.Black,
                Anchor = AnchorStyles.Bottom,
                Text = DateTime.Now.ToString("HH:mm")
            };
            Label TimeInfo = new Label()
            {
                BackColor = Color.Transparent,
                Location = new Point(166, 53),
                ForeColor = Color.Black,
                Text = string.Empty
            };
            PictureBox ButtonPic = new PictureBox()
            {
                Size = new Size(57, 60),
                Location = new Point(13, 10),
                BackgroundImage = Properties.Resources.PlayBtn,
                BackgroundImageLayout = ImageLayout.Stretch,
            };
            TrackBar ElapsedBar = new TrackBar()
            {
                Size = new Size(169, 45),
                Location = new Point(75, 31),
                TickStyle = TickStyle.None
            };
            ButtonPic.Click += (sender, e) => Chat.ButtonPic_Click(sender, e, ButtonPic, AudioPanel.Name, ElapsedBar);


            FileStream ms = File.OpenRead(AudioFile);
            var rdr = new WaveFileReader(ms);
            var ts = new TimeSpan();
            ts = rdr.TotalTime;
            ElapsedBar.Maximum = (int)ts.TotalSeconds*100;
            string time = rdr.TotalTime.ToString();
            time = time.Remove(time.LastIndexOf('.'), 8);
            TimeInfo.Text = time;

            ms.Dispose();
            rdr.Dispose();

            AudioPanel.Controls.Add(TimeInfo);
            AudioPanel.Controls.Add(ButtonPic);
            AudioPanel.Controls.Add(ElapsedBar);

            BodyPanel.Controls.Add(Info);
            BodyPanel.Controls.Add(AudioPanel);

            return BodyPanel;
        }

        public Panel CreateRightAudioBubble(string text, string userName)
        {
            Panel BodyPanel = new Panel()
            {
                Size = new Size(729, 130),//Original 729, 168
                Margin = new Padding(70, 0, 0, 0),
                Dock = DockStyle.Right,
                /*BorderStyle = BorderStyle.Fixed3D,
                BackgroundImage = VolupiaChat.Properties.Resources.LeftBaloon,
                BackgroundImageLayout = ImageLayout.Stretch*/
                BackColor = Color.Azure
            };
            Panel AudioPanel = new Panel()
            {
                Name = AudioFile,
                Size = new Size(253, 81),
                Location = new Point(445, 15),
                BorderStyle = BorderStyle.FixedSingle
            };
            Label Info = new Label()
            {
                BackColor = Color.Transparent,
                Location = new Point(611, 99),//450.140
                ForeColor = Color.Black,
                Anchor = AnchorStyles.Bottom,
                Text = DateTime.Now.ToString("HH:mm")
            };
            Label TimeInfo = new Label()
            {
                BackColor = Color.Transparent,
                Location = new Point(166, 53),
                ForeColor = Color.Black,
                Text = string.Empty
            };
            PictureBox ButtonPic = new PictureBox()
            {
                Size = new Size(57, 60),
                Location = new Point(13, 10),
                BackgroundImage = Properties.Resources.PlayBtn,
                BackgroundImageLayout = ImageLayout.Stretch,
            };
            TrackBar ElapsedBar = new TrackBar()
            {
                Size = new Size(169, 45),
                Location = new Point(75, 31),
                TickStyle = TickStyle.None
            };
            ButtonPic.Click += (sender, e) => Chat.ButtonPic_Click(sender, e, ButtonPic, AudioPanel.Name, ElapsedBar);


            FileStream ms = File.OpenRead(AudioFile);
            var rdr = new WaveFileReader(ms);
            var ts = new TimeSpan();
            ts = rdr.TotalTime;
            ElapsedBar.Maximum = (int)ts.TotalSeconds * 100;
            string time = rdr.TotalTime.ToString();
            time = time.Remove(time.LastIndexOf('.'), 8);
            TimeInfo.Text = time;

            ms.Dispose();
            rdr.Dispose();

            AudioPanel.Controls.Add(TimeInfo);
            AudioPanel.Controls.Add(ButtonPic);
            AudioPanel.Controls.Add(ElapsedBar);

            BodyPanel.Controls.Add(Info);
            BodyPanel.Controls.Add(AudioPanel);

            return BodyPanel;
        }

    }
}

