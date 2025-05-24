using System.Runtime;

namespace Domen
{
    public class Korisnik
    {
        public int Id { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Email { get; set; }
        public String Username{ get; set; }
        public String Password{ get; set; }
        public String JMBG { get; set; }
        public String brojPasoša { get; set; }
        public List<PrijavljenaPutovanja> Prijave { get; set; }

    }

}
