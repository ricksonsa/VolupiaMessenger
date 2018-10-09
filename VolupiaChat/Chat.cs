using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Windows.Forms;
using VolupiaInterfaces;
using VolupiaMessenger;
using System.Threading;
using System.IO;
using NAudio;
using NAudio.Wave;
using System.Linq;

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
        private static FlowLayoutPanel FlowBox;

        private static bool isMinimized;

        internal static void SendResponse()
        {
            Form1.Server.GetResponse(myUserName);
        }

        private static string audioAtual;
        private static string audioAnterior;
        private static int fileCount = 0;

        private int downCount;
        private bool isRecording = false;
        private TimeSpan AudioTimeCount;
        private System.Windows.Forms.Timer downTime;
        // Variaveis globais
        public static string myUserName;
        public static string myID;
        private WaveIn waveIn;
        private static WaveOut waveOut = new WaveOut();
        private WaveFileWriter waveFile;
        private static WaveStream waveStream;
        private static WaveFileReader rdr;
        //private MemoryStream ms;

        #region(Chat Screen)
        public Chat(string[] MyUser)
        {
            InitializeComponent();

            textRTB.BackColor = Color.Azure;
            textRTB.ForeColor = Color.Black;

            UserListPanel.Controls.Add(UserListBox);
            UserListBox.Anchor = AnchorStyles.Right;
            UserListBox.BackColor = Color.Azure;
            UserListBox.ForeColor = Color.Black;
            UserListBox.Dock = DockStyle.Fill;
            UserListBox.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Regular);

            DisplayPanel.Controls.Add(DisplayRTBtext);
            DisplayRTBtext.ReadOnly = true;
            DisplayRTBtext.BackColor = Color.Azure;
            DisplayRTBtext.ForeColor = Color.Black;
            DisplayRTBtext.Font = new System.Drawing.Font("Tahoma", 15, FontStyle.Regular);
            DisplayRTBtext.Anchor = AnchorStyles.Bottom;
            DisplayRTBtext.MouseClick += DisplayRTBtext_MouseClick;
            DisplayRTBtext.TextChanged += DisplayRTBtext_TextChanged;
            DisplayRTBtext.Dock = DockStyle.Fill;
            DisplayPanel.Visible = false;
            DisplayRTBtext.Visible = false;

            //FlowBox = eDisplayFlowPanel;
            FlowBox = new FlowLayoutPanel()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Size = eDisplayFlowPanel.Size,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Location = eDisplayFlowPanel.Location,
                Enabled = true,
                Visible = true
            };

            ThisPanel.Controls.Add(FlowBox);

            eDisplayFlowPanel.Visible = false;

            notifyTray.BalloonTipIcon = ToolTipIcon.Info;
            notifyTray.BalloonTipTitle = "Volupia Messenger";
            //notifyTray.Icon = GetHiconForChat();
            notifyTray.Icon = new Icon(Environment.CurrentDirectory + @"\VolupiaChat.ico");
            notifyTray.BalloonTipClicked += NotifyTray_BalloonTipClicked;
            notifyTray.MouseDoubleClick += NotifyTray_MouseDoubleClick;

            downTime = new System.Windows.Forms.Timer
            {
                Interval = 500
            };
            downTime.Tick += DownTime_Tick;

            waveOut.PlaybackStopped += (s, e) =>
            {
                waveOut.Dispose();
                waveStream.Dispose();
            };

            DisplayRTBtext.TextChanged += (s, e) =>
            {
                if (this.WindowState == FormWindowState.Minimized || !IsFormFocused())
                {
                    SoundPlayer splayer = new SoundPlayer(@"notification.wav");
                    splayer.Play();
                    FlashWindow(this.Handle, true);
                }
            };

            myUserName = MyUser[2];
            myID = MyUser[0];
            NameLbl.Text = MyUser[1];
            notifyTray.Text = MyUser[1];
            downCount = 0;
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

        private void DisplayRTBtext_TextChanged(object sender, EventArgs e)
        {
            DisplayRTBtext.Text += '\n';
            DisplayRTBtext.Text += '\n';
        }

        private void DisplayRTBtext_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void NotifyTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            isMinimized = false;
            this.ShowInTaskbar = true;
            this.BringToFront();
            notifyTray.Visible = false;
        }

        internal static void ButtonPic_Click(object sender, EventArgs e, PictureBox buttonPic, string file, TrackBar elapsedBar)
        {
            buttonPic.BackgroundImage = Properties.Resources.TwoButtons;
            System.Windows.Forms.Timer audioTimer = new System.Windows.Forms.Timer();
            audioTimer.Interval = 100;
            audioTimer.Tick += (sendere, ee) => AudioTimer_Tick(sender, e, elapsedBar, audioTimer);
            PlayAudioBubble(file);
            Thread.Sleep(200);
            audioTimer.Start();
        }

        private static void AudioTimer_Tick(object sender, EventArgs e, TrackBar elapsedBar, System.Windows.Forms.Timer audioTimer)
        {
            if (waveOut.PlaybackState == PlaybackState.Playing)
            {
                elapsedBar.Value = (int)rdr.CurrentTime.TotalSeconds * 100;
            }
            else
                audioTimer.Stop();
        }
        #endregion

        private bool IsFormFocused()
        {
            if (this.textRTB.Focused || this.Focused || DisplayRTBtext.Focused || this.EnviarBtn.Focused || UserListBox.Focused)
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
        }

        public static void TakeMessage(string message, string userName)
        {
            if (userName != string.Empty || message != string.Empty)
            {
                Mbubble mbubble = new Mbubble();
                var control = mbubble.CreateRightTextBubble(message, userName);
                FlowBox.Controls.Add(control);
                FlowBox.ScrollControlIntoView(control);

                notifyTray.BalloonTipText = userName + ": " + message;

                if (isMinimized)
                    notifyTray.ShowBalloonTip(3000);
            }
        }

        public static void TakeAudioMessage(MemoryStream ms, string userName, string meta)
        {
            notifyTray.BalloonTipText = userName + ": Enviou um áudio...";

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

            Mbubble bubble = new Mbubble();
            bubble.AudioFile = file;
            var control = bubble.CreateRightAudioBubble(null, myUserName);
            FlowBox.Controls.Add(control);
            FlowBox.ScrollControlIntoView(control);

            if (isMinimized)
                notifyTray.ShowBalloonTip(3000);

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
            waveStream.Dispose();
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

            SendAudioPicBox.BorderStyle = BorderStyle.Fixed3D;

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
            waveFile = new WaveFileWriter(path + @"\" + myUserName + audioAtual + ".wav", waveIn.WaveFormat);

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

            SendAudioPicBox.BorderStyle = BorderStyle.None;

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

            int helper = fileCount - 1;
            string path = Path.GetPathRoot(Environment.SystemDirectory) + "\\Users\\" + Environment.UserName + "\\AppData\\Local\\Temp\\VolupiaMessenger";
            string file = path + @"\" + myUserName + audioAtual + ".wav";

            MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));

            if (Form1.ServerConnectionState == Form1.VConnectionState.Connected)
            {
                Thread tt = new Thread(t => SendAudioThread(ms));
                tt.Start();

                Mbubble bubble = new Mbubble();
                bubble.AudioFile = file;
                var control = bubble.CreateLeftAudioBubble(null, myUserName);
                FlowBox.Controls.Add(control);
                FlowBox.ScrollControlIntoView(control);
            }

            waveFile.Dispose();
        }

        private void SendAudioThread(MemoryStream ms)
        {
            try
            {
                Form1.Server.SendAudioMessageToAll(ms, myUserName, audioAtual);
            }
            catch (Exception)
            {
                Form1.ServerConnectionState = Form1.VConnectionState.Faulted;
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
            if (Form1.ServerConnectionState == Form1.VConnectionState.Connected)
                Form1.Server.Logout();

            Application.Exit();
        }

        private void Chat_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Chat_Load(object sender, EventArgs e)
        {
            LoadUserList(Form1.Server.GetCurrentUsers());
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
                if (Form1.ServerConnectionState == Form1.VConnectionState.Connected)
                {
                    try
                    {
                        Form1.Server.SendMessageToALL(textRTB.Text, myUserName);
                        //TakeMessage(textRTB.Text, "Você");
                        Mbubble mbubble = new Mbubble();
                        FlowBox.Controls.Add(mbubble.CreateLeftTextBubble(textRTB.Text, "Você"));
                        textRTB.ResetText();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Não foi possível enviar a mensagem", "Volupia Messenger");
                        if (Form1.ServerConnectionState == Form1.VConnectionState.Connected)
                        {
                            Form1.Server.UserLogWrite(myUserName, "[Erro em EnviarBtn_Click()]  ->  " + ex.ToString());
                        }
                    }
                }
                else
                {
                    TakeMessage(textRTB.Text, "Você");
                    textRTB.ResetText();
                }

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                LoadUserList(Form1.Server.GetCurrentUsers());
            }
            catch (Exception)
            {
                Form1.ServerConnectionState = Form1.VConnectionState.Faulted;
            }
            finally
            {
                if (Form1.ServerConnectionState != Form1.VConnectionState.Connected)
                {
                    try//Attempt to reconnect
                    {
                        Form1.CreateChannel();
                        Form1.Server.Login(myUserName);
                        //Server = Form1.Server;
                    }
                    catch (CommunicationException)
                    {
                        Form1.ServerConnectionState = Form1.VConnectionState.Faulted;
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

        private void BtnSendAudio_Click(object sender, EventArgs e)
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
    }
}
