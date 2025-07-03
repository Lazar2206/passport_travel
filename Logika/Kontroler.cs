using DBBroker;
using Domen;
using Microsoft.Identity.Client.Extensibility;
using Repozitorijumi;
using System.ComponentModel;

namespace Logika
{
    public class Kontroler
    {
        private static Kontroler instance; //klasa može da istancira samu sebe; šef mafije


        private Broker broker = new Broker();
        private RepozitorijumKorisnici korisnici = new RepozitorijumKorisnici();
        private BindingList<Korisnik> prijavljeniKorisnici = new BindingList<Korisnik>();


        public static Kontroler Instance//telefon do šefa
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kontroler();
                }
                return instance;
            }
        }
        private Kontroler()
        {
        }

        public bool Login(Korisnik korisnik) //proveravamo da li mafijas koji se loguje pripada našoj mafiji
        {
            foreach (Korisnik k in broker.VratiSveKorisnike())
            {
                if (k.Username == korisnik.Username && k.Password == korisnik.Password)
                {
                    prijavljeniKorisnici.Add(k);
                    return true;
                }
            }
            return false;
        }

        public void DodajKorisnika(Korisnik korisnik)
        {
            broker.DodajKorisnika(korisnik);
        }

        public bool UsernamePostoji(string username)
        {
           return broker.UsernamePostoji(username);
        }

        public bool PraviDrzavljanin(string JMBG, string ime, string prezime, string pasos)
        {
            return broker.PraviDrzavljanin(JMBG, ime, prezime, pasos);
        }

        public void AzurirajPutovanje(PrijavljenaPutovanja prijava)
        {
           broker.AzurirajPutovanje(prijava);
        }

        public Korisnik PronadjiKorisnika(string username, string password)
        {
          return (Korisnik)broker.PronadjiKorisnika(username, password);
        }

        public List<PrijavljenaPutovanja> VratiPutovanja(String jmbg)
        {
            return broker.VratiPutovanja(jmbg);
        }

        public void PrijaviPutovanje(PrijavljenaPutovanja prijava)
        {
            broker.PrijaviPutovanje(prijava);
        }

        public void DeleteTrip(PrijavljenaPutovanja delete)
        {
            broker.DeleteTrip(delete);
        }

        public void Logout(Korisnik prijavljeniKorisnik)
        {
            foreach (Korisnik k in prijavljeniKorisnici)
            {
                if (k.Username == prijavljeniKorisnik.Username && k.Password == prijavljeniKorisnik.Password)
                {
                    prijavljeniKorisnici.Remove(k);
                    return;
                }
            }
        }

        public BindingList<Korisnik> VratiPrijavljeneKorisnike()
        {
            return new BindingList<Korisnik>(prijavljeniKorisnici);
        }

        public Korisnik VratiOdgKorisnika(string username, string passworkd)
        {
            throw new NotImplementedException();
        }

        public bool BrojPasosaPostoji(string pasos)
        {
            return broker.BrojPasosaPostoji(pasos);
        }

        public bool PostojiRegKorisnik(string jmbg, string pasos)
        {
            return broker.PostojiRegKorisnik(jmbg, pasos);
        }
    }
}
