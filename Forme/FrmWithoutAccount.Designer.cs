namespace Forme
{
    partial class FrmWithoutAccount
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
            btnObriši = new Button();
            cmbPrevoz = new ComboBox();
            dtpDatumDo = new DateTimePicker();
            dtpDatumOd = new DateTimePicker();
            btnOdaberiZemlju = new Button();
            dgvOdabraneZemlje = new DataGridView();
            btnPrijaviPutovanje = new Button();
            txtBrojPasoša = new TextBox();
            label9 = new Label();
            txtJMBG = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            cmbZemlja = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtPrezime = new TextBox();
            label2 = new Label();
            txtIme = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOdabraneZemlje).BeginInit();
            SuspendLayout();
            // 
            // btnObriši
            // 
            btnObriši.Location = new Point(845, 112);
            btnObriši.Name = "btnObriši";
            btnObriši.Size = new Size(155, 29);
            btnObriši.TabIndex = 44;
            btnObriši.Text = "Obriši zemlju";
            btnObriši.UseVisualStyleBackColor = true;
            btnObriši.Click += btnObriši_Click_1;
            // 
            // cmbPrevoz
            // 
            cmbPrevoz.FormattingEnabled = true;
            cmbPrevoz.Location = new Point(187, 338);
            cmbPrevoz.Name = "cmbPrevoz";
            cmbPrevoz.Size = new Size(125, 28);
            cmbPrevoz.TabIndex = 43;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(187, 205);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(243, 27);
            dtpDatumDo.TabIndex = 42;
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(187, 168);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(243, 27);
            dtpDatumOd.TabIndex = 41;
            // 
            // btnOdaberiZemlju
            // 
            btnOdaberiZemlju.Location = new Point(627, 112);
            btnOdaberiZemlju.Name = "btnOdaberiZemlju";
            btnOdaberiZemlju.Size = new Size(161, 29);
            btnOdaberiZemlju.TabIndex = 40;
            btnOdaberiZemlju.Text = "Odaberi zemlju";
            btnOdaberiZemlju.UseVisualStyleBackColor = true;
            btnOdaberiZemlju.Click += btnOdaberiZemlju_Click_1;
            // 
            // dgvOdabraneZemlje
            // 
            dgvOdabraneZemlje.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOdabraneZemlje.Location = new Point(627, 165);
            dgvOdabraneZemlje.Name = "dgvOdabraneZemlje";
            dgvOdabraneZemlje.RowHeadersWidth = 51;
            dgvOdabraneZemlje.Size = new Size(389, 233);
            dgvOdabraneZemlje.TabIndex = 39;
            // 
            // btnPrijaviPutovanje
            // 
            btnPrijaviPutovanje.Location = new Point(183, 430);
            btnPrijaviPutovanje.Name = "btnPrijaviPutovanje";
            btnPrijaviPutovanje.Size = new Size(146, 29);
            btnPrijaviPutovanje.TabIndex = 38;
            btnPrijaviPutovanje.Text = "Prijavi putovanje";
            btnPrijaviPutovanje.UseVisualStyleBackColor = true;
            btnPrijaviPutovanje.Click += btnPrijaviPutovanje_Click_1;
            // 
            // txtBrojPasoša
            // 
            txtBrojPasoša.Location = new Point(187, 292);
            txtBrojPasoša.Name = "txtBrojPasoša";
            txtBrojPasoša.Size = new Size(125, 27);
            txtBrojPasoša.TabIndex = 37;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(79, 292);
            label9.Name = "label9";
            label9.Size = new Size(89, 20);
            label9.TabIndex = 36;
            label9.Text = "Broj pasoša:";
            // 
            // txtJMBG
            // 
            txtJMBG.Location = new Point(187, 245);
            txtJMBG.Name = "txtJMBG";
            txtJMBG.Size = new Size(125, 27);
            txtJMBG.TabIndex = 35;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(96, 252);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 34;
            label8.Text = "JMBG:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(788, 175);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 33;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(79, 205);
            label6.Name = "label6";
            label6.Size = new Size(105, 20);
            label6.TabIndex = 32;
            label6.Text = "Datum izlaska:";
            // 
            // cmbZemlja
            // 
            cmbZemlja.FormattingEnabled = true;
            cmbZemlja.Location = new Point(776, 65);
            cmbZemlja.Name = "cmbZemlja";
            cmbZemlja.Size = new Size(125, 28);
            cmbZemlja.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(627, 66);
            label5.Name = "label5";
            label5.Size = new Size(118, 20);
            label5.TabIndex = 30;
            label5.Text = "Odaberi zemlju: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(92, 341);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 29;
            label4.Text = "Prevoz:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(79, 168);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 28;
            label3.Text = "Datum ulaska:";
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(187, 112);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(125, 27);
            txtPrezime.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 115);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 26;
            label2.Text = "Prezime:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(187, 66);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(125, 27);
            txtIme.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 69);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 24;
            label1.Text = "lme:";
            // 
            // FrmWithoutAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 519);
            Controls.Add(btnObriši);
            Controls.Add(cmbPrevoz);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(btnOdaberiZemlju);
            Controls.Add(dgvOdabraneZemlje);
            Controls.Add(btnPrijaviPutovanje);
            Controls.Add(txtBrojPasoša);
            Controls.Add(label9);
            Controls.Add(txtJMBG);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(cmbZemlja);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtPrezime);
            Controls.Add(label2);
            Controls.Add(txtIme);
            Controls.Add(label1);
            Name = "FrmWithoutAccount";
            Text = "FrmWithoutAccount";
            ((System.ComponentModel.ISupportInitialize)dgvOdabraneZemlje).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnObriši;
        private ComboBox cmbPrevoz;
        private DateTimePicker dtpDatumDo;
        private DateTimePicker dtpDatumOd;
        private Button btnOdaberiZemlju;
        private DataGridView dgvOdabraneZemlje;
        private Button btnPrijaviPutovanje;
        private TextBox txtBrojPasoša;
        private Label label9;
        private TextBox txtJMBG;
        private Label label8;
        private Label label7;
        private Label label6;
        private ComboBox cmbZemlja;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtPrezime;
        private Label label2;
        private TextBox txtIme;
        private Label label1;
    }
}