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
    public partial class FrmChangeTrip : Form
    {
        private bool placaSe;
        private PrijavljenaPutovanja putovanje;
        private Komunikacija komunikacija;
        public FrmChangeTrip(PrijavljenaPutovanja putovanje, Komunikacija komunikacija)
        {
            InitializeComponent();
            this.putovanje = putovanje;
            this.komunikacija = komunikacija;
            lblKorisnikId.Text = putovanje.KorisnikId.ToString();
            lblPrijavaId.Text = putovanje.Id.ToString();
            lblIme.Text = putovanje.Ime.ToString();
            lblPrezime.Text = putovanje.Prezime.ToString();
            lblJmbg.Text = putovanje.JMBG.ToString();
            lblPasos.Text = putovanje.Pasoš.ToString();
            dtpDatumOd.Value = putovanje.DatumUlaska;
            dtpDatumDo.Value = putovanje.DatumIzlaska;
            cmbPrevoz.DataSource = Enum.GetValues(typeof(Prevoz));
            cmbPrevoz.SelectedItem = putovanje.Prevoz;

        }

        private void btnSačuvajIzmene_Click(object sender, EventArgs e)
        {
            string jmbg = lblJmbg.Text;
            if (jmbg.Length != 13)
            {
                MessageBox.Show("JMBG mora sadržati tačno 13 cifara.");
                return;
            }

            int dan = int.Parse(jmbg.Substring(0, 2));
            int mesec = int.Parse(jmbg.Substring(2, 2));
            int godina = int.Parse(jmbg.Substring(4, 3));

            if (godina >= 0 && godina <= 999)
            {
                godina += (godina >= 900) ? 1000 : 2000;
                if (godina > DateTime.Now.Year)
                    godina -= 100;
            }

            DateTime datumRodjenja;
            try
            {
                datumRodjenja = new DateTime(godina, mesec, dan);
            }
            catch
            {
                MessageBox.Show("Neispravan datum u JMBG-u.");
                return;
            }

            int starost = DateTime.Now.Year - datumRodjenja.Year;
            if (datumRodjenja > DateTime.Now.AddYears(-starost)) starost--;

            placaSe = starost >= 18 && starost <= 70;
            // Određivanje statusa na osnovu datuma
            StatusPrijave status;

            TimeSpan vremeDoUlaska = dtpDatumOd.Value - DateTime.Now;

            if (vremeDoUlaska.TotalHours < 48 && dtpDatumOd.Value > DateTime.Now)
            {

                status = StatusPrijave.Zakljucana;
            }
            else if (dtpDatumOd.Value <= DateTime.Now && dtpDatumDo.Value >= DateTime.Now)
            {

                status = StatusPrijave.U_Obradi;
            }
            else if (dtpDatumDo.Value < DateTime.Now)
            {
                // Putovanje je završeno
                status = StatusPrijave.Zavrsena;
            }
            else
            {
                // Sve ostalo — aktivna prijava za neko buduće vreme
                status = StatusPrijave.U_Obradi;
            }

            if ((putovanje.DatumUlaska - DateTime.Now).TotalHours < 48)
            {
                MessageBox.Show("Ne možete izmeniti 48 sati pre putovanja");
                return;
            }

            if (dtpDatumOd.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Datum ulaska ne može biti u prošlosti!");
                return;
            }

            if (dtpDatumDo.Value.Date < dtpDatumOd.Value.Date)
            {
                MessageBox.Show("Datum izlaska ne može biti pre datuma ulaska!");
                return;
            }

            if ((dtpDatumDo.Value - dtpDatumOd.Value).TotalDays > 90)
            {
                MessageBox.Show("Boravak ne može biti duži od 90 dana!");
                return;
            }
            if (
                 cmbPrevoz.SelectedItem == null)
            {
                MessageBox.Show("Molimo vas da popunite sva polja.");
                return;
            }
            PrijavljenaPutovanja prijava = new PrijavljenaPutovanja()
            {
                Id = putovanje.Id,
                KorisnikId = putovanje.KorisnikId,
                Ime = lblIme.Text,
                Prezime = lblPrezime.Text,
              
                JMBG = lblJmbg.Text,
                Pasoš = lblPasos.Text,
                DatumPrijave = DateTime.Now,
                DatumUlaska = dtpDatumOd.Value,
                DatumIzlaska = dtpDatumDo.Value,
                Prevoz = (Prevoz)cmbPrevoz.SelectedItem,
                BrojDanaBoravka = (int)(dtpDatumDo.Value - dtpDatumOd.Value).TotalDays,
                Platio = placaSe,
                Status = status,
                Zemlje = putovanje.Zemlje

            };

            Poruka zahtev = new Poruka
            {
                Object = prijava,
                Operacija = Operacija.ChangeTrip,
            };
            komunikacija.PošaljiPoruku(zahtev);
            Poruka odgovor = komunikacija.PrimiPoruku();
            if (odgovor.Operacija == Operacija.Uspesno)
            {
                MessageBox.Show("Paket je uspešno izmenjen");
            }
            else
            {
                MessageBox.Show("Greska");
            }
            

           
           // Kontroler.Instance.AzurirajPutovanje(prijava);
            GenerisiFajl(prijava.Ime, prijava.Prezime, prijava.JMBG, prijava.Pasoš, prijava.Zemlje, prijava.DatumPrijave, prijava.DatumUlaska, prijava.BrojDanaBoravka);
           // MessageBox.Show("Uspešno ažurirano putovanje");
            this.Close();
        }
        private void GenerisiFajl(string ime, string prezime, string jmbg, string brPasosa, List<string> zemlje, DateTime datumPrijave, DateTime datumUlaska, int brDana)
        {
            string folderPath = $"C:\\Korisnici\\PC\\source\\repos\\rmt_saobracaj\\prijave\\{jmbg}";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, datumUlaska.ToString("yyyy-MM-dd") + ".txt");

            StringBuilder sadrzaj = new StringBuilder();
            sadrzaj.AppendLine($"Ime: {ime}");
            sadrzaj.AppendLine($"Prezime: {prezime}");
            sadrzaj.AppendLine($"JMBG: {jmbg}");
            sadrzaj.AppendLine($"Broj pasoša: {brPasosa}");
            sadrzaj.AppendLine($"Zemlje EU: {string.Join(", ", zemlje)}");
            sadrzaj.AppendLine($"Datum prijave: {datumPrijave:dd.MM.yyyy}");
            sadrzaj.AppendLine($"Datum ulaska: {datumUlaska:dd.MM.yyyy}");
            sadrzaj.AppendLine($"Broj dana boravka: {brDana}");

            try
            {
                File.WriteAllText(filePath, sadrzaj.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom generisanja fajla: " + ex.Message);
            }
        }
    }
}
