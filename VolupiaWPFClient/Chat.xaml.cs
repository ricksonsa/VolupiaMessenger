using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using VolupiaInterfaces;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace VolupiaWPFClient
{
    /// <summary>
    /// Lógica interna para Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool FlashStatus);

        //Variáveis globais
        private string audioAtual = DateTime.Now.ToString("ddMMyyy#HHmmss");
        private string audioAnterior;
        private string myUserName;
        private WaveIn waveIn;
        private WaveFileWriter waveFile;
        private MemoryStream ms;
        public static IVolupiaService Server;
        private NotifyIcon notifyIcon;
        Timer timer2;

        public Chat(string[] MyUser, IVolupiaService server)
        {
            InitializeComponent();

            Server = server;
            myUserName = MyUser[2];

            #region Instanciando Icone Notificação
            notifyIcon = new NotifyIcon()
            {
                BalloonTipTitle = "Volupia Messenger",
                Icon = new Icon(Environment.CurrentDirectory + @"\VolupiaChat.ico"),
                Text =""
            };
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            notifyIcon.BalloonTipClicked += NotifyIcon_BalloonTipClicked;
            #endregion

            timer2 = new Timer()
            {
                Interval = 1000
            };
            timer2.Tick += Timer2_Tick;

            LoadUserList(Server.GetCurrentUsers());
        }

        private void LoadUserList(List<string> list)
        {
            foreach (var user in list)
            {
                AddUserToList(user);
            }
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (System.Windows.Application.Current.MainWindow.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
                this.Activate();
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(System.Windows.Application.Current.MainWindow.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
                this.Activate();              
            }
        }

        public void TakeMessage(string message, string userName)
        {
            if (userName != string.Empty || message != string.Empty)
            {
                string adding = userName + ": " + message;
                ChatDisplayLV.Items.Add(adding);
                ToastNotify(adding);
            }
        }

        public void TakeAudioMessage(MemoryStream ms, string userName)
        {
            string adding = userName + ": Enviou um áudio...";
            ChatDisplayLV.Items.Add(adding);

            if (userName != "Você")
            {
                ms.Seek(0, SeekOrigin.Begin);

                FileStream fs = File.Create(userName + audioAtual + ".wav");
                byte[] buf = new byte[65536];
                int len = 0;
                while ((len = ms.Read(buf, 0, 65536)) > 0)
                {
                    fs.Write(buf, 0, len);
                }
                fs.Close();

                WaveOut waveOut = new WaveOut();
                WaveStream waveStream = new WaveFileReader(userName + audioAtual + ".wav");
                waveOut.Init(waveStream);
                waveOut.Play();

                ToastNotify(adding);
            }
        }

        private void ToastNotify(string text)
        {
            if (!IsActive)
            {             
                SoundPlayer splayer = new SoundPlayer(@"notification.wav");
                splayer.Play();
            }
            if(System.Windows.Application.Current.MainWindow.WindowState == WindowState.Minimized)
            {
                notifyIcon.BalloonTipText = text;
                notifyIcon.ShowBalloonTip(3000);
            }

            else if (!IsActive && System.Windows.Application.Current.MainWindow.WindowState != WindowState.Minimized)
            {
                FlashWindow(Process.GetCurrentProcess().MainWindowHandle, true);               
            }
          
        }

        private void SendTextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextTB.Text))
            {
                try
                {
                    Server.SendMessageToALL(TextTB.Text, myUserName);
                    TakeMessage(TextTB.Text, "Você");
                    TextTB.Clear();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString(), "Error!");
                }
            }
        }

        public void AddUserToList(string userName)
        {
            if (OnlineLB.Items.Contains(userName))
                return;
            OnlineLB.Items.Add(userName);
        }

        public void RemoveUserFromList(string userName)
        {
            if (OnlineLB.Items.Contains(userName))
                OnlineLB.Items.Remove(userName);
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
            else
            {
                this.ShowInTaskbar = true;
                notifyIcon.Visible = false;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Server.Logout();
        }

        private void SendAudioBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            waveIn = new WaveIn();
            int rate = 44100;
            int blockAlign = (ushort)(2 * (16 / 8));
            int avgBytesPerSec = rate * blockAlign;
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.RecordingStopped += WaveIn_RecordingStopped;

            waveIn.WaveFormat = new WaveFormat(rate, 1);
            waveIn.BufferMilliseconds = 1000;
            waveFile = new WaveFileWriter("genericAudioFile" + audioAtual + ".wav", waveIn.WaveFormat);

            waveIn.StartRecording();
        }

        private void WaveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            audioAnterior = audioAtual;

            audioAtual = DateTime.Now.ToString("ddMMyyy#HHmmss");
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                if (e.Buffer.Length >= 64800)
                {
                    SendAudioBtn_MouseLeftButtonUp(sender, null);
                }
                else
                {
                    waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                    waveFile.Flush();
                }            
            }
        }

        private void SendAudioBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            waveIn.StopRecording();
            waveIn.Dispose();
            waveFile.Dispose();
            timer2.Start();//Tempo delay para mandar audio
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            ms = new MemoryStream(File.ReadAllBytes("genericAudioFile" + audioAnterior + ".wav"));

            try
            {
                Server.SendAudioMessageToAll(ms, myUserName);
                TakeAudioMessage(ms, "Você");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message.ToString(), "Error!");
            }
            waveFile.Dispose();
            try
            {
                File.Delete("genericAudioFile" + audioAnterior + ".wav");
            }
            catch (Exception)
            {

            }
            
        }
    }
}
