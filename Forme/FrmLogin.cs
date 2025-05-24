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
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void Login()
        {
            Korisnik korisnik = new Korisnik()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
            };
            if (Kontroler.Instance.Login(korisnik))
            {
                MessageBox.Show("Dobrodošli");
                FrmGlavna frm = new FrmGlavna();
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
            FrmRegister frm = new FrmRegister();
            this.Visible = false;
            frm.ShowDialog();
            
            
        }
    }
}
