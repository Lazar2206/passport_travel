namespace Forme
{
    partial class FrmGlavna
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
            menuStrip1 = new MenuStrip();
            prijaviPutovanjeToolStripMenuItem = new ToolStripMenuItem();
            showATripToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { prijaviPutovanjeToolStripMenuItem, showATripToolStripMenuItem, logoutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // prijaviPutovanjeToolStripMenuItem
            // 
            prijaviPutovanjeToolStripMenuItem.Name = "prijaviPutovanjeToolStripMenuItem";
            prijaviPutovanjeToolStripMenuItem.Size = new Size(122, 24);
            prijaviPutovanjeToolStripMenuItem.Text = "Schedule a trip";
            prijaviPutovanjeToolStripMenuItem.Click += prijaviPutovanjeToolStripMenuItem_Click;
            // 
            // showATripToolStripMenuItem
            // 
            showATripToolStripMenuItem.Name = "showATripToolStripMenuItem";
            showATripToolStripMenuItem.Size = new Size(98, 24);
            showATripToolStripMenuItem.Text = "Show a trip";
            showATripToolStripMenuItem.Click += showATripToolStripMenuItem_Click;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(70, 24);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // FrmGlavna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmGlavna";
            Text = "FrmGlavna";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem prijaviPutovanjeToolStripMenuItem;
        private ToolStripMenuItem showATripToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
    }
}