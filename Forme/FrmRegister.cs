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
        
        private Komunikacija komunikacija;
        public FrmRegister(Komunikacija komunikacija)
        {
            InitializeComponent();
            this.komunikacija = komunikacija;
            
        }

        private void btnRegistruj_Click(object sender, EventArgs e)
        {
            PoveziSe();
            Register();
        }

        private void PoveziSe()
        {
            if (komunikacija == null)
            {
                komunikacija = new Komunikacija();
                if (!komunikacija.PoveziSe())//provera da li se povezao 
                {
                    komunikacija = null; //ako se nije povezao
                    MessageBox.Show("Neuspešno povezivanje");
                    return;
                }
            }
        }

        private void Register()
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text) ||
          string.IsNullOrWhiteSpace(txtPrezime.Text) ||
            string.IsNullOrWhiteSpace(txtJMBG.Text) ||
            string.IsNullOrWhiteSpace(txtUsername.Text) ||
              string.IsNullOrWhiteSpace(txtEmail.Text) ||
               string.IsNullOrWhiteSpace(txtpasos.Text))
            {
                MessageBox.Show("Molimo vas da popunite sva polja.");
                return;
            }
            if (!ValidanJMBG(txtJMBG.Text))
            {
                MessageBox.Show("Unesi JMBG u formatu: DDMMGGGRRBBBK");
                return;
            }

          
            if (Kontroler.Instance.UsernamePostoji(txtUsername.Text))
            {
                MessageBox.Show("Korisnicko ime vec postoji.");
                return;
            }
          
           
            if (txtpasos.Text.Length != 9 || !txtpasos.Text.All(char.IsDigit))
            {
                MessageBox.Show("Unesite broj pasoša u dobrom formatu");
                return;
            }
            if (!Kontroler.Instance.PraviDrzavljanin(txtJMBG.Text, txtIme.Text, txtPrezime.Text, txtpasos.Text))
            {
                MessageBox.Show("Ime i prezime osobe se ne poklapa sa JMBG i pasošom");
                return;
            }
            if (Kontroler.Instance.PostojiRegKorisnik(txtJMBG.Text, txtpasos.Text))
            {
                MessageBox.Show("Već postoji registrovani korisnik sa ovim JMBG-om i pasošem");
                return;
            }


            Korisnik korisnik = new Korisnik()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Email = txtEmail.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                JMBG = txtJMBG.Text,
                brojPasoša = txtpasos.Text
            };
          

            //kreiranje zahteva
            Poruka zahtev = new Poruka
            {
                Object = korisnik,
                Operacija = Operacija.Register
            };
            //slanje zahteva
            komunikacija.PošaljiPoruku(zahtev);
            //primanje odgovora
            Poruka odgovor = komunikacija.PrimiPoruku();
            if (odgovor.Operacija == Operacija.Uspesno)
            {
               
                MessageBox.Show("Uspešno");
                this.Close();
            }
            else
            {
                MessageBox.Show("Neuspešno");
            }
            //Kontroler.Instance.DodajKorisnika(korisnik);
            //MessageBox.Show("Uspešna registracija");
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
