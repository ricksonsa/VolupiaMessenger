namespace VolupiaChat
{
    partial class InviteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InviteForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.UsersLbl = new System.Windows.Forms.Label();
            this.IconsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PersonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SearchRtb = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UsersLbl);
            this.panel1.Controls.Add(this.IconsFlowLayoutPanel);
            this.panel1.Controls.Add(this.PersonFlowLayoutPanel);
            this.panel1.Controls.Add(this.SearchPanel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 473);
            this.panel1.TabIndex = 20;
            this.panel1.Click += new System.EventHandler(this.PersonFlowLayoutPanel_Click);
            // 
            // UsersLbl
            // 
            this.UsersLbl.AutoSize = true;
            this.UsersLbl.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersLbl.Location = new System.Drawing.Point(62, 111);
            this.UsersLbl.Name = "UsersLbl";
            this.UsersLbl.Size = new System.Drawing.Size(105, 29);
            this.UsersLbl.TabIndex = 4;
            this.UsersLbl.Text = "Usuários";
            this.UsersLbl.Visible = false;
            // 
            // IconsFlowLayoutPanel
            // 
            this.IconsFlowLayoutPanel.AutoScroll = true;
            this.IconsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.IconsFlowLayoutPanel.Location = new System.Drawing.Point(482, 150);
            this.IconsFlowLayoutPanel.Name = "IconsFlowLayoutPanel";
            this.IconsFlowLayoutPanel.Size = new System.Drawing.Size(68, 299);
            this.IconsFlowLayoutPanel.TabIndex = 3;
            this.IconsFlowLayoutPanel.WrapContents = false;
            // 
            // PersonFlowLayoutPanel
            // 
            this.PersonFlowLayoutPanel.AutoScroll = true;
            this.PersonFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PersonFlowLayoutPanel.Location = new System.Drawing.Point(56, 150);
            this.PersonFlowLayoutPanel.Name = "PersonFlowLayoutPanel";
            this.PersonFlowLayoutPanel.Size = new System.Drawing.Size(423, 299);
            this.PersonFlowLayoutPanel.TabIndex = 2;
            this.PersonFlowLayoutPanel.WrapContents = false;
            this.PersonFlowLayoutPanel.Click += new System.EventHandler(this.PersonFlowLayoutPanel_Click);
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.Color.White;
            this.SearchPanel.Controls.Add(this.pictureBox2);
            this.SearchPanel.Controls.Add(this.SearchRtb);
            this.SearchPanel.Location = new System.Drawing.Point(31, 10);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(548, 82);
            this.SearchPanel.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::VolupiaChat.Properties.Resources.loupe;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(435, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 59);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // SearchRtb
            // 
            this.SearchRtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchRtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchRtb.ForeColor = System.Drawing.Color.LightGray;
            this.SearchRtb.Location = new System.Drawing.Point(58, 20);
            this.SearchRtb.Multiline = false;
            this.SearchRtb.Name = "SearchRtb";
            this.SearchRtb.Size = new System.Drawing.Size(371, 44);
            this.SearchRtb.TabIndex = 0;
            this.SearchRtb.Text = "Buscar...";
            this.SearchRtb.TextChanged += new System.EventHandler(this.SearchRtb_TextChanged);
            this.SearchRtb.Enter += new System.EventHandler(this.SearchRtb_Enter);
            this.SearchRtb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchRtb_KeyPress);
            this.SearchRtb.Leave += new System.EventHandler(this.SearchRtb_Leave);
            // 
            // InviteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 477);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InviteForm";
            this.Text = "Adicionar amigo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.SearchPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel PersonFlowLayoutPanel;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox SearchRtb;
        private System.Windows.Forms.FlowLayoutPanel IconsFlowLayoutPanel;
        private System.Windows.Forms.Label UsersLbl;
    }
}