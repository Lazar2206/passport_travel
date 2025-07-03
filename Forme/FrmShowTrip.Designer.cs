namespace Forme
{
    partial class FrmShowTrip
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
            btnPrikažiPutovanja = new Button();
            dgvPutovanja = new DataGridView();
            btnIzmeni = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPutovanja).BeginInit();
            SuspendLayout();
            // 
            // btnPrikažiPutovanja
            // 
            btnPrikažiPutovanja.Location = new Point(1391, 163);
            btnPrikažiPutovanja.Name = "btnPrikažiPutovanja";
            btnPrikažiPutovanja.Size = new Size(142, 29);
            btnPrikažiPutovanja.TabIndex = 0;
            btnPrikažiPutovanja.Text = "Prikaži putovanja";
            btnPrikažiPutovanja.UseVisualStyleBackColor = true;
            btnPrikažiPutovanja.Click += btnPrikažiPutovanja_Click;
            // 
            // dgvPutovanja
            // 
            dgvPutovanja.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPutovanja.Location = new Point(12, 131);
            dgvPutovanja.Name = "dgvPutovanja";
            dgvPutovanja.RowHeadersWidth = 51;
            dgvPutovanja.Size = new Size(1289, 381);
            dgvPutovanja.TabIndex = 3;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(1391, 221);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(142, 29);
            btnIzmeni.TabIndex = 4;
            btnIzmeni.Text = "Edit trip";
            btnIzmeni.UseVisualStyleBackColor = true;
            btnIzmeni.Click += btnIzmeni_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1391, 283);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(142, 29);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete trip";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // FrmShowTrip
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1579, 558);
            Controls.Add(btnDelete);
            Controls.Add(btnIzmeni);
            Controls.Add(dgvPutovanja);
            Controls.Add(btnPrikažiPutovanja);
            Name = "FrmShowTrip";
            Text = "FrmShowTrip";
            ((System.ComponentModel.ISupportInitialize)dgvPutovanja).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPrikažiPutovanja;
        private DataGridView dgvPutovanja;
        private Button btnIzmeni;
        private Button btnDelete;
    }
}