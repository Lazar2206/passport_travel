using Domen;
using Logika;
using System.ComponentModel;

namespace ServerskaStrana
{
    public partial class Form1 : Form
    {
        private BindingList<Korisnik> korisnici = new BindingList<Korisnik>();
        private Server server;
        private bool kraj;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            server = new Server();
            server.start();
            Thread nit = new Thread(server.Accept);
            nit.Start();
            btnPokreni.Enabled = false;
            btnZaustavi.Enabled = true;
            Thread nit1 = new Thread(NapuniDGV);
            nit1.Start();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (dgvKorisnici.SelectedRows.Count > 0)
            {
                Korisnik k = (Korisnik)dgvKorisnici.SelectedRows[0].DataBoundItem;
                server.Logout(k);
            }
            else
            {
                MessageBox.Show("Nijedan red nije selektovan");
            }
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            kraj = true;
            dgvKorisnici.DataSource = null;
            server.Stop();
            btnZaustavi.Enabled = false;
            btnPokreni.Enabled = true;
            server = null;
        }
        private void NapuniDGV()
        {
            kraj = false;
            while (!kraj)
            {
                Thread.Sleep(5000); //na svakih 5 sekundi
                Invoke(new Action(() =>
                {
                    korisnici = Kontroler.Instance.VratiPrijavljeneKorisnike();
                    dgvKorisnici.DataSource = null;
                    dgvKorisnici.DataSource = korisnici;
                    dgvKorisnici.Columns["id"].Visible = false;

                }));
            }


        }
    }
}
