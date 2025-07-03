using Domen;
using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmScheduleTrip : Form
    {
        private bool placaSe;
        private Korisnik korisnik;
        private Komunikacija komunikacija;

        public FrmScheduleTrip(Korisnik korisnik, Komunikacija komunikacija)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            lblIme.Text=korisnik.Ime.ToString();
            lblPrezime.Text=korisnik.Prezime.ToString();
            lblJmbg.Text=korisnik.JMBG.ToString();
            lblPasos.Text=korisnik.brojPasoša.ToString();
            this.komunikacija = komunikacija;


            NapuniCMB();
            NapuniDGV();
        }

        private void NapuniDGV()
        {
            if (dgvOdabraneZemlje.Columns.Count == 0)
            {
                dgvOdabraneZemlje.Columns.Add("Zemlja", "Zemlja EU");
                dgvOdabraneZemlje.AllowUserToAddRows = false;
            }
        }

        private void PoveziSe()
        {
            if (komunikacija == null)
            {
                komunikacija = new Komunikacija();
                if (!komunikacija.PoveziSe())
                {
                    komunikacija = null;
                    MessageBox.Show("Neuspešno povezivanje");
                    return;
                }
            }
        }

        private void NapuniCMB()
        {
            PoveziSe();
            cmbPrevoz.DataSource = Enum.GetValues(typeof(Prevoz));
            cmbPrevoz.SelectedIndex = -1;
            cmbZemlja.DataSource = Enum.GetValues(typeof(DrzaveEU));
            cmbZemlja.SelectedIndex = -1;
        }

        private void btnOdaberiZemlju_Click(object sender, EventArgs e)
        {
            if (cmbZemlja.SelectedItem == null)
            {
                MessageBox.Show("Molimo vas da izaberete zemlju iz liste.");
                return;
            }

            string izabranaZemlja = cmbZemlja.SelectedItem.ToString();

            foreach (DataGridViewRow row in dgvOdabraneZemlje.Rows)
            {
                if (row.Cells[0].Value?.ToString() == izabranaZemlja)
                {
                    MessageBox.Show("Zemlja je već dodata.");
                    return;
                }
            }

            dgvOdabraneZemlje.Rows.Add(izabranaZemlja);
        }

        private void btnObriši_Click(object sender, EventArgs e)
        {
            if (dgvOdabraneZemlje.SelectedRows.Count > 0)
            {
                DataGridViewRow selektovaniRed = dgvOdabraneZemlje.SelectedRows[0];

                DialogResult dr = MessageBox.Show("Da li ste sigurni da želite da obrišete izabranu zemlju?",
                                                  "Potvrda",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    dgvOdabraneZemlje.Rows.Remove(selektovaniRed);
                }
            }
            else
            {
                MessageBox.Show("Molimo vas da prvo selektujete zemlju koju želite da obrišete.");
            }
        }

        private void btnPrijaviPutovanje_Click(object sender, EventArgs e)
        {
          

            List<string> selektovaneZemlje = dgvOdabraneZemlje.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["Zemlja"].Value != null && !r.IsNewRow)
                .Select(r => r.Cells["Zemlja"].Value.ToString())
                .ToList();

            if (selektovaneZemlje.Count == 0)
            {
                MessageBox.Show("Dodajte bar jednu zemlju.");
                return;
            }

            string jmbg = lblJmbg.Text;
            

            int dan = int.Parse(jmbg.Substring(0, 2));
            int mesec = int.Parse(jmbg.Substring(2, 2));
            int godina = int.Parse(jmbg.Substring(4, 3));
            godina += (godina >= 900) ? 1000 : 2000;
            if (godina > DateTime.Now.Year) godina -= 100;

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

            Korisnik pronadjeniKorisnik = Kontroler.Instance.PronadjiKorisnika(korisnik.Username, korisnik.Password);
            int korisnikovId = pronadjeniKorisnik.Id;

            // PROVERA: da li korisnik već ima putovanje za iste zemlje i datume
            List<PrijavljenaPutovanja> postojecaPutovanja = Kontroler.Instance.VratiPutovanja(lblJmbg.Text);

            foreach (var put in postojecaPutovanja)
            {
                foreach (var zemlja in selektovaneZemlje)
                {
                    if (put.Zemlje.Contains(zemlja) &&
                        dtpDatumOd.Value <= put.DatumIzlaska &&
                        dtpDatumDo.Value >= put.DatumUlaska)
                    {
                        MessageBox.Show($"Već imate prijavljeno putovanje za {zemlja} u datom periodu.");
                        return;
                    }
                }
            }

            StatusPrijave status;
            TimeSpan vremeDoUlaska = dtpDatumOd.Value - DateTime.Now;
            if (vremeDoUlaska.TotalHours < 48 && dtpDatumOd.Value > DateTime.Now)
                status = StatusPrijave.Zakljucana;
            else if (dtpDatumOd.Value <= DateTime.Now && dtpDatumDo.Value >= DateTime.Now)
                status = StatusPrijave.U_Obradi;
            else if (dtpDatumDo.Value < DateTime.Now)
                status = StatusPrijave.Zavrsena;
            else
                status = StatusPrijave.U_Obradi;

            var prijava = new PrijavljenaPutovanja
            {
                Ime = lblIme.Text,
                Prezime = lblPrezime.Text,
                KorisnikId = korisnikovId,
                JMBG = lblJmbg.Text,
                Pasoš = lblPasos.Text,
                Zemlje = selektovaneZemlje,
                DatumPrijave = DateTime.Now,
                DatumUlaska = dtpDatumOd.Value,
                DatumIzlaska = dtpDatumDo.Value,
                Prevoz = (Prevoz)cmbPrevoz.SelectedItem,
                BrojDanaBoravka = (int)(dtpDatumDo.Value - dtpDatumOd.Value).TotalDays,
                Platio = placaSe,
                Status = status
            };

            Poruka zahtev = new Poruka { Object = prijava, Operacija = Operacija.ScheduleTrip };
            komunikacija.PošaljiPoruku(zahtev);
            Poruka odgovor = komunikacija.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspesno)
            {
                MessageBox.Show("Uspešno dodavanje putovanja.");
                GenerisiFajl(prijava.Ime, prijava.Prezime, prijava.JMBG, prijava.Pasoš,
                             prijava.Zemlje, prijava.DatumPrijave, prijava.DatumUlaska,
                             prijava.BrojDanaBoravka);
            }
            else
            {
                MessageBox.Show("Neuspešno.");
            }
        }

        private void GenerisiFajl(string ime, string prezime, string jmbg, string brPasosa,
                                  List<string> zemlje, DateTime datumPrijave,
                                  DateTime datumUlaska, int brDana)
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
