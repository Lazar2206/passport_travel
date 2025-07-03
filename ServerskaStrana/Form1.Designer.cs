namespace ServerskaStrana
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPokreni = new Button();
            btnZaustavi = new Button();
            dgvKorisnici = new DataGridView();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).BeginInit();
            SuspendLayout();
            // 
            // btnPokreni
            // 
            btnPokreni.Location = new Point(41, 66);
            btnPokreni.Name = "btnPokreni";
            btnPokreni.Size = new Size(94, 29);
            btnPokreni.TabIndex = 0;
            btnPokreni.Text = "Start";
            btnPokreni.UseVisualStyleBackColor = true;
            btnPokreni.Click += btnPokreni_Click;
            // 
            // btnZaustavi
            // 
            btnZaustavi.Location = new Point(236, 66);
            btnZaustavi.Name = "btnZaustavi";
            btnZaustavi.Size = new Size(94, 29);
            btnZaustavi.TabIndex = 1;
            btnZaustavi.Text = "Stop";
            btnZaustavi.UseVisualStyleBackColor = true;
            btnZaustavi.Click += btnZaustavi_Click;
            // 
            // dgvKorisnici
            // 
            dgvKorisnici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKorisnici.Location = new Point(60, 138);
            dgvKorisnici.Name = "dgvKorisnici";
            dgvKorisnici.RowHeadersWidth = 51;
            dgvKorisnici.Size = new Size(300, 188);
            dgvKorisnici.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(41, 384);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogout);
            Controls.Add(dgvKorisnici);
            Controls.Add(btnZaustavi);
            Controls.Add(btnPokreni);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPokreni;
        private Button btnZaustavi;
        private DataGridView dgvKorisnici;
        private Button btnLogout;
    }
}
