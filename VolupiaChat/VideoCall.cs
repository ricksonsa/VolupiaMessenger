using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.Live;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolupiaChat
{
    public partial class VideoCall : Form
    {
        LiveJob _job;
        LiveDeviceSource _deviceSource;

        public VideoCall()
        {
            InitializeComponent();
            //StartCam();

            /*
             // Sets up publishing format for file archival type
_job = new LiveJob();

_deviceSource = _job.AddDeviceSource(video, audio);
_job.ActivateSource(_deviceSource);         

// Finds and applys a smooth streaming preset        
_job.ApplyPreset(LivePresets.VC1256kDSL16x9);

// Creates the publishing format for the job
PullBroadcastPublishFormat format = new PullBroadcastPublishFormat();
format.BroadcastPort = 8080;
format.MaximumNumberOfConnections = 2;

// Adds the publishing format to the job
_job.PublishFormats.Add(format);

// Starts encoding
_job.StartEncoding();
             */
        }
        
        private void StartVoice()
        {
            
        }

        private void StartCam()
        {
            var lstVideoDevices = new List<EncoderDevice>();
            var lstAudioDevices = new List<EncoderDevice>();           

            foreach (EncoderDevice edv in EncoderDevices.FindDevices(EncoderDeviceType.Video))
            {
                lstVideoDevices.Add(edv);
                //listBox1.Items.Add(edv.Name);
            }
            foreach (EncoderDevice eda in EncoderDevices.FindDevices(EncoderDeviceType.Audio))
            {
                lstAudioDevices.Add(eda);
                //listBox2.Items.Add(eda.Name);
            }

            var video = lstVideoDevices.FirstOrDefault();
            var audio = lstAudioDevices.FirstOrDefault();

            _job = new LiveJob();

            _deviceSource = _job.AddDeviceSource(video, audio);
            _deviceSource.VideoDevice = video;
            _deviceSource.AudioDevice = audio;

            _deviceSource.PreviewWindow = new PreviewWindow(new HandleRef(this, this.Handle));
            _deviceSource.PreviewWindow.SetSize(Size);

            _job.ActivateSource(_deviceSource);
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            _job.Dispose();
            _deviceSource.Dispose();
            ActiveForm.Close();
        }
    }

    
}
