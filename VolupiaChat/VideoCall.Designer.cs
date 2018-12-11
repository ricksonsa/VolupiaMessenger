namespace VolupiaChat
{
    partial class VideoCall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReceivedVideoPlaceHolder = new System.Windows.Forms.Panel();
            this.SendVideoPlaceHolder = new System.Windows.Forms.Panel();
            this.roundButton1 = new VolupiaChat.Controls.RoundButton();
            this.ReceivedVideoPlaceHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReceivedVideoPlaceHolder
            // 
            this.ReceivedVideoPlaceHolder.Controls.Add(this.SendVideoPlaceHolder);
            this.ReceivedVideoPlaceHolder.Location = new System.Drawing.Point(507, 12);
            this.ReceivedVideoPlaceHolder.Name = "ReceivedVideoPlaceHolder";
            this.ReceivedVideoPlaceHolder.Size = new System.Drawing.Size(218, 399);
            this.ReceivedVideoPlaceHolder.TabIndex = 0;
            this.ReceivedVideoPlaceHolder.Visible = false;
            // 
            // SendVideoPlaceHolder
            // 
            this.SendVideoPlaceHolder.Location = new System.Drawing.Point(429, 244);
            this.SendVideoPlaceHolder.Name = "SendVideoPlaceHolder";
            this.SendVideoPlaceHolder.Size = new System.Drawing.Size(281, 182);
            this.SendVideoPlaceHolder.TabIndex = 1;
            // 
            // roundButton1
            // 
            this.roundButton1.Location = new System.Drawing.Point(319, 417);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(75, 56);
            this.roundButton1.TabIndex = 1;
            this.roundButton1.Text = "roundButton1";
            this.roundButton1.UseVisualStyleBackColor = true;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // VideoCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 482);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.ReceivedVideoPlaceHolder);
            this.Name = "VideoCall";
            this.Text = "VoiceCall";
            this.ReceivedVideoPlaceHolder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ReceivedVideoPlaceHolder;
        private System.Windows.Forms.Panel SendVideoPlaceHolder;
        private Controls.RoundButton roundButton1;
    }
}