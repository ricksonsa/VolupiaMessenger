using NAudio.Wave;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VolupiaChat.Controls;

namespace VolupiaChat
{
    class BubbleComponent
    {
        public string AudioFile { get; set; }
        public DateTime Time { get; set; }

        private void Body_ContentsResized(object sender, ContentsResizedEventArgs e, RichTextBox ea, Panel panel)
        {
            ((RichTextBox)sender).Height = e.NewRectangle.Height + 10;
            ((RichTextBox)sender).Width = ((RichTextBox)sender).Rtf.Length+60;

            if (((RichTextBox)sender).Width >= 260)
                ((RichTextBox)sender).Width = 260;

            ((RichTextBox)sender).Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, ((RichTextBox)sender).Width, ((RichTextBox)sender).Height, 15, 15));
            ((RichTextBox)sender).Parent.Height = ((RichTextBox)sender).Height + 49;
        }

        private void Body_TextChanged(object sender, EventArgs e, RichTextBox Body)
        {
            for (int i = 0; i < Body.Lines.Length; i++)
            {
                if (Body.Lines[i].Length > 34)
                {
                    var text = Body.Lines[i];
                    var newLine = text;
                    newLine = newLine.Remove(0, 34);
                    text = text.Substring(34);
                    Body.WordWrap = true;
                    Body.Text = text + Environment.NewLine + newLine;
                }
            }
        }

        public Panel CreateLeftTextBubble(string text, string userName)
        {
            RichTextBox Body = new RichTextBox()
            {
                Name = DateTime.Now.ToString("HHmmssfff"),
                Size = new Size(278, 81),
                Location = new Point(20,10),
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.None,
                WordWrap = true,
                ReadOnly = true,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Tahoma", 12, FontStyle.Regular),
                Text = text
            };

            LeftLabel Info = new LeftLabel()
            {
                BackColor = Color.Transparent,
                Location = new Point(195, 98),
                ForeColor = Theme.GetForeColor(),
                Anchor = AnchorStyles.Bottom,
                Text = DateTime.Now.ToString("HH:mm")
            };

            Panel BodyPanel = new Panel()
            {
                Name = "TextBox"+Body.Name,
                Size = new Size(839, 485),
                //Margin = new Padding(70, 0, 0, 0),
                BackColor = Theme.GetBackColor()
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
                Name = DateTime.Now.ToString("HHmmssfff"),
                Size = new Size(278, 81),//258.120
                Location = new Point(560, 10),
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.None,
                WordWrap = true,
                ReadOnly = true,
                BackColor = Color.PaleGreen,
                ForeColor = Color.Black,
                Anchor = (AnchorStyles.Right | AnchorStyles.Top),
                Font = new Font("Tahoma", 12, FontStyle.Regular),
                Text = text
            };
            //Body.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Body.Width, Body.Height, 15, 15));

            Panel BodyPanel = new Panel()
            {
                Name = "TextBox" + Body.Name,
                Size = new Size(839, 485),
                //Margin = new Padding(70, 0, 0, 0),
                BackColor = Theme.GetBackColor()
            };

            Label Info = new Label()
            {
                BackColor = Color.Transparent,
                Location = new Point(738, 98),//450.140
                ForeColor = Color.Black,
                Text = DateTime.Now.ToString("HH:mm")
            };

            //Body.TextChanged += (sender, e) => Body_TextChanged(sender, e, Body);
            Body.ContentsResized += (sender, e) => Body_ContentsResized(sender, e, Body, BodyPanel);
            BodyPanel.Controls.Add(Info);
            BodyPanel.Controls.Add(Body);

            BodyPanel.Refresh();
            return BodyPanel;
        }

        public Panel CreateLeftAudioBubble(string text, string userName)
        {
            Panel BodyPanel = new Panel()
            {
                Size = new Size(839, 130),//Original 729, 168
                Margin = new Padding(0, 0, 0, 0),
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Theme.GetBackColor()
            };
            RoundPanel AudioPanel = new RoundPanel()
            {
                Name = AudioFile,
                BackColor = Color.White,
                Size = new Size(253, 81),
                Location = new Point(20, 15)

            };
            AudioPanel.Region = System.Drawing.Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, AudioPanel.Width, AudioPanel.Height, 20, 20));
            LeftLabel Info = new LeftLabel()
            {
                BackColor = Color.Transparent,
                Location = new Point(195, 98),
                ForeColor = Theme.GetForeColor(),
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
            RoundButton ButtonPic = new RoundButton()
            {
                Size = new Size(64, 62),
                Location = new Point(8, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Theme.GetForeColor(),

                BackgroundImage = Properties.Resources.play2,
                BackgroundImageLayout = ImageLayout.Stretch,
            };
            ButtonPic.FlatAppearance.BorderSize = 0;
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

        public Panel CreateRightAudioBubble(string text, string userName)
        {
            Panel BodyPanel = new Panel()
            {
                Size = new Size(839, 130),//Original 729, 168
                //Margin = new Padding(70, 0, 0, 0),
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Theme.GetBackColor()
            };
            RoundPanel AudioPanel = new RoundPanel()
            {
                Name = AudioFile,
                Size = new Size(253, 81),
                Location = new Point(560, 15),
                Anchor = AnchorStyles.Right,
                BackColor = Color.PaleGreen
            };

            AudioPanel.Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, AudioPanel.Width, AudioPanel.Height, 20, 20));

            Label Info = new Label()
            {
                BackColor = Color.Transparent,
                Location = new Point(611, 99),//450.140
                ForeColor = Theme.GetForeColor(),
                Anchor = AnchorStyles.Right,
                Text = DateTime.Now.ToString("HH:mm")
            };
            Label TimeInfo = new Label()
            {
                BackColor = Color.Transparent,
                Location = new Point(166, 53),
                ForeColor = Color.Black,
                Text = string.Empty
            };
            RoundButton ButtonPic = new RoundButton()
            {
                Size = new Size(64, 62),
                Location = new Point(8, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Theme.GetForeColor(),

                BackgroundImage = Properties.Resources.play2,
                BackgroundImageLayout = ImageLayout.Stretch,
            };
            ButtonPic.FlatAppearance.BorderSize = 0;
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

     
            BodyPanel.Refresh();

            return BodyPanel;
        }

    }
}

