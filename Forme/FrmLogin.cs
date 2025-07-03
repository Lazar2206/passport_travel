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
    public partial class FrmLogin : Form
    {
        private Komunikacija komunikacija;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PoveziSe();
            Login();
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

        private void Login()
        {
            Korisnik potencijalni = Kontroler.Instance.PronadjiKorisnika(txtUsername.Text,txtPassword.Text);
            if(potencijalni==null)
            {
                MessageBox.Show("Pogrešili ste username ili password");
                return;
            }
            Korisnik korisnik = new Korisnik()
            {
                Ime=potencijalni.Ime,
                Prezime=potencijalni.Prezime,
                Email=potencijalni.Email,
                JMBG=potencijalni.JMBG,
                brojPasoša=potencijalni.brojPasoša,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                
            };
            //kreiranje zahteva
            Poruka zahtev = new Poruka();
            zahtev.Object = korisnik;
            zahtev.Operacija = Operacija.Login;
            //slanje zahteva
            komunikacija.PošaljiPoruku(zahtev);
            //primanje odgovora
            Poruka odgovor = komunikacija.PrimiPoruku();
            if (odgovor.Operacija.Equals(Operacija.Uspesno))
            {
                MessageBox.Show("Dobrodošli");
                FrmGlavna frm = new FrmGlavna(korisnik, komunikacija);
                this.Visible = false;
                frm.ShowDialog();
            }
            else
            {
                //ako podaci nisu ispravni
                MessageBox.Show("Nepostojeci korisnik");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegister frm = new FrmRegister(komunikacija);
            frm.ShowDialog();


        }

        private void btnBezNaloga_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dobrodošli");
            FrmWithoutAccount bezNaloga = new FrmWithoutAccount(komunikacija);
            this.Visible = false;
            bezNaloga.ShowDialog();
        }
    }
}
