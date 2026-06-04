namespace ShoesProject
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            panelMain = new Panel();
            txtPassword = new TextBox();
            txtLogin = new TextBox();
            btnGuest = new Button();
            lbPassword = new Label();
            lbLogin = new Label();
            btnLogin = new Button();
            pbLogo = new PictureBox();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(txtPassword);
            panelMain.Controls.Add(txtLogin);
            panelMain.Controls.Add(btnGuest);
            panelMain.Controls.Add(lbPassword);
            panelMain.Controls.Add(lbLogin);
            panelMain.Controls.Add(btnLogin);
            panelMain.Location = new Point(22, 120);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(350, 229);
            panelMain.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(65, 101);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(218, 26);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(65, 44);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(218, 26);
            txtLogin.TabIndex = 4;
            // 
            // btnGuest
            // 
            btnGuest.BackColor = Color.LawnGreen;
            btnGuest.FlatAppearance.BorderSize = 0;
            btnGuest.FlatStyle = FlatStyle.Flat;
            btnGuest.Font = new Font("Times New Roman", 14.25F);
            btnGuest.Location = new Point(98, 186);
            btnGuest.Name = "btnGuest";
            btnGuest.Size = new Size(150, 34);
            btnGuest.TabIndex = 3;
            btnGuest.Text = "Войти как гость";
            btnGuest.UseVisualStyleBackColor = false;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(137, 79);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(58, 19);
            lbPassword.TabIndex = 2;
            lbPassword.Text = "Пароль";
            // 
            // lbLogin
            // 
            lbLogin.AutoSize = true;
            lbLogin.Location = new Point(137, 16);
            lbLogin.Name = "lbLogin";
            lbLogin.Size = new Size(52, 19);
            lbLogin.TabIndex = 1;
            lbLogin.Text = "Логин";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightGreen;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Times New Roman", 14.25F);
            btnLogin.Location = new Point(98, 143);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 34);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.None;
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(144, 12);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(100, 100);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 2;
            pbLogo.TabStop = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 361);
            Controls.Add(pbLogo);
            Controls.Add(panelMain);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход в систему";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panelMain;
        private TextBox txtPassword;
        private TextBox txtLogin;
        private Button btnGuest;
        private Label lbPassword;
        private Label lbLogin;
        private Button btnLogin;
        private PictureBox pbLogo;
    }
}