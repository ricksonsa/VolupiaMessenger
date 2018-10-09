namespace VolupiaChat.MessageBox
{
    partial class HelloMessage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelloMessage));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MessageLbl = new System.Windows.Forms.Label();
            this.NameRtb = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MessageLbl
            // 
            this.MessageLbl.AutoSize = true;
            this.MessageLbl.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLbl.ForeColor = System.Drawing.Color.DarkCyan;
            this.MessageLbl.Location = new System.Drawing.Point(-25, 4);
            this.MessageLbl.Name = "MessageLbl";
            this.MessageLbl.Size = new System.Drawing.Size(337, 84);
            this.MessageLbl.TabIndex = 0;
            this.MessageLbl.Text = " Bem Vindo!";
            // 
            // NameRtb
            // 
            this.NameRtb.BackColor = System.Drawing.Color.Azure;
            this.NameRtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameRtb.DetectUrls = false;
            this.NameRtb.Font = new System.Drawing.Font("Segoe Print", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameRtb.ForeColor = System.Drawing.Color.DarkCyan;
            this.NameRtb.Location = new System.Drawing.Point(49, 91);
            this.NameRtb.Multiline = false;
            this.NameRtb.Name = "NameRtb";
            this.NameRtb.ReadOnly = true;
            this.NameRtb.Size = new System.Drawing.Size(239, 47);
            this.NameRtb.TabIndex = 0;
            this.NameRtb.Text = "";
            // 
            // HelloMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.NameRtb);
            this.Controls.Add(this.MessageLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelloMessage";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Volupia Hello";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label MessageLbl;
        private System.Windows.Forms.RichTextBox NameRtb;
    }
}