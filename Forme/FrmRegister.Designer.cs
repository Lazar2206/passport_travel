namespace Forme
{
    partial class FrmRegister
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
            label1 = new Label();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            txtpasos = new TextBox();
            label4 = new Label();
            txtJMBG = new TextBox();
            label5 = new Label();
            txtPassword = new TextBox();
            label6 = new Label();
            txtUsername = new TextBox();
            label7 = new Label();
            btnRegistruj = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 45);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(156, 42);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(125, 27);
            txtIme.TabIndex = 1;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(156, 94);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(125, 27);
            txtPrezime.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 97);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 2;
            label2.Text = "Prezime:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(156, 147);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 150);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 4;
            label3.Text = "Email:";
            // 
            // txtpasos
            // 
            txtpasos.Location = new Point(156, 346);
            txtpasos.Name = "txtpasos";
            txtpasos.Size = new Size(125, 27);
            txtpasos.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 346);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 6;
            label4.Text = "BrojPasoša: ";
            // 
            // txtJMBG
            // 
            txtJMBG.Location = new Point(156, 299);
            txtJMBG.Name = "txtJMBG";
            txtJMBG.Size = new Size(125, 27);
            txtJMBG.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 299);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 8;
            label5.Text = "JMBG:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(156, 254);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 254);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 10;
            label6.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(156, 194);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(43, 197);
            label7.Name = "label7";
            label7.Size = new Size(82, 20);
            label7.TabIndex = 12;
            label7.Text = "Username: ";
            // 
            // btnRegistruj
            // 
            btnRegistruj.Location = new Point(156, 398);
            btnRegistruj.Name = "btnRegistruj";
            btnRegistruj.Size = new Size(125, 29);
            btnRegistruj.TabIndex = 14;
            btnRegistruj.Text = "Registruj se";
            btnRegistruj.UseVisualStyleBackColor = true;
            btnRegistruj.Click += btnRegistruj_Click;
            // 
            // FrmRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 450);
            Controls.Add(btnRegistruj);
            Controls.Add(txtUsername);
            Controls.Add(label7);
            Controls.Add(txtPassword);
            Controls.Add(label6);
            Controls.Add(txtJMBG);
            Controls.Add(label5);
            Controls.Add(txtpasos);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtPrezime);
            Controls.Add(label2);
            Controls.Add(txtIme);
            Controls.Add(label1);
            Name = "FrmRegister";
            Text = "FrmRegister";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtpasos;
        private Label label4;
        private TextBox txtJMBG;
        private Label label5;
        private TextBox txtPassword;
        private Label label6;
        private TextBox txtUsername;
        private Label label7;
        private Button btnRegistruj;
    }
}