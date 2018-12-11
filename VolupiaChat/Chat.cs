using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using VolupiaChat.Controls;
using Microsoft.Expression.Encoder;
using Microsoft.Expression.Encoder.Live;
using System.Collections.ObjectModel;
using Microsoft.Expression.Encoder.Devices;

namespace VolupiaChat
{
    public partial class Chat : Form
    {
        // Notificação na taskbar(glow)
        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool FlashStatus);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        //Objetos públicos
        private static RichTextBox DisplayRTBtext = new RichTextBox();
        private static NotifyIcon notifyTray = new NotifyIcon();
        private static ListBox UserListBox = new ListBox();
        private static FlowLayoutPanel NotificationsFLP;
        private static FlowLayoutPanel ContactsFLP;
        private static FlowLayoutPanel ConversationFLP;

        private static Panel BubblePlaceHolder;
        private static Client _MyClient;
        public static List<Client> ContactList;

        private static bool isMinimized;
        private static Label TalkingTolbl;

        internal static void SendResponse()
        {
            LoginForm.Server.GetResponse();
        }

        private static string audioAtual;
        private static string audioAnterior;
        private static int fileCount = 0;
        private static string nowPlaying;

        private int downCount;
        private bool isRecording = false;
        private TimeSpan AudioTimeCount;
        private System.Windows.Forms.Timer downTime;
        // Variaveis globais
        private WaveIn waveIn;
        private static WaveOut waveOut = new WaveOut();
        private WaveFileWriter waveFile;
        //private static WaveStream waveStream;
        private static WaveFileReader rdr;
        internal static string myUserName;
        internal static int myUserId;
        //private MemoryStream ms;

        #region(Chat Screen)
        public Chat(Client client)
        {
            InitializeComponent();

            UserListPanel.Controls.Add(UserListBox);
            UserListBox.Anchor = AnchorStyles.Right;
            UserListBox.BackColor = Theme.GetBackColor();
            UserListBox.ForeColor = Theme.GetForeColor();
            UserListBox.Dock = DockStyle.Fill;
            UserListBox.Visible = false;
            UserListBox.Font = new Font("Tahoma", 12, FontStyle.Regular);

            TalkingTolbl = new Label
            {
                Location = new Point(326, 14),
                Text = string.Empty,
                Font = new Font("Tahoma", 14, FontStyle.Regular)
            };
            Controls.Add(TalkingTolbl);

            BubblePlaceHolder = new Panel()
            {
                Name = "BubblePlaceHolder",
                Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom),
                AutoSize = false,
                Size = new Size(772, 447),
                Location = new Point(313, 52),
                Visible = true
            };
            Controls.Add(BubblePlaceHolder);

            ConversationFLP = new FlowLayoutPanel()
            {
                BorderStyle = BorderStyle.FixedSingle,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                AutoSize = true,
                Enabled = true,
                Visible = true
            };
            ConversationFLP.ControlAdded += ConversationFLP_ControlAdded;
            UserListPanel.Controls.Add(ConversationFLP);
            ConversationFLP.Dock = DockStyle.Fill;
            ConversationFLP.HorizontalScroll.Maximum = 0;
            ConversationFLP.HorizontalScroll.Visible = false;
            ConversationFLP.VerticalScroll.Visible = true;
            ConversationFLP.Refresh();

            ContactsFLP = new FlowLayoutPanel()
            {
                BorderStyle = BorderStyle.FixedSingle,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                AutoSize = true,
                Enabled = true,
                Visible = false
            };
            UserListPanel.Controls.Add(ContactsFLP);
            ContactsFLP.Dock = DockStyle.Fill;
            ContactsFLP.HorizontalScroll.Maximum = 0;
            ContactsFLP.HorizontalScroll.Visible = false;
            ContactsFLP.VerticalScroll.Visible = true;
            ContactsFLP.Refresh();

            //NPanel
            NotificationsFLP = new FlowLayoutPanel()
            {
                BorderStyle = BorderStyle.FixedSingle,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                AutoSize = true,
                Enabled = true,
                Visible = true
            };

            NotificationsFLP.ControlAdded += NotificationsFLP_ControlAdded;
            NotificationsFLP.ControlRemoved += NotificationsFLP_ControlRemoved;
            NPanel.Controls.Add(NotificationsFLP);
            NotificationsFLP.Dock = DockStyle.Fill;
            NotificationsFLP.HorizontalScroll.Maximum = 0;
            NotificationsFLP.HorizontalScroll.Visible = false;
            NotificationsFLP.VerticalScroll.Visible = true;
            NotificationsFLP.Refresh();

            ThisPanel.HorizontalScroll.Visible = false;

            RolesPanel.Controls.Add(ContactLbl);
            RolesPanel.Controls.Add(ConversationsLbl);

            notifyTray.BalloonTipIcon = ToolTipIcon.Info;
            notifyTray.BalloonTipTitle = "Volupia Messenger";
            //notifyTray.Icon = GetHiconForChat();
            notifyTray.Icon = new Icon(Environment.CurrentDirectory + @"\VolupiaChat.ico");
            notifyTray.BalloonTipClicked += NotifyTray_BalloonTipClicked;
            notifyTray.MouseDoubleClick += NotifyTray_MouseDoubleClick;

            //Button Fix
            MicRBtn.FlatStyle = FlatStyle.Flat;
            MicRBtn.BackColor = Color.Lavender;
            MicRBtn.FlatAppearance.BorderSize = 0;

            BarPanel.Region = Region.FromHrgn(GDI.CreateRoundRectRgn(0, 0, BarPanel.Width, BarPanel.Height, 60, 60)); //Arredonda caixa de texto

            SendRButton.FlatStyle = FlatStyle.Flat;
            SendRButton.BackColor = Color.Lavender;
            SendRButton.FlatAppearance.BorderSize = 0;

            ApplyTheme();

            downTime = new System.Windows.Forms.Timer
            {
                Interval = 500
            };

            downTime.Tick += DownTime_Tick;



            waveOut.PlaybackStopped += (s, e) =>
            {
                waveOut.Dispose();
            };

            _MyClient = client;
            myUserName = _MyClient.Username;
            myUserId = _MyClient.Id;

            NameLbl.Text = _MyClient.Name;
            notifyTray.Text = _MyClient.Name;
            downCount = 0;

            LoginForm.Server.Connected();
            TakeInvites();
            GetContacts();
        }

        private void ConversationFLP_ControlAdded(object sender, ControlEventArgs e)
        {


        }

        internal static void SetConversation(string name)
        {
            SetConversationPlaceHolder(name);
            TalkingTolbl.Text = name;

            ResetMessageCount(name);

            foreach (FlowLayoutPanel item in BubblePlaceHolder.Controls)
            {
                item.Visible = false;
                if (item.Name.Contains(name))
                    item.Visible = true;
            }
        }

        private static void ResetMessageCount(string name)
        {
            foreach (Control item in ConversationFLP.Controls)
            {
                if (item.Name.Contains(name))
                {
                    foreach (Control control in item.Controls)
                    {
                        if (control.GetType().Equals(typeof(RoundButton)))
                        {

                            control.Visible = false;
                            control.Text = "1";
                        }
                    }

                }
            }
        }

        internal static void SetConversationPlaceHolder(string name)
        {
            if (!BubblePlaceHolder.Controls.ContainsKey(name))
            {

                var FlowBox = new FlowLayoutPanel()
                {
                    Name = name,
                    BorderStyle = BorderStyle.FixedSingle,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    AutoScroll = true,
                    Enabled = true,
                    Visible = false
                };

                FlowBox.Resize += FlowBox_Resize;

                FlowBox.ControlAdded += (s, e) =>
                {
                    ((Control)s).Width = FlowBox.ClientSize.Width - 10;

                    if (!FlowBox.Visible)
                    {
                        SoundPlayer splayer = new SoundPlayer(@"notification.wav");
                        splayer.Play();
                        if (!ActiveForm.Focused)
                            FlashWindow(ActiveForm.Handle, true);
                    }
                };

                FlowBox.Dock = DockStyle.Fill;
                FlowBox.HorizontalScroll.Maximum = 0;
                FlowBox.HorizontalScroll.Visible = false;
                FlowBox.VerticalScroll.Visible = true;
                FlowBox.Refresh();

                BubblePlaceHolder.Controls.Add(FlowBox);
            }
        }

        private void NotificationsFLP_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (((FlowLayoutPanel)sender).Controls.Count == 0)
            {
                NBall.Visible = false;
                NotificationsDropDownBtn.BackColor = Color.Transparent;
                NPanel.Visible = false;
            }
        }

        private void NotificationsFLP_ControlAdded(object sender, ControlEventArgs e)
        {
            if (((FlowLayoutPanel)sender).Controls.Count > 0)
            {
                NBall.Visible = true;
            }
        }

        private static void FlowBox_Resize(object sender, EventArgs e)
        {
            ResizeFlowBox(sender);
        }

        private static void ResizeFlowBox(object sender)
        {
            foreach (Control panel in ((FlowLayoutPanel)sender).Controls)
            {
                if (panel.GetType().Equals(typeof(Panel)))
                {
                    if (!panel.Name.Contains("panel"))
                    {
                        panel.Width = ((Control)sender).ClientSize.Width - 10;

                        foreach (Control subitem in panel.Controls)
                        {
                            if (subitem.GetType().Equals(typeof(Label)))
                            {
                                if (subitem.Parent.Name.Contains("TextBox"))
                                    subitem.Location = new Point(panel.ClientSize.Width - 160, panel.ClientSize.Height - 35);// label hora de envio do texto
                                else
                                    subitem.Location = new Point(panel.ClientSize.Width - 120, panel.ClientSize.Height - 32);//label hora de envio do audio
                            }
                            if (subitem.GetType().Equals(typeof(LeftLabel)))
                            {
                                
                                foreach (Control rtb in panel.Controls)
                                {
                                    if (rtb.GetType().Equals(typeof(RichTextBox)))
                                    {
                                        subitem.Location = new Point(rtb.ClientSize.Width - 45, rtb.ClientSize.Height + 15);
                                        break;
                                    }

                                    else if(rtb.GetType().Equals(typeof(RoundPanel)))
                                    {
                                        subitem.Location = new Point(rtb.ClientSize.Width - 60, subitem.Location.Y);
                                        break;
                                    }
                                        
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void GetContacts()
        {
            if (LoginForm.ServerConnectionState == LoginForm.VConnectionState.Connected)
            {
                var contacts = LoginForm.Server.GetContacts(_MyClient.Id);
                ContactList = new List<Client>();

                if (contacts != null)
                {
                    foreach (var contact in contacts)
                    {
                        var friend = JsonConvert.DeserializeObject<Client>(contact);
                        ContactList.Add(friend);

                        if (!ContactsFLP.Controls.ContainsKey(friend.Name))
                        {
                            ContactsFLP.Controls.Add(ContactComponent.CreateBlock(friend.Name, null));
                        }
                    }
                }
            }
        }

        private void ApplyTheme()
        {
            BackColor = Theme.GetBackColor();
            menuStrip1.BackColor = Theme.GetBackColor();

            foreach (Control control in Controls)
            {
                if (control.GetType().Equals(typeof(RichTextBox)))
                {
                    control.BackColor = Theme.GetBackColor();
                    control.ForeColor = Theme.GetForeColor();
                }

                if (control.GetType().Equals(typeof(Label)))
                {
                    control.ForeColor = Theme.GetForeColor();
                }

                if (control.GetType().Equals(typeof(Panel)))
                {
                    control.ForeColor = Theme.GetBackColor();

                    foreach (var item in ((Panel)control).Controls)
                    {
                        if (item.GetType().Equals(typeof(Label)))
                        {
                            control.ForeColor = Theme.GetForeColor();
                        }
                    }
                }
            }
        }

        private Icon GetHiconForChat()
        {
            // Create a Bitmap object from an image file.
            Bitmap myBitmap = Properties.Resources.VolupiaChat;

            // Get an Hicon for myBitmap.
            IntPtr Hicon = myBitmap.GetHicon();

            // Create a new icon from the handle. 
            Icon newIcon = Icon.FromHandle(Hicon);
            Icon myIcon = newIcon;
            DestroyIcon(newIcon.Handle);
            return myIcon;
        }

        private void NotifyTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            isMinimized = false;
            this.ShowInTaskbar = true;
            this.BringToFront();
            notifyTray.Visible = false;
        }

        internal static void ButtonPic_Click(object sender, EventArgs e, RoundButton buttonPic, string file, TrackBar elapsedBar)
        {
            System.Windows.Forms.Timer audioTimer = new System.Windows.Forms.Timer();
            audioTimer.Interval = 100;
            audioTimer.Tick += (sendere, ee) => AudioTimer_Tick(sender, e, elapsedBar, audioTimer, buttonPic);

            if (waveOut.PlaybackState != PlaybackState.Playing || waveOut == null)
            {
                PlayAudioBubble(file);
                Thread.Sleep(200);
                audioTimer.Start();
            }
            else if (waveOut.PlaybackState == PlaybackState.Playing || waveOut != null)
            {
                waveOut.Pause();
                audioTimer.Stop();
            }
            else if (file != nowPlaying)
            {
                waveOut.Dispose();
                audioTimer.Stop();
                PlayAudioBubble(file);
                Thread.Sleep(200);
                audioTimer.Start();
            }

        }

        private static void AudioTimer_Tick(object sender, EventArgs e, TrackBar elapsedBar, System.Windows.Forms.Timer audioTimer, RoundButton buttonPic)
        {
            if (waveOut.PlaybackState == PlaybackState.Playing)
            {
                buttonPic.BackgroundImage = Properties.Resources.pause1;
                elapsedBar.Value = (int)rdr.CurrentTime.TotalSeconds * 100;
            }
            else
            {
                buttonPic.BackgroundImage = Properties.Resources.play2;
                elapsedBar.Value = 0;
                audioTimer.Stop();
            }

        }
        #endregion

        private bool IsFormFocused()
        {
            if (this.textRTB.Focused || this.Focused || DisplayRTBtext.Focused || MicRBtn.Focused || this.SendRButton.Focused || UserListBox.Focused)
                return true;
            else
                return false;
        }

        internal static void PlayAudioBubble(string file)
        {
            rdr = new WaveFileReader(file);
            waveOut = new WaveOut();
            waveOut.Init(rdr);
            waveOut.Play();
            nowPlaying = file;
        }

        public static void TakeMessage(string message, string userName)
        {
            if (userName != string.Empty || message != string.Empty)
            {
                if (userName != _MyClient.Name)
                {
                    GetConversation(userName, message);
                    SetConversationPlaceHolder(userName);
                    var lbubble = new BubbleComponent();
                    var control = lbubble.CreateLeftTextBubble(message, userName);
                    foreach (Control item in BubblePlaceHolder.Controls)
                    {
                        if (item.Name.Contains(userName))
                        {
                            item.Controls.Add(control);
                        }
                    }
                }
                else
                {

                    GetConversation(TalkingTolbl.Text, message);
                    SetConversationPlaceHolder(TalkingTolbl.Text);
                    var rbubble = new BubbleComponent();
                    var newControl = rbubble.CreateRightTextBubble(message, userName);
                    foreach (Control item in BubblePlaceHolder.Controls)
                    {
                        if (item.Name.Contains(TalkingTolbl.Text))
                        {
                            item.Controls.Add(newControl);
                        }
                    }

                }

                notifyTray.BalloonTipText = userName + ": " + message;

                if (ActiveForm.WindowState == FormWindowState.Minimized)
                {
                    notifyTray.ShowBalloonTip(3000);
                }
            }
        }

        private static void GetConversation(string userName, string message)
        {
            if (!ConversationFLP.Controls.ContainsKey(userName))
            {
                ConversationFLP.Controls.Add(ConversationComponent.CreateBlock(userName, message, DateTime.Now.ToString("HH:mm")));
            }
            else
            {
                foreach (var item in ConversationFLP.Controls)
                {
                    if (((Panel)item).Name.Contains(userName))
                    {
                        foreach (Control control in ((Panel)item).Controls)
                        {
                            if (control.GetType().Equals(typeof(Label)))
                            {
                                if (control.Name.Contains("text"))
                                {
                                    control.Text = message;
                                }
                                if (control.Name.Contains("time"))
                                {
                                    control.Text = DateTime.Now.ToString("HH:mm");
                                }
                            }
                            if (control.GetType().Equals(typeof(RoundButton)))
                            {
                                int count = 0;
                                if (control.Text != string.Empty)
                                {
                                    count = Convert.ToInt16(control.Text);
                                }
                                count++;
                                if (TalkingTolbl.Text == userName)
                                    control.Visible = false;
                                control.Text = count.ToString();
                            }
                        }
                    }
                }
            }
        }

        public static void TakeInvites()
        {
            var jsonList = LoginForm.Server.GetInvited(_MyClient.Id);

            if (jsonList != null)
            {
                foreach (var json in jsonList)
                {
                    var invite = JsonConvert.DeserializeObject<Friend>(json);//Deserializa json para classe friend para pegar o id do invite
                    var person = JsonConvert.DeserializeObject<Client>(LoginForm.Server.FindById(invite.UserId)); //Deserializa json para classe client para pegar o nome pelo friendid no invite
                    if (!NotificationsFLP.Controls.ContainsKey(person.Name))
                    {
                        NotificationsFLP.Controls.Add(NotificationComponent.CreateBlock(person.Name, invite.Id));
                    }
                }
            }
        }

        public static void TakeAudioMessage(MemoryStream ms, string userName, string meta)
        {
            notifyTray.BalloonTipText = userName + ": Enviou um áudio...";
            var message = "Enviou um áudio...";
            string audioFilePath = GenerateAudioFile(ms, userName, meta);

            if (userName != _MyClient.Name)
            {
                GetConversation(userName, message);
                SetConversationPlaceHolder(userName);
                var lbubble = new BubbleComponent();
                lbubble.AudioFile = audioFilePath;
                var control = lbubble.CreateLeftAudioBubble(message, userName);
                foreach (Control item in BubblePlaceHolder.Controls)
                {
                    if (item.Name.Contains(userName))
                    {
                        item.Controls.Add(control);
                    }
                }
            }
        }

        private static string GenerateAudioFile(MemoryStream ms, string userName, string meta)
        {
            string path = Path.GetPathRoot(Environment.SystemDirectory) + "\\Users\\" + Environment.UserName + "\\AppData\\Local\\Temp\\VolupiaMessenger";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string file = path + @"\" + userName + meta + ".wav";

            ms.Seek(0, SeekOrigin.Begin);
            FileStream fs = File.Create(file);
            byte[] buf = new byte[(int)3e+8];
            int len = 0;
            while ((len = ms.Read(buf, 0, (int)3e+8)) > 0)
            {
                fs.Write(buf, 0, len);
            }
            fs.Close();
            return file;
        }

        private static void PlayAudioFromBytes(byte[] bytes)
        {
            IWaveProvider provider = new RawSourceWaveStream(
                         new MemoryStream(bytes), new WaveFormat(48000, 16, 1));
            waveOut = new WaveOut()
            {
                DesiredLatency = 60
            };
            waveOut.Init(provider);
            waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
            waveOut.Play();
        }

        private static void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            //waveStream.Dispose();
            waveOut.Dispose();
        }

        private void WaveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            audioAnterior = audioAtual;
            fileCount++;
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        private void BtnSendAudio_MouseDown(object sender, MouseEventArgs e)
        {
            SoundPlayer splayer = new SoundPlayer(@"Cap.wav");
            splayer.Play();

            if (!isRecording)
                downTime.Start();

            isRecording = true;
            RecordingLbl.Visible = true;
            waveIn = new WaveIn(this.Handle);
            int rate = 44100;
            int blockAlign = (ushort)(2 * (16 / 8));
            int avgBytesPerSec = rate * blockAlign;
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.RecordingStopped += WaveIn_RecordingStopped;
            waveIn.WaveFormat = new WaveFormat(rate, 1);
            waveIn.BufferMilliseconds = 100;
            audioAtual = DateTime.Now.ToString("ddMMyyyy#HHmmssfff");

            string path = Path.GetPathRoot(Environment.SystemDirectory) + "\\Users\\" + Environment.UserName + "\\AppData\\Local\\Temp\\VolupiaMessenger";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            waveFile = new WaveFileWriter(path + @"\" + _MyClient.Username + audioAtual + ".wav", waveIn.WaveFormat);

            waveIn.StartRecording();
        }

        private void DownTime_Tick(object sender, EventArgs e)
        {
            downCount++;
            AudioTimeCount.Add(TimeSpan.FromSeconds(downCount));
            RecordingLbl.Text = "Gravando... " + AudioTimeCount.Hours + ":" + AudioTimeCount.Minutes + ":" + AudioTimeCount.Seconds;
        }

        private void BtnSendAudio_MouseUp(object sender, MouseEventArgs e)
        {
            waveIn.StopRecording();
            waveIn.Dispose();
            waveFile.Dispose();
            RecordingLbl.Visible = false;
            timer2.Interval = 1000;
            downTime.Stop();
            isRecording = false;

            if (downCount > 1)
            {
                timer2.Start();
            }
            else
            {
                SoundPlayer splayer = new SoundPlayer(@"Release.wav");
                splayer.Play();
                waveFile.Dispose();
            }
            downCount = 0;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            string path = Path.GetPathRoot(Environment.SystemDirectory) + "\\Users\\" + Environment.UserName + "\\AppData\\Local\\Temp\\VolupiaMessenger";
            string file = path + @"\" + _MyClient.Username + audioAtual + ".wav";

            var ms = new MemoryStream(File.ReadAllBytes(file));

            GetConversation(TalkingTolbl.Text, "Enviou um áudio...");
            SetConversationPlaceHolder(TalkingTolbl.Text);
            var rbubble = new BubbleComponent();
            rbubble.AudioFile = file;
            var newControl = rbubble.CreateRightAudioBubble(null, null);
            foreach (Control item in BubblePlaceHolder.Controls)
            {
                if (item.Name.Contains(TalkingTolbl.Text))
                {
                    item.Controls.Add(newControl);
                }
            }

            if (LoginForm.ServerConnectionState == LoginForm.VConnectionState.Connected)
            {
                Thread tt = new Thread(t => SendAudioThread(ms));
                tt.Start();
            }

            waveFile.Dispose();
        }

        private void SendAudioThread(MemoryStream ms)
        {
            try
            {
                LoginForm.Server.SendAudioMessageToUser(ms, _MyClient.Name, TalkingTolbl.Text, audioAtual);
            }
            catch (Exception)
            {
                LoginForm.ServerConnectionState = LoginForm.VConnectionState.Faulted;
            }
        }

        private void NotifyTray_BalloonTipClicked(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            isMinimized = false;
            this.ShowInTaskbar = true;
            this.BringToFront();
            notifyTray.Visible = false;
        }

        public static void AddUserToList(string userName)
        {
            if (UserListBox.Items.Contains(userName))
                return;
            UserListBox.Items.Add(userName);
        }

        public static void RemoveUserFromList(string userName)
        {
            if (UserListBox.Items.Contains(userName))
                UserListBox.Items.Remove(userName);
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (LoginForm.ServerConnectionState == LoginForm.VConnectionState.Connected)
                {
                    LoginForm.Server.Logout();
                }
            }
            finally
            {
                Application.Exit();
            }
        }

        private void Chat_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Chat_Load(object sender, EventArgs e)
        {
            LoadUserList(LoginForm.Server.GetCurrentUsers());
        }

        private void LoadUserList(List<string> users)
        {

            foreach (var user in users)
            {
                AddUserToList(user);
            }

        }

        private void EnviarBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textRTB.Text) || textRTB.Text != "Digite aqui...")
            {
                if (LoginForm.ServerConnectionState == LoginForm.VConnectionState.Connected)
                {
                    try
                    {
                        LoginForm.Server.SendMessageToUser(textRTB.Text, TalkingTolbl.Text, _MyClient.Name);
                        TakeMessage(textRTB.Text, _MyClient.Name);

                        textRTB.ResetText();
                        textRTB.Focus();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString(), "Volupia Messenger");
                        if (LoginForm.ServerConnectionState == LoginForm.VConnectionState.Connected)
                        {
                            LoginForm.Server.UserLogWrite(_MyClient.Username, "[Erro em EnviarBtn_Click()]  ->  " + ex.ToString());
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                GetContacts();
            }
            catch (Exception)
            {
                LoginForm.ServerConnectionState = LoginForm.VConnectionState.Faulted;
            }
            finally
            {
                if (LoginForm.ServerConnectionState != LoginForm.VConnectionState.Connected)
                {
                    try//Attempt to reconnect
                    {
                        LoginForm.CreateChannel();
                        LoginForm.Server.Login(_MyClient.Username, _MyClient.Password);
                        //Server = Form1.Server;
                    }
                    catch (CommunicationException)
                    {
                        LoginForm.ServerConnectionState = LoginForm.VConnectionState.Faulted;
                    }

                }
                timer1.Stop();
                timer1.Start();
            }
        }

        private void Chat_Activated(object sender, EventArgs e)
        {
        }

        private void Chat_Deactivate(object sender, EventArgs e)
        {

        }

        private void Chat_Move(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Visible = true;
            this.Show();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textRTB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                EnviarBtn_Click(sender, e);
            }
        }

        void Chat_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                isMinimized = true;
                notifyTray.Visible = true;
                this.ShowInTaskbar = false;
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                isMinimized = false;
                notifyTray.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }


        private void TextPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textRTB_Enter(object sender, EventArgs e)
        {
            if (textRTB.Text.Equals("Digite aqui..."))
                textRTB.Text = "";
        }

        private void textRTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textRTB.Text))
                textRTB.Text = "Digite aqui...";
        }

        private void SelectedRole(Control c)
        {
            foreach (Control control in RolesPanel.Controls)
            {
                control.BackColor = Color.Transparent;
                control.Font = new Font("Tahoma", 16, FontStyle.Regular);

                if (control.Name.Equals(c.Name))
                {
                    control.BackColor = Theme.SetTransparency(127, Color.LightGray);
                    control.Font = new Font("Tahoma", 18, FontStyle.Regular);
                }
            }
        }

        private void ConversationsLbl_MouseEnter(object sender, EventArgs e)
        {
            Theme.HoverLabel((Control)sender);
        }

        private void ConversationsLbl_Click(object sender, EventArgs e)
        {
            SelectedRole((Control)sender);
            ConversationFLP.Visible = true;
            ContactsFLP.Visible = false;
        }

        private void ConversationsLbl_MouseLeave(object sender, EventArgs e)
        {
            Theme.LeaveLabel((Control)sender);
        }

        private void ContactLbl_Click(object sender, EventArgs e)
        {
            SelectedRole((Control)sender);
            ConversationFLP.Visible = false;
            ContactsFLP.Visible = true;
        }

        private void ContactLbl_MouseEnter(object sender, EventArgs e)
        {
            Theme.HoverLabel((Control)sender);
        }

        private void ContactLbl_MouseLeave(object sender, EventArgs e)
        {
            Theme.LeaveLabel((Control)sender);
        }

        private void Chat_SizeChanged(object sender, EventArgs e)
        {
            //ResizeFlowBox(FlowBox);
        }

        private void InviteFriendBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddFriendMenuItem_Click(object sender, EventArgs e)
        {
            InviteForm inviteForm = new InviteForm();
            inviteForm.Show();
        }

        private void NPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            //((Panel)sender).Height = ((Panel)sender).Height + e.Control.Height;
            //((Panel)sender).Width = e.Control.Width;
        }

        private void NPanel_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void NotificationsDropDownBtn_Click(object sender, EventArgs e)
        {
            if (!NPanel.Visible)
            {
                ((ToolStripMenuItem)sender).BackColor = Color.Gray;
                NPanel.Visible = true;
            }
            else
            {
                ((ToolStripMenuItem)sender).BackColor = Theme.GetBackColor();
                NPanel.Visible = false;
            }

        }

        private void NPanel_Leave(object sender, EventArgs e)
        {
            NotificationsDropDownBtn.BackColor = Theme.GetBackColor();
            NPanel.Visible = false;
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            VideoCall callScreen = new VideoCall();
            callScreen.Show();
        }
    }
}
