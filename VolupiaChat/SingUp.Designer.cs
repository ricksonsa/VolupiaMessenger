using VolupiaChat.Controls;

namespace VolupiaChat
{
    partial class SingUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingUp));
            this.BodyPanel = new System.Windows.Forms.Panel();
            this.PanelButton = new System.Windows.Forms.Panel();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.DragPanel = new System.Windows.Forms.Panel();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.CloseX = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.UserNameTextBlock = new System.Windows.Forms.TextBox();
            this.UserNameTB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PasswordTextBlock = new System.Windows.Forms.TextBox();
            this.PassordMTB = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NameTextBlock = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MailTextBlock = new System.Windows.Forms.TextBox();
            this.MailTextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ErrorHasUserLbl = new System.Windows.Forms.Label();
            this.ErrorPassLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.ErrorHasMailLbl = new System.Windows.Forms.Label();
            this.ErrorUserNameLengthLbl = new System.Windows.Forms.Label();
            this.ErrorInvalidEmailLabl = new System.Windows.Forms.Label();
            this.BodyPanel.SuspendLayout();
            this.DragPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BodyPanel
            // 
            this.BodyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BodyPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BodyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BodyPanel.Controls.Add(this.flowLayoutPanel2);
            this.BodyPanel.Controls.Add(this.PanelButton);
            this.BodyPanel.Controls.Add(this.AcceptBtn);
            this.BodyPanel.Controls.Add(this.DragPanel);
            this.BodyPanel.Controls.Add(this.flowLayoutPanel1);
            this.BodyPanel.Location = new System.Drawing.Point(0, 0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(586, 512);
            this.BodyPanel.TabIndex = 0;
            // 
            // PanelButton
            // 
            this.PanelButton.BackColor = System.Drawing.Color.SteelBlue;
            this.PanelButton.BackgroundImage = global::VolupiaChat.Properties.Resources.Concluir;
            this.PanelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelButton.Location = new System.Drawing.Point(209, 427);
            this.PanelButton.Name = "PanelButton";
            this.PanelButton.Size = new System.Drawing.Size(148, 42);
            this.PanelButton.TabIndex = 14;
            this.PanelButton.Click += new System.EventHandler(this.PanelButton_Click);
            this.PanelButton.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelButton_Paint);
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Location = new System.Drawing.Point(241, 427);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(75, 21);
            this.AcceptBtn.TabIndex = 13;
            this.AcceptBtn.Text = "Concluir";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // DragPanel
            // 
            this.DragPanel.Controls.Add(this.TitleLbl);
            this.DragPanel.Controls.Add(this.CloseX);
            this.DragPanel.Location = new System.Drawing.Point(0, 2);
            this.DragPanel.Name = "DragPanel";
            this.DragPanel.Size = new System.Drawing.Size(585, 28);
            this.DragPanel.TabIndex = 8;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.TitleLbl.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.TitleLbl.Location = new System.Drawing.Point(5, 4);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(97, 13);
            this.TitleLbl.TabIndex = 10;
            this.TitleLbl.Text = "Volupia Messenger";
            // 
            // CloseX
            // 
            this.CloseX.AutoSize = true;
            this.CloseX.BackColor = System.Drawing.Color.Transparent;
            this.CloseX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseX.ForeColor = System.Drawing.Color.SteelBlue;
            this.CloseX.Location = new System.Drawing.Point(561, -4);
            this.CloseX.Name = "CloseX";
            this.CloseX.Size = new System.Drawing.Size(20, 24);
            this.CloseX.TabIndex = 4;
            this.CloseX.Text = "x";
            this.CloseX.Click += new System.EventHandler(this.CloseX_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.UserNameTextBlock);
            this.flowLayoutPanel1.Controls.Add(this.UserNameTB);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.PasswordTextBlock);
            this.flowLayoutPanel1.Controls.Add(this.PassordMTB);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.NameTextBlock);
            this.flowLayoutPanel1.Controls.Add(this.NameTextBox);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.MailTextBlock);
            this.flowLayoutPanel1.Controls.Add(this.MailTextBox);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(176, 117);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(220, 322);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // UserNameTextBlock
            // 
            this.UserNameTextBlock.BackColor = System.Drawing.Color.LightSteelBlue;
            this.UserNameTextBlock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserNameTextBlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserNameTextBlock.Enabled = false;
            this.UserNameTextBlock.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTextBlock.ForeColor = System.Drawing.Color.Black;
            this.UserNameTextBlock.Location = new System.Drawing.Point(3, 13);
            this.UserNameTextBlock.Name = "UserNameTextBlock";
            this.UserNameTextBlock.ReadOnly = true;
            this.UserNameTextBlock.Size = new System.Drawing.Size(217, 22);
            this.UserNameTextBlock.TabIndex = 0;
            this.UserNameTextBlock.Text = "Login";
            this.UserNameTextBlock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserNameTB
            // 
            this.UserNameTB.BackColor = System.Drawing.Color.White;
            this.UserNameTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserNameTB.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTB.ForeColor = System.Drawing.Color.Black;
            this.UserNameTB.Location = new System.Drawing.Point(3, 41);
            this.UserNameTB.Name = "UserNameTB";
            this.UserNameTB.Size = new System.Drawing.Size(217, 21);
            this.UserNameTB.TabIndex = 1;
            this.UserNameTB.TextChanged += new System.EventHandler(this.UserNameTB_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 1);
            this.panel1.TabIndex = 2;
            // 
            // PasswordTextBlock
            // 
            this.PasswordTextBlock.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PasswordTextBlock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTextBlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.PasswordTextBlock.Enabled = false;
            this.PasswordTextBlock.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBlock.ForeColor = System.Drawing.Color.Black;
            this.PasswordTextBlock.Location = new System.Drawing.Point(3, 85);
            this.PasswordTextBlock.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.PasswordTextBlock.Name = "PasswordTextBlock";
            this.PasswordTextBlock.ReadOnly = true;
            this.PasswordTextBlock.Size = new System.Drawing.Size(217, 22);
            this.PasswordTextBlock.TabIndex = 3;
            this.PasswordTextBlock.Text = "Senha";
            this.PasswordTextBlock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PassordMTB
            // 
            this.PassordMTB.BackColor = System.Drawing.Color.White;
            this.PassordMTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PassordMTB.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassordMTB.ForeColor = System.Drawing.Color.Black;
            this.PassordMTB.Location = new System.Drawing.Point(3, 113);
            this.PassordMTB.Name = "PassordMTB";
            this.PassordMTB.PasswordChar = '°';
            this.PassordMTB.Size = new System.Drawing.Size(217, 21);
            this.PassordMTB.TabIndex = 4;
            this.PassordMTB.TextChanged += new System.EventHandler(this.PassordMTB_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 143);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 1);
            this.panel2.TabIndex = 5;
            // 
            // NameTextBlock
            // 
            this.NameTextBlock.BackColor = System.Drawing.Color.LightSteelBlue;
            this.NameTextBlock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameTextBlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameTextBlock.Enabled = false;
            this.NameTextBlock.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBlock.ForeColor = System.Drawing.Color.Black;
            this.NameTextBlock.Location = new System.Drawing.Point(3, 157);
            this.NameTextBlock.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.NameTextBlock.Name = "NameTextBlock";
            this.NameTextBlock.ReadOnly = true;
            this.NameTextBlock.Size = new System.Drawing.Size(217, 22);
            this.NameTextBlock.TabIndex = 6;
            this.NameTextBlock.Text = "Seu Nome";
            this.NameTextBlock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.White;
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameTextBox.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.ForeColor = System.Drawing.Color.Black;
            this.NameTextBox.Location = new System.Drawing.Point(3, 185);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(217, 21);
            this.NameTextBox.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 215);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(212, 1);
            this.panel3.TabIndex = 8;
            // 
            // MailTextBlock
            // 
            this.MailTextBlock.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MailTextBlock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MailTextBlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.MailTextBlock.Enabled = false;
            this.MailTextBlock.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MailTextBlock.ForeColor = System.Drawing.Color.Black;
            this.MailTextBlock.Location = new System.Drawing.Point(3, 229);
            this.MailTextBlock.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.MailTextBlock.Name = "MailTextBlock";
            this.MailTextBlock.ReadOnly = true;
            this.MailTextBlock.Size = new System.Drawing.Size(217, 22);
            this.MailTextBlock.TabIndex = 9;
            this.MailTextBlock.Text = "E-Mail";
            this.MailTextBlock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MailTextBox
            // 
            this.MailTextBox.BackColor = System.Drawing.Color.White;
            this.MailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MailTextBox.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MailTextBox.ForeColor = System.Drawing.Color.Black;
            this.MailTextBox.Location = new System.Drawing.Point(3, 257);
            this.MailTextBox.Name = "MailTextBox";
            this.MailTextBox.Size = new System.Drawing.Size(217, 21);
            this.MailTextBox.TabIndex = 10;
            this.MailTextBox.TextChanged += new System.EventHandler(this.MailTextBox_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 289);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 1);
            this.panel4.TabIndex = 11;
            // 
            // ErrorHasUserLbl
            // 
            this.ErrorHasUserLbl.AutoSize = true;
            this.ErrorHasUserLbl.ForeColor = System.Drawing.Color.Red;
            this.ErrorHasUserLbl.Location = new System.Drawing.Point(3, 0);
            this.ErrorHasUserLbl.Name = "ErrorHasUserLbl";
            this.ErrorHasUserLbl.Size = new System.Drawing.Size(157, 13);
            this.ErrorHasUserLbl.TabIndex = 12;
            this.ErrorHasUserLbl.Text = "*Nome de usuário já foi utilizado";
            this.ErrorHasUserLbl.Visible = false;
            // 
            // ErrorPassLbl
            // 
            this.ErrorPassLbl.AutoSize = true;
            this.ErrorPassLbl.ForeColor = System.Drawing.Color.Red;
            this.ErrorPassLbl.Location = new System.Drawing.Point(3, 13);
            this.ErrorPassLbl.Name = "ErrorPassLbl";
            this.ErrorPassLbl.Size = new System.Drawing.Size(397, 26);
            this.ErrorPassLbl.TabIndex = 12;
            this.ErrorPassLbl.Text = "*A senha deve conter 6 digitos ou mais e não deve conter símbolos ou caracteres e" +
    "speciais";
            this.ErrorPassLbl.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(this.ErrorHasUserLbl);
            this.flowLayoutPanel2.Controls.Add(this.ErrorPassLbl);
            this.flowLayoutPanel2.Controls.Add(this.ErrorHasMailLbl);
            this.flowLayoutPanel2.Controls.Add(this.ErrorUserNameLengthLbl);
            this.flowLayoutPanel2.Controls.Add(this.ErrorInvalidEmailLabl);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(147, 31);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(434, 80);
            this.flowLayoutPanel2.TabIndex = 15;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // ErrorHasMailLbl
            // 
            this.ErrorHasMailLbl.AutoSize = true;
            this.ErrorHasMailLbl.ForeColor = System.Drawing.Color.Red;
            this.ErrorHasMailLbl.Location = new System.Drawing.Point(3, 39);
            this.ErrorHasMailLbl.Name = "ErrorHasMailLbl";
            this.ErrorHasMailLbl.Size = new System.Drawing.Size(162, 13);
            this.ErrorHasMailLbl.TabIndex = 13;
            this.ErrorHasMailLbl.Text = "*O e-mail fornecido já foi utilizado";
            this.ErrorHasMailLbl.Visible = false;
            // 
            // ErrorUserNameLengthLbl
            // 
            this.ErrorUserNameLengthLbl.AutoSize = true;
            this.ErrorUserNameLengthLbl.ForeColor = System.Drawing.Color.Red;
            this.ErrorUserNameLengthLbl.Location = new System.Drawing.Point(3, 52);
            this.ErrorUserNameLengthLbl.Name = "ErrorUserNameLengthLbl";
            this.ErrorUserNameLengthLbl.Size = new System.Drawing.Size(232, 13);
            this.ErrorUserNameLengthLbl.TabIndex = 14;
            this.ErrorUserNameLengthLbl.Text = "*Nome de usuário deve conter 4 digitos ou mais";
            this.ErrorUserNameLengthLbl.Visible = false;
            // 
            // ErrorInvalidEmailLabl
            // 
            this.ErrorInvalidEmailLabl.AutoSize = true;
            this.ErrorInvalidEmailLabl.ForeColor = System.Drawing.Color.Red;
            this.ErrorInvalidEmailLabl.Location = new System.Drawing.Point(3, 65);
            this.ErrorInvalidEmailLabl.Name = "ErrorInvalidEmailLabl";
            this.ErrorInvalidEmailLabl.Size = new System.Drawing.Size(78, 13);
            this.ErrorInvalidEmailLabl.TabIndex = 15;
            this.ErrorInvalidEmailLabl.Text = "*E-mail inválido";
            this.ErrorInvalidEmailLabl.Visible = false;
            // 
            // SingUp
            // 
            this.AcceptButton = this.AcceptBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(587, 511);
            this.ControlBox = false;
            this.Controls.Add(this.BodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SingUp";
            this.Opacity = 0.95D;
            this.Text = "Volupia Messenger";
            this.Load += new System.EventHandler(this.SingUp_Load);
            this.BodyPanel.ResumeLayout(false);
            this.DragPanel.ResumeLayout(false);
            this.DragPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox UserNameTextBlock;
        private System.Windows.Forms.TextBox UserNameTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox PasswordTextBlock;
        private System.Windows.Forms.MaskedTextBox PassordMTB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox NameTextBlock;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox MailTextBlock;
        private System.Windows.Forms.TextBox MailTextBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button AcceptBtn;
        private System.Windows.Forms.Panel DragPanel;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label CloseX;
        private System.Windows.Forms.Panel PanelButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label ErrorHasUserLbl;
        private System.Windows.Forms.Label ErrorPassLbl;
        private System.Windows.Forms.Label ErrorHasMailLbl;
        private System.Windows.Forms.Label ErrorUserNameLengthLbl;
        private System.Windows.Forms.Label ErrorInvalidEmailLabl;
    }
}