using DBBroker;
using Domen;
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

        public bool JmbgPostoji(string JMBG)
        {
            return broker.JmbgPostoji(JMBG);
        }
    }
}
