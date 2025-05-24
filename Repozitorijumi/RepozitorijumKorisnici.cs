using Domen;

namespace Repozitorijumi
{
    public class RepozitorijumKorisnici
    {
        private List<Korisnik> korisnici = new List<Korisnik>();
        public RepozitorijumKorisnici()
        { 
            Korisnik k1 = new Korisnik
            {
                Username = "ana",
                Password = "ana"

            };
            korisnici.Add(k1);
            Korisnik k2 = new Korisnik
            {
                Username = "laki",
                Password = "laki"

            };
            korisnici.Add(k2);
            Korisnik k3 = new Korisnik
            {
                Username = "mama",
                Password = "mama"

            };
            korisnici.Add(k3);
           

        }


        public List<Korisnik> vratiKorisnike()
        {
            return korisnici;
        }
    }
}
