using Domen;
using Logika;
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
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void btnRegistruj_Click(object sender, EventArgs e)
        {
            if (!ValidanJMBG(txtJMBG.Text))
            {
                MessageBox.Show("Unesi JMBG u formatu: DDMMGGGRRBBBK");
                return;
            }

            if (!txtJMBG.Text.Equals(txtpasos.Text))
            {
                MessageBox.Show("JMBG i broj pasoša moraju biti jednaki.");
                return;
            }
            if (Kontroler.Instance.UsernamePostoji(txtUsername.Text))
            {
                MessageBox.Show("Korisnicko ime vec postoji.");
                return;
            }
            if (Kontroler.Instance.JmbgPostoji(txtJMBG.Text))
            {
                MessageBox.Show("Korisnik sa ovim JMBG-om već postoji.");
                return;
            }

            Korisnik korisnik = new Korisnik()
            {
                Ime=txtIme.Text,
                Prezime=txtPrezime.Text,
                Email=txtEmail.Text,
                Username=txtUsername.Text,
                Password=txtPassword.Text,
                JMBG=txtJMBG.Text,
                brojPasoša=txtpasos.Text
            };
            Kontroler.Instance.DodajKorisnika(korisnik);
            MessageBox.Show("Uspešna registracija");
        }
        private bool ValidanJMBG(string jmbg)
        {
            if (jmbg.Length != 13 || !jmbg.All(char.IsDigit))
                return false;

            int dan = int.Parse(jmbg.Substring(0, 2));
            int mesec = int.Parse(jmbg.Substring(2, 2));
            int godina = int.Parse(jmbg.Substring(4, 3));
            int punaGodina = godina < 1000 ? (godina < 100 ? 2000 + godina : 1000 + godina) : godina;

            try
            {
                DateTime datum = new DateTime(punaGodina, mesec, dan);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
