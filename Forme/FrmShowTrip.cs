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
    public partial class FrmShowTrip : Form
    {
        private BindingList<PrijavljenaPutovanja> prijavljenaPutovanja = new BindingList<PrijavljenaPutovanja>();
        private Komunikacija komunikacija;
        private Korisnik korisnik;
        public FrmShowTrip(Komunikacija komunikacija, Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            this.komunikacija = komunikacija;
            

        }

        private void NapuniDGV()
        {
            var originalnaPutovanja = Kontroler.Instance.VratiPutovanja(korisnik.JMBG);
            var listaZaPrikaz = new BindingList<PrijavljenaPutovanja>(originalnaPutovanja);

            dgvPutovanja.DataSource = listaZaPrikaz;

            // Ako kolona već postoji, nemoj dodavati duplikat
            if (!dgvPutovanja.Columns.Contains("ZemljaTekst"))
            {
                DataGridViewTextBoxColumn kolonaZemlja = new DataGridViewTextBoxColumn();
                kolonaZemlja.Name = "ZemljaTekst";
                kolonaZemlja.HeaderText = "Zemlje";
                dgvPutovanja.Columns.Add(kolonaZemlja);
            }

            // Popuni vrednosti u novoj koloni
            foreach (DataGridViewRow row in dgvPutovanja.Rows)
            {
                var putovanje = row.DataBoundItem as PrijavljenaPutovanja;
                if (putovanje != null && putovanje.Zemlje != null)
                {
                    row.Cells["ZemljaTekst"].Value = string.Join(", ", putovanje.Zemlje);
                }
            }


        }

        private void btnPrikažiPutovanja_Click(object sender, EventArgs e)
        {
            
            NapuniDGV();
            dgvPutovanja.Columns["ZemljeTekst"].Visible = false;
            dgvPutovanja.Columns["Korisnik"].Visible = false;
            dgvPutovanja.Columns["KorisnikId"].Visible = false;
            dgvPutovanja.Columns["Id"].Visible = false;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvPutovanja.SelectedRows.Count > 0) //proverava da li je neki red selektovan
            {
                PrijavljenaPutovanja putovanje = (PrijavljenaPutovanja)dgvPutovanja.SelectedRows[0].DataBoundItem;

                (new FrmChangeTrip(putovanje, komunikacija)).ShowDialog();
                NapuniDGV();
            }
            else
            {
                MessageBox.Show("Nijedan red nije selektovan");
            }
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            PoveziSe();
            if (dgvPutovanja.SelectedRows.Count > 0)
            {
                PrijavljenaPutovanja delete = (PrijavljenaPutovanja)dgvPutovanja.SelectedRows[0].DataBoundItem;
                Poruka zahtev = new Poruka()
                {
                    Object = delete,
                    Operacija = Operacija.DeleteTrip,
                };
                komunikacija.PošaljiPoruku(zahtev);
                Poruka odgovor = komunikacija.PrimiPoruku();
                if (odgovor.Operacija == Operacija.Uspesno)
                {
                    MessageBox.Show("Uspešno obrisan paket");
                }
                else
                {
                    MessageBox.Show("Greska");
                }
                NapuniDGV();
            }
            else
            {
                MessageBox.Show("Nijedan red nije selektovan!");
            }
        }
    }
}
