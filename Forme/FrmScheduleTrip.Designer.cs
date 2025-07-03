namespace Forme
{
    partial class FrmScheduleTrip
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnPrijaviPutovanje = new Button();
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            cmbPrevoz = new ComboBox();
            colorDialog1 = new ColorDialog();
            label5 = new Label();
            cmbZemlja = new ComboBox();
            label7 = new Label();
            btnObriši = new Button();
            btnOdaberiZemlju = new Button();
            dgvOdabraneZemlje = new DataGridView();
            lblIme = new Label();
            lblPrezime = new Label();
            lblJmbg = new Label();
            lblPasos = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOdabraneZemlje).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 38);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 0;
            label1.Text = "lme:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 84);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 2;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(-3, 137);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 4;
            label3.Text = "Datum ulaska:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 310);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 6;
            label4.Text = "Prevoz:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-3, 174);
            label6.Name = "label6";
            label6.Size = new Size(105, 20);
            label6.TabIndex = 10;
            label6.Text = "Datum izlaska:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 221);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 13;
            label8.Text = "JMBG:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(-3, 261);
            label9.Name = "label9";
            label9.Size = new Size(89, 20);
            label9.TabIndex = 15;
            label9.Text = "Broj pasoša:";
            // 
            // btnPrijaviPutovanje
            // 
            btnPrijaviPutovanje.Location = new Point(101, 399);
            btnPrijaviPutovanje.Name = "btnPrijaviPutovanje";
            btnPrijaviPutovanje.Size = new Size(146, 29);
            btnPrijaviPutovanje.TabIndex = 17;
            btnPrijaviPutovanje.Text = "Prijavi putovanje";
            btnPrijaviPutovanje.UseVisualStyleBackColor = true;
            btnPrijaviPutovanje.Click += btnPrijaviPutovanje_Click;
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(105, 137);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(243, 27);
            dtpDatumOd.TabIndex = 20;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(105, 174);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(243, 27);
            dtpDatumDo.TabIndex = 21;
            // 
            // cmbPrevoz
            // 
            cmbPrevoz.FormattingEnabled = true;
            cmbPrevoz.Location = new Point(105, 307);
            cmbPrevoz.Name = "cmbPrevoz";
            cmbPrevoz.Size = new Size(125, 28);
            cmbPrevoz.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(545, 35);
            label5.Name = "label5";
            label5.Size = new Size(118, 20);
            label5.TabIndex = 7;
            label5.Text = "Odaberi zemlju: ";
            // 
            // cmbZemlja
            // 
            cmbZemlja.FormattingEnabled = true;
            cmbZemlja.Location = new Point(694, 34);
            cmbZemlja.Name = "cmbZemlja";
            cmbZemlja.Size = new Size(125, 28);
            cmbZemlja.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(706, 144);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 12;
            // 
            // btnObriši
            // 
            btnObriši.Location = new Point(763, 81);
            btnObriši.Name = "btnObriši";
            btnObriši.Size = new Size(155, 29);
            btnObriši.TabIndex = 23;
            btnObriši.Text = "Obriši zemlju";
            btnObriši.UseVisualStyleBackColor = true;
            btnObriši.Click += btnObriši_Click;
            // 
            // btnOdaberiZemlju
            // 
            btnOdaberiZemlju.Location = new Point(545, 81);
            btnOdaberiZemlju.Name = "btnOdaberiZemlju";
            btnOdaberiZemlju.Size = new Size(161, 29);
            btnOdaberiZemlju.TabIndex = 19;
            btnOdaberiZemlju.Text = "Odaberi zemlju";
            btnOdaberiZemlju.UseVisualStyleBackColor = true;
            btnOdaberiZemlju.Click += btnOdaberiZemlju_Click;
            // 
            // dgvOdabraneZemlje
            // 
            dgvOdabraneZemlje.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOdabraneZemlje.Location = new Point(545, 134);
            dgvOdabraneZemlje.Name = "dgvOdabraneZemlje";
            dgvOdabraneZemlje.RowHeadersWidth = 51;
            dgvOdabraneZemlje.Size = new Size(389, 233);
            dgvOdabraneZemlje.TabIndex = 18;
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Location = new Point(121, 38);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(58, 20);
            lblIme.TabIndex = 24;
            lblIme.Text = "label10";
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Location = new Point(121, 85);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(58, 20);
            lblPrezime.TabIndex = 25;
            lblPrezime.Text = "label11";
            // 
            // lblJmbg
            // 
            lblJmbg.AutoSize = true;
            lblJmbg.Location = new Point(121, 221);
            lblJmbg.Name = "lblJmbg";
            lblJmbg.Size = new Size(58, 20);
            lblJmbg.TabIndex = 26;
            lblJmbg.Text = "label12";
            // 
            // lblPasos
            // 
            lblPasos.AutoSize = true;
            lblPasos.Location = new Point(121, 261);
            lblPasos.Name = "lblPasos";
            lblPasos.Size = new Size(58, 20);
            lblPasos.TabIndex = 27;
            lblPasos.Text = "label13";
            // 
            // FrmScheduleTrip
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 488);
            Controls.Add(lblPasos);
            Controls.Add(lblJmbg);
            Controls.Add(lblPrezime);
            Controls.Add(lblIme);
            Controls.Add(btnObriši);
            Controls.Add(cmbPrevoz);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(btnOdaberiZemlju);
            Controls.Add(dgvOdabraneZemlje);
            Controls.Add(btnPrijaviPutovanje);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(cmbZemlja);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmScheduleTrip";
            Text = "ScheduleTrip";
            ((System.ComponentModel.ISupportInitialize)dgvOdabraneZemlje).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtDatumUlaska;
        private Label label3;
        private Label label4;
        private ComboBox cbPrevoz;
        private TextBox txtDatumIzlaska;
        private Label label6;
        private Label label8;
        private Label label9;
        private Button btnPrijaviPutovanje;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
        private ComboBox cmbPrevoz;
        private ColorDialog colorDialog1;
        private Label label5;
        private ComboBox cmbZemlja;
        private Label label7;
        private Button btnObriši;
        private Button btnOdaberiZemlju;
        private DataGridView dgvOdabraneZemlje;
        private Label lblIme;
        private Label lblPrezime;
        private Label lblJmbg;
        private Label lblPasos;
    }
}