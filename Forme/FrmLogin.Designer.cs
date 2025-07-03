namespace Forme
{
    partial class FrmLogin
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            label2 = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            label3 = new Label();
            btnBezNaloga = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(232, 88);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(232, 141);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(117, 144);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(112, 91);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 3;
            label2.Text = "Username: ";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(169, 223);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(104, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Uloguj se";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(169, 318);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(104, 29);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Registruj se";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(169, 275);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 6;
            label3.Text = "Nemaš nalog?";
            // 
            // btnBezNaloga
            // 
            btnBezNaloga.Location = new Point(169, 376);
            btnBezNaloga.Name = "btnBezNaloga";
            btnBezNaloga.Size = new Size(104, 53);
            btnBezNaloga.TabIndex = 7;
            btnBezNaloga.Text = "Zakaži bez naloga";
            btnBezNaloga.UseVisualStyleBackColor = true;
            btnBezNaloga.Click += btnBezNaloga_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 485);
            Controls.Add(btnBezNaloga);
            Controls.Add(label3);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Name = "FrmLogin";
            Text = "FrmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblPassword;
        private Label label2;
        private Button btnLogin;
        private Button btnRegister;
        private Label label3;
        private Button btnBezNaloga;
    }
}