using VolupiaChat.Controls;

namespace VolupiaChat
{
    partial class LoginForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.ButtonLogin = new System.Windows.Forms.Panel();
            this.LoginRtb = new System.Windows.Forms.RichTextBox();
            this.UserLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseX = new System.Windows.Forms.Label();
            this.ForgetLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passMTextBox = new System.Windows.Forms.MaskedTextBox();
            this.DragPanel = new System.Windows.Forms.Panel();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.RememberUserCB = new System.Windows.Forms.CheckBox();
            this.AutoLoginCB = new System.Windows.Forms.CheckBox();
            this.BorderR = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ConnectingLbl = new System.Windows.Forms.Label();
            this.DragPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.SteelBlue;
            this.ButtonLogin.BackgroundImage = global::VolupiaChat.Properties.Resources.EntrarBtn;
            this.ButtonLogin.Location = new System.Drawing.Point(37, 245);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(173, 42);
            this.ButtonLogin.TabIndex = 6;
            this.ButtonLogin.Click += new System.EventHandler(this.LoginBtn_Click);
            this.ButtonLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonLogin_MouseDown);
            this.ButtonLogin.MouseEnter += new System.EventHandler(this.ButtonLogin_MouseEnter);
            this.ButtonLogin.MouseLeave += new System.EventHandler(this.ButtonLogin_MouseLeave);
            this.ButtonLogin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonLogin_MouseUp);
            // 
            // LoginRtb
            // 
            this.LoginRtb.BackColor = System.Drawing.Color.LightSteelBlue;
            this.LoginRtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginRtb.DetectUrls = false;
            this.LoginRtb.ForeColor = System.Drawing.Color.Black;
            this.LoginRtb.Location = new System.Drawing.Point(37, 118);
            this.LoginRtb.Multiline = false;
            this.LoginRtb.Name = "LoginRtb";
            this.LoginRtb.Size = new System.Drawing.Size(173, 30);
            this.LoginRtb.TabIndex = 2;
            this.LoginRtb.Text = "Email ou Username";
            this.LoginRtb.Enter += new System.EventHandler(this.LoginRtb_Enter);
            // 
            // UserLbl
            // 
            this.UserLbl.AutoSize = true;
            this.UserLbl.BackColor = System.Drawing.Color.Transparent;
            this.UserLbl.Font = new System.Drawing.Font("Segoe Script", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.UserLbl.Location = new System.Drawing.Point(93, 62);
            this.UserLbl.Name = "UserLbl";
            this.UserLbl.Size = new System.Drawing.Size(62, 38);
            this.UserLbl.TabIndex = 0;
            this.UserLbl.Text = "Olá";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(208, -9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "_";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // CloseX
            // 
            this.CloseX.AutoSize = true;
            this.CloseX.BackColor = System.Drawing.Color.Transparent;
            this.CloseX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseX.ForeColor = System.Drawing.Color.SteelBlue;
            this.CloseX.Location = new System.Drawing.Point(232, -3);
            this.CloseX.Name = "CloseX";
            this.CloseX.Size = new System.Drawing.Size(20, 24);
            this.CloseX.TabIndex = 4;
            this.CloseX.Text = "x";
            this.CloseX.Click += new System.EventHandler(this.CloseX_Click);
            this.CloseX.MouseEnter += new System.EventHandler(this.CloseX_MouseEnter);
            this.CloseX.MouseLeave += new System.EventHandler(this.CloseX_MouseLeave);
            // 
            // ForgetLbl
            // 
            this.ForgetLbl.AutoSize = true;
            this.ForgetLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgetLbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.ForgetLbl.Location = new System.Drawing.Point(134, 451);
            this.ForgetLbl.Name = "ForgetLbl";
            this.ForgetLbl.Size = new System.Drawing.Size(108, 13);
            this.ForgetLbl.TabIndex = 4;
            this.ForgetLbl.Text = "Esqueci minha senha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(12, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cadastrar";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // passMTextBox
            // 
            this.passMTextBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.passMTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passMTextBox.ForeColor = System.Drawing.Color.Black;
            this.passMTextBox.Location = new System.Drawing.Point(37, 161);
            this.passMTextBox.Name = "passMTextBox";
            this.passMTextBox.PromptChar = '*';
            this.passMTextBox.Size = new System.Drawing.Size(173, 13);
            this.passMTextBox.TabIndex = 3;
            this.passMTextBox.UseSystemPasswordChar = true;
            this.passMTextBox.TabIndexChanged += new System.EventHandler(this.passMTextBox_TabIndexChanged);
            this.passMTextBox.MouseEnter += new System.EventHandler(this.passMTextBox_MouseEnter);
            // 
            // DragPanel
            // 
            this.DragPanel.BackColor = System.Drawing.Color.Transparent;
            this.DragPanel.Controls.Add(this.TitleLbl);
            this.DragPanel.Controls.Add(this.panel3);
            this.DragPanel.Controls.Add(this.label1);
            this.DragPanel.Controls.Add(this.CloseX);
            this.DragPanel.Location = new System.Drawing.Point(-1, 0);
            this.DragPanel.Name = "DragPanel";
            this.DragPanel.Size = new System.Drawing.Size(250, 45);
            this.DragPanel.TabIndex = 6;
            this.DragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseDown);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.TitleLbl.ForeColor = System.Drawing.Color.Black;
            this.TitleLbl.Location = new System.Drawing.Point(5, 4);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(97, 13);
            this.TitleLbl.TabIndex = 10;
            this.TitleLbl.Text = "Volupia Messenger";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumBlue;
            this.panel3.Location = new System.Drawing.Point(-1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 1);
            this.panel3.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RememberUserCB
            // 
            this.RememberUserCB.AutoSize = true;
            this.RememberUserCB.ForeColor = System.Drawing.Color.Black;
            this.RememberUserCB.Location = new System.Drawing.Point(37, 201);
            this.RememberUserCB.Name = "RememberUserCB";
            this.RememberUserCB.Size = new System.Drawing.Size(81, 17);
            this.RememberUserCB.TabIndex = 4;
            this.RememberUserCB.Text = "Lembrar-me";
            this.RememberUserCB.UseVisualStyleBackColor = true;
            // 
            // AutoLoginCB
            // 
            this.AutoLoginCB.AutoSize = true;
            this.AutoLoginCB.ForeColor = System.Drawing.Color.Black;
            this.AutoLoginCB.Location = new System.Drawing.Point(37, 220);
            this.AutoLoginCB.Name = "AutoLoginCB";
            this.AutoLoginCB.Size = new System.Drawing.Size(138, 17);
            this.AutoLoginCB.TabIndex = 5;
            this.AutoLoginCB.Text = "Entrar automaticamente";
            this.AutoLoginCB.UseVisualStyleBackColor = true;
            // 
            // BorderR
            // 
            this.BorderR.BackColor = System.Drawing.Color.MediumBlue;
            this.BorderR.Location = new System.Drawing.Point(250, 0);
            this.BorderR.Name = "BorderR";
            this.BorderR.Size = new System.Drawing.Size(1, 475);
            this.BorderR.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumBlue;
            this.panel2.Location = new System.Drawing.Point(0, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 475);
            this.panel2.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumBlue;
            this.panel4.Location = new System.Drawing.Point(2, 472);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(249, 1);
            this.panel4.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel5.Location = new System.Drawing.Point(37, 141);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(173, 2);
            this.panel5.TabIndex = 10;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel6.Location = new System.Drawing.Point(37, 179);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(173, 2);
            this.panel6.TabIndex = 10;
            // 
            // ConnectingLbl
            // 
            this.ConnectingLbl.AutoSize = true;
            this.ConnectingLbl.BackColor = System.Drawing.Color.Transparent;
            this.ConnectingLbl.Font = new System.Drawing.Font("Myanmar Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectingLbl.ForeColor = System.Drawing.Color.Black;
            this.ConnectingLbl.Location = new System.Drawing.Point(33, 253);
            this.ConnectingLbl.Name = "ConnectingLbl";
            this.ConnectingLbl.Size = new System.Drawing.Size(179, 27);
            this.ConnectingLbl.TabIndex = 0;
            this.ConnectingLbl.Text = "Conectando ao servidor...";
            this.ConnectingLbl.Visible = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(251, 473);
            this.Controls.Add(this.ConnectingLbl);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BorderR);
            this.Controls.Add(this.AutoLoginCB);
            this.Controls.Add(this.RememberUserCB);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.DragPanel);
            this.Controls.Add(this.passMTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ForgetLbl);
            this.Controls.Add(this.LoginRtb);
            this.Controls.Add(this.UserLbl);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragPanel.ResumeLayout(false);
            this.DragPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel ButtonLogin;
        private System.Windows.Forms.RichTextBox LoginRtb;
        private System.Windows.Forms.Label UserLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CloseX;
        private System.Windows.Forms.Label ForgetLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox passMTextBox;
        private System.Windows.Forms.Panel DragPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox RememberUserCB;
        private System.Windows.Forms.CheckBox AutoLoginCB;
        private System.Windows.Forms.Panel BorderR;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label ConnectingLbl;
    }
}

