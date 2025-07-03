namespace Forme
{
    partial class FrmChangeTrip
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
            cmbPrevoz = new ComboBox();
            dtpDatumDo = new DateTimePicker();
            dtpDatumOd = new DateTimePicker();
            btnSačuvajIzmene = new Button();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label10 = new Label();
            lblKorisnikId = new Label();
            lblPrijavaId = new Label();
            label13 = new Label();
            lblPrezime = new Label();
            lblIme = new Label();
            lblPasos = new Label();
            lblJmbg = new Label();
            SuspendLayout();
            // 
            // cmbPrevoz
            // 
            cmbPrevoz.FormattingEnabled = true;
            cmbPrevoz.Location = new Point(156, 386);
            cmbPrevoz.Name = "cmbPrevoz";
            cmbPrevoz.Size = new Size(125, 28);
            cmbPrevoz.TabIndex = 43;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(156, 253);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(243, 27);
            dtpDatumDo.TabIndex = 42;
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(156, 216);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(243, 27);
            dtpDatumOd.TabIndex = 41;
            // 
            // btnSačuvajIzmene
            // 
            btnSačuvajIzmene.Location = new Point(156, 449);
            btnSačuvajIzmene.Name = "btnSačuvajIzmene";
            btnSačuvajIzmene.Size = new Size(146, 29);
            btnSačuvajIzmene.TabIndex = 38;
            btnSačuvajIzmene.Text = "Sačuvaj izmene";
            btnSačuvajIzmene.UseVisualStyleBackColor = true;
            btnSačuvajIzmene.Click += btnSačuvajIzmene_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(48, 340);
            label9.Name = "label9";
            label9.Size = new Size(89, 20);
            label9.TabIndex = 36;
            label9.Text = "Broj pasoša:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(65, 300);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 34;
            label8.Text = "JMBG:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(48, 253);
            label6.Name = "label6";
            label6.Size = new Size(105, 20);
            label6.TabIndex = 32;
            label6.Text = "Datum izlaska:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 389);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 29;
            label4.Text = "Prevoz:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 216);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 28;
            label3.Text = "Datum ulaska:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 163);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 26;
            label2.Text = "Prezime:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 117);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 24;
            label1.Text = "lme:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(71, 32);
            label10.Name = "label10";
            label10.Size = new Size(77, 20);
            label10.TabIndex = 45;
            label10.Text = "KorisnikId:";
            // 
            // lblKorisnikId
            // 
            lblKorisnikId.AutoSize = true;
            lblKorisnikId.Location = new Point(181, 32);
            lblKorisnikId.Name = "lblKorisnikId";
            lblKorisnikId.Size = new Size(58, 20);
            lblKorisnikId.TabIndex = 46;
            lblKorisnikId.Text = "label11";
            // 
            // lblPrijavaId
            // 
            lblPrijavaId.AutoSize = true;
            lblPrijavaId.Location = new Point(181, 72);
            lblPrijavaId.Name = "lblPrijavaId";
            lblPrijavaId.Size = new Size(58, 20);
            lblPrijavaId.TabIndex = 48;
            lblPrijavaId.Text = "label12";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(71, 72);
            label13.Name = "label13";
            label13.Size = new Size(69, 20);
            label13.TabIndex = 47;
            label13.Text = "PrijavaId:";
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Location = new Point(181, 163);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(58, 20);
            lblPrezime.TabIndex = 50;
            lblPrezime.Text = "label12";
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Location = new Point(181, 117);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(58, 20);
            lblIme.TabIndex = 49;
            lblIme.Text = "label11";
            // 
            // lblPasos
            // 
            lblPasos.AutoSize = true;
            lblPasos.Location = new Point(181, 340);
            lblPasos.Name = "lblPasos";
            lblPasos.Size = new Size(58, 20);
            lblPasos.TabIndex = 52;
            lblPasos.Text = "label12";
            // 
            // lblJmbg
            // 
            lblJmbg.AutoSize = true;
            lblJmbg.Location = new Point(181, 300);
            lblJmbg.Name = "lblJmbg";
            lblJmbg.Size = new Size(58, 20);
            lblJmbg.TabIndex = 51;
            lblJmbg.Text = "label11";
            // 
            // FrmChangeTrip
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 500);
            Controls.Add(lblPasos);
            Controls.Add(lblJmbg);
            Controls.Add(lblPrezime);
            Controls.Add(lblIme);
            Controls.Add(lblPrijavaId);
            Controls.Add(label13);
            Controls.Add(lblKorisnikId);
            Controls.Add(label10);
            Controls.Add(cmbPrevoz);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(btnSačuvajIzmene);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmChangeTrip";
            Text = "FrmChangeTrip";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbPrevoz;
        private DateTimePicker dtpDatumDo;
        private DateTimePicker dtpDatumOd;
        private Button btnSačuvajIzmene;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label10;
        private Label lblKorisnikId;
        private Label lblPrijavaId;
        private Label label13;
        private Label lblPrezime;
        private Label lblIme;
        private Label lblPasos;
        private Label lblJmbg;
    }
}