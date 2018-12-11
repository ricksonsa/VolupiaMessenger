using VolupiaChat.Controls;

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
            this.RecordingLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.ContactLbl = new System.Windows.Forms.Label();
            this.UserListPanel = new System.Windows.Forms.Panel();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.NBall = new VolupiaChat.Controls.RoundButton();
            this.RolesPanel = new System.Windows.Forms.Panel();
            this.ConversationsLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFriendMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotificationsDropDownBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.BarPanel = new System.Windows.Forms.Panel();
            this.textRTB = new System.Windows.Forms.RichTextBox();
            this.TextPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MicRBtn = new VolupiaChat.Controls.RoundButton();
            this.SendRButton = new VolupiaChat.Controls.RoundButton();
            this.ThisPanel = new System.Windows.Forms.Panel();
            this.NPanel = new System.Windows.Forms.Panel();
            this.roundButton1 = new VolupiaChat.Controls.RoundButton();
            this.contextMenuStrip1.SuspendLayout();
            this.UserPanel.SuspendLayout();
            this.RolesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.BarPanel.SuspendLayout();
            this.TextPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
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
            // ContactLbl
            // 
            resources.ApplyResources(this.ContactLbl, "ContactLbl");
            this.ContactLbl.ForeColor = System.Drawing.Color.Black;
            this.ContactLbl.Name = "ContactLbl";
            this.ContactLbl.Click += new System.EventHandler(this.ContactLbl_Click);
            this.ContactLbl.MouseEnter += new System.EventHandler(this.ContactLbl_MouseEnter);
            this.ContactLbl.MouseLeave += new System.EventHandler(this.ContactLbl_MouseLeave);
            // 
            // UserListPanel
            // 
            resources.ApplyResources(this.UserListPanel, "UserListPanel");
            this.UserListPanel.BackColor = System.Drawing.Color.Transparent;
            this.UserListPanel.Name = "UserListPanel";
            // 
            // UserPanel
            // 
            resources.ApplyResources(this.UserPanel, "UserPanel");
            this.UserPanel.BackColor = System.Drawing.Color.Transparent;
            this.UserPanel.Controls.Add(this.NBall);
            this.UserPanel.Controls.Add(this.RolesPanel);
            this.UserPanel.Controls.Add(this.UserListPanel);
            this.UserPanel.Controls.Add(this.pictureBox1);
            this.UserPanel.Controls.Add(this.NameLbl);
            this.UserPanel.Controls.Add(this.menuStrip1);
            this.UserPanel.Name = "UserPanel";
            // 
            // NBall
            // 
            this.NBall.BackColor = System.Drawing.Color.Red;
            this.NBall.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.NBall.FlatAppearance.BorderSize = 0;
            this.NBall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.NBall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.NBall, "NBall");
            this.NBall.Name = "NBall";
            this.NBall.TabStop = false;
            this.NBall.UseVisualStyleBackColor = false;
            // 
            // RolesPanel
            // 
            this.RolesPanel.Controls.Add(this.ContactLbl);
            this.RolesPanel.Controls.Add(this.ConversationsLbl);
            resources.ApplyResources(this.RolesPanel, "RolesPanel");
            this.RolesPanel.Name = "RolesPanel";
            // 
            // ConversationsLbl
            // 
            resources.ApplyResources(this.ConversationsLbl, "ConversationsLbl");
            this.ConversationsLbl.ForeColor = System.Drawing.Color.Black;
            this.ConversationsLbl.Name = "ConversationsLbl";
            this.ConversationsLbl.Click += new System.EventHandler(this.ConversationsLbl_Click);
            this.ConversationsLbl.MouseEnter += new System.EventHandler(this.ConversationsLbl_MouseEnter);
            this.ConversationsLbl.MouseLeave += new System.EventHandler(this.ConversationsLbl_MouseLeave);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuButton,
            this.NotificationsDropDownBtn});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // MenuButton
            // 
            resources.ApplyResources(this.MenuButton, "MenuButton");
            this.MenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFriendMenuItem});
            this.MenuButton.Image = global::VolupiaChat.Properties.Resources.menu;
            this.MenuButton.Name = "MenuButton";
            // 
            // AddFriendMenuItem
            // 
            this.AddFriendMenuItem.Name = "AddFriendMenuItem";
            resources.ApplyResources(this.AddFriendMenuItem, "AddFriendMenuItem");
            this.AddFriendMenuItem.Click += new System.EventHandler(this.AddFriendMenuItem_Click);
            // 
            // NotificationsDropDownBtn
            // 
            this.NotificationsDropDownBtn.BackgroundImage = global::VolupiaChat.Properties.Resources.bell;
            resources.ApplyResources(this.NotificationsDropDownBtn, "NotificationsDropDownBtn");
            this.NotificationsDropDownBtn.Image = global::VolupiaChat.Properties.Resources.bell;
            this.NotificationsDropDownBtn.Name = "NotificationsDropDownBtn";
            this.NotificationsDropDownBtn.Click += new System.EventHandler(this.NotificationsDropDownBtn_Click);
            // 
            // BarPanel
            // 
            resources.ApplyResources(this.BarPanel, "BarPanel");
            this.BarPanel.BackColor = System.Drawing.Color.White;
            this.BarPanel.Controls.Add(this.textRTB);
            this.BarPanel.Name = "BarPanel";
            // 
            // textRTB
            // 
            resources.ApplyResources(this.textRTB, "textRTB");
            this.textRTB.BackColor = System.Drawing.Color.White;
            this.textRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textRTB.DetectUrls = false;
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
            this.TextPanel.BackColor = System.Drawing.Color.Transparent;
            this.TextPanel.Controls.Add(this.BarPanel);
            this.TextPanel.Name = "TextPanel";
            this.TextPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TextPanel_Paint);
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.MicRBtn);
            this.panel3.Controls.Add(this.SendRButton);
            this.panel3.Name = "panel3";
            // 
            // MicRBtn
            // 
            this.MicRBtn.BackColor = System.Drawing.Color.Lavender;
            this.MicRBtn.BackgroundImage = global::VolupiaChat.Properties.Resources.microphone;
            resources.ApplyResources(this.MicRBtn, "MicRBtn");
            this.MicRBtn.Name = "MicRBtn";
            this.MicRBtn.UseVisualStyleBackColor = false;
            this.MicRBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnSendAudio_MouseDown);
            this.MicRBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnSendAudio_MouseUp);
            // 
            // SendRButton
            // 
            this.SendRButton.BackColor = System.Drawing.Color.Transparent;
            this.SendRButton.BackgroundImage = global::VolupiaChat.Properties.Resources.send;
            resources.ApplyResources(this.SendRButton, "SendRButton");
            this.SendRButton.Name = "SendRButton";
            this.SendRButton.UseVisualStyleBackColor = false;
            this.SendRButton.Click += new System.EventHandler(this.EnviarBtn_Click);
            // 
            // ThisPanel
            // 
            resources.ApplyResources(this.ThisPanel, "ThisPanel");
            this.ThisPanel.BackColor = System.Drawing.Color.Transparent;
            this.ThisPanel.Name = "ThisPanel";
            // 
            // NPanel
            // 
            resources.ApplyResources(this.NPanel, "NPanel");
            this.NPanel.BackColor = System.Drawing.Color.Transparent;
            this.NPanel.Name = "NPanel";
            this.NPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.NPanel_ControlAdded);
            this.NPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.NPanel_ControlRemoved);
            this.NPanel.Leave += new System.EventHandler(this.NPanel_Leave);
            // 
            // roundButton1
            // 
            resources.ApplyResources(this.roundButton1, "roundButton1");
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.UseVisualStyleBackColor = true;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // Chat
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.NPanel);
            this.Controls.Add(this.RecordingLbl);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ThisPanel);
            this.Controls.Add(this.TextPanel);
            this.Controls.Add(this.UserPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Chat";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Activated += new System.EventHandler(this.Chat_Activated);
            this.Deactivate += new System.EventHandler(this.Chat_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
            this.Load += new System.EventHandler(this.Chat_Load);
            this.SizeChanged += new System.EventHandler(this.Chat_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Chat_KeyDown);
            this.Move += new System.EventHandler(this.Chat_Move);
            this.Resize += new System.EventHandler(this.Chat_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            this.RolesPanel.ResumeLayout(false);
            this.RolesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.BarPanel.ResumeLayout(false);
            this.TextPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ContactLbl;
        private System.Windows.Forms.Panel UserListPanel;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.Label RecordingLbl;
        private System.Windows.Forms.Panel BarPanel;
        private System.Windows.Forms.RichTextBox textRTB;
        private System.Windows.Forms.Panel TextPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel ThisPanel;
        private Controls.RoundButton MicRBtn;
        private Controls.RoundButton SendRButton;
        private System.Windows.Forms.Label ConversationsLbl;
        private System.Windows.Forms.Panel RolesPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuButton;
        private System.Windows.Forms.ToolStripMenuItem AddFriendMenuItem;
        private System.Windows.Forms.Panel NPanel;
        private System.Windows.Forms.ToolStripMenuItem NotificationsDropDownBtn;
        private RoundButton NBall;
        private RoundButton roundButton1;
    }
}