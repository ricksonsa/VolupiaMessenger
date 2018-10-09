namespace VolupiaChat
{
    partial class Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.RecordingLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UserListPanel = new System.Windows.Forms.Panel();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.BarPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textRTB = new System.Windows.Forms.RichTextBox();
            this.TextPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.EnviarBtn = new System.Windows.Forms.Button();
            this.BtnSendAudio = new System.Windows.Forms.Button();
            this.eDisplayFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ThisPanel = new System.Windows.Forms.Panel();
            this.SendAudioPicBox = new System.Windows.Forms.PictureBox();
            this.SendPicBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            this.UserPanel.SuspendLayout();
            this.BarPanel.SuspendLayout();
            this.TextPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SendAudioPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            resources.ApplyResources(this.abrirToolStripMenuItem, "abrirToolStripMenuItem");
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            resources.ApplyResources(this.fecharToolStripMenuItem, "fecharToolStripMenuItem");
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // DisplayPanel
            // 
            resources.ApplyResources(this.DisplayPanel, "DisplayPanel");
            this.DisplayPanel.BackColor = System.Drawing.Color.Azure;
            this.DisplayPanel.Name = "DisplayPanel";
            // 
            // RecordingLbl
            // 
            resources.ApplyResources(this.RecordingLbl, "RecordingLbl");
            this.RecordingLbl.BackColor = System.Drawing.Color.Transparent;
            this.RecordingLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.RecordingLbl.Name = "RecordingLbl";
            // 
            // NameLbl
            // 
            resources.ApplyResources(this.NameLbl, "NameLbl");
            this.NameLbl.ForeColor = System.Drawing.Color.Black;
            this.NameLbl.Name = "NameLbl";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // UserListPanel
            // 
            this.UserListPanel.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.UserListPanel, "UserListPanel");
            this.UserListPanel.Name = "UserListPanel";
            // 
            // UserPanel
            // 
            resources.ApplyResources(this.UserPanel, "UserPanel");
            this.UserPanel.BackColor = System.Drawing.Color.Azure;
            this.UserPanel.Controls.Add(this.UserListPanel);
            this.UserPanel.Controls.Add(this.label1);
            this.UserPanel.Controls.Add(this.pictureBox1);
            this.UserPanel.Controls.Add(this.NameLbl);
            this.UserPanel.Name = "UserPanel";
            // 
            // BarPanel
            // 
            this.BarPanel.Controls.Add(this.panel2);
            this.BarPanel.Controls.Add(this.textRTB);
            resources.ApplyResources(this.BarPanel, "BarPanel");
            this.BarPanel.Name = "BarPanel";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // textRTB
            // 
            this.textRTB.BackColor = System.Drawing.Color.Azure;
            this.textRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textRTB.DetectUrls = false;
            resources.ApplyResources(this.textRTB, "textRTB");
            this.textRTB.ForeColor = System.Drawing.Color.Black;
            this.textRTB.Name = "textRTB";
            this.textRTB.TabStop = false;
            this.textRTB.Enter += new System.EventHandler(this.textRTB_Enter);
            this.textRTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Chat_KeyDown);
            this.textRTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textRTB_KeyUp);
            this.textRTB.Leave += new System.EventHandler(this.textRTB_Leave);
            // 
            // TextPanel
            // 
            resources.ApplyResources(this.TextPanel, "TextPanel");
            this.TextPanel.Controls.Add(this.panel1);
            this.TextPanel.Controls.Add(this.BarPanel);
            this.TextPanel.Name = "TextPanel";
            this.TextPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TextPanel_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SendAudioPicBox);
            this.panel3.Controls.Add(this.SendPicBox);
            this.panel3.Controls.Add(this.EnviarBtn);
            this.panel3.Controls.Add(this.BtnSendAudio);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // EnviarBtn
            // 
            resources.ApplyResources(this.EnviarBtn, "EnviarBtn");
            this.EnviarBtn.Name = "EnviarBtn";
            this.EnviarBtn.UseVisualStyleBackColor = true;
            this.EnviarBtn.Click += new System.EventHandler(this.EnviarBtn_Click);
            // 
            // BtnSendAudio
            // 
            resources.ApplyResources(this.BtnSendAudio, "BtnSendAudio");
            this.BtnSendAudio.Name = "BtnSendAudio";
            this.BtnSendAudio.UseVisualStyleBackColor = true;
            this.BtnSendAudio.Click += new System.EventHandler(this.BtnSendAudio_Click);
            this.BtnSendAudio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnSendAudio_MouseDown);
            this.BtnSendAudio.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnSendAudio_MouseUp);
            // 
            // eDisplayFlowPanel
            // 
            resources.ApplyResources(this.eDisplayFlowPanel, "eDisplayFlowPanel");
            this.eDisplayFlowPanel.Name = "eDisplayFlowPanel";
            // 
            // ThisPanel
            // 
            resources.ApplyResources(this.ThisPanel, "ThisPanel");
            this.ThisPanel.Name = "ThisPanel";
            // 
            // SendAudioPicBox
            // 
            this.SendAudioPicBox.BackgroundImage = global::VolupiaChat.Properties.Resources.microphone;
            resources.ApplyResources(this.SendAudioPicBox, "SendAudioPicBox");
            this.SendAudioPicBox.Name = "SendAudioPicBox";
            this.SendAudioPicBox.TabStop = false;
            this.SendAudioPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnSendAudio_MouseDown);
            this.SendAudioPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnSendAudio_MouseUp);
            // 
            // SendPicBox
            // 
            this.SendPicBox.BackgroundImage = global::VolupiaChat.Properties.Resources.send;
            resources.ApplyResources(this.SendPicBox, "SendPicBox");
            this.SendPicBox.Name = "SendPicBox";
            this.SendPicBox.TabStop = false;
            this.SendPicBox.Click += new System.EventHandler(this.EnviarBtn_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Chat
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.ThisPanel);
            this.Controls.Add(this.eDisplayFlowPanel);
            this.Controls.Add(this.RecordingLbl);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.TextPanel);
            this.Controls.Add(this.UserPanel);
            this.Name = "Chat";
            this.Opacity = 0.95D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Activated += new System.EventHandler(this.Chat_Activated);
            this.Deactivate += new System.EventHandler(this.Chat_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
            this.Load += new System.EventHandler(this.Chat_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Chat_KeyDown);
            this.Move += new System.EventHandler(this.Chat_Move);
            this.Resize += new System.EventHandler(this.Chat_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            this.BarPanel.ResumeLayout(false);
            this.TextPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SendAudioPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox UsersListBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel UserListPanel;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.Label RecordingLbl;
        private System.Windows.Forms.Button BtnSendAudio;
        private System.Windows.Forms.Button EnviarBtn;
        private System.Windows.Forms.Panel BarPanel;
        private System.Windows.Forms.RichTextBox textRTB;
        private System.Windows.Forms.Panel TextPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox SendPicBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox SendAudioPicBox;
        private System.Windows.Forms.FlowLayoutPanel DisplayFlowPanel;
        private System.Windows.Forms.FlowLayoutPanel eDisplayFlowPanel;
        private System.Windows.Forms.Panel ThisPanel;
    }
}