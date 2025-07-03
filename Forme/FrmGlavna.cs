using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmGlavna : Form
    {
        private Korisnik korisnik;
        private Komunikacija komunikacija;
        public FrmGlavna(Korisnik korisnik, Komunikacija komunikacija)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            this.komunikacija = komunikacija;
        }

        private void prijaviPutovanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FrmScheduleTrip(korisnik, komunikacija)).ShowDialog();
        }

        private void showATripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FrmShowTrip(komunikacija,korisnik)).ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            komunikacija.Logout();
            //gašenje forme
            Application.Exit();
        }
    }
}
