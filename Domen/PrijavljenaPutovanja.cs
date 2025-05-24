namespace Domen
{
    public class PrijavljenaPutovanja
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        public string Zemlja { get; set; }
        public DateTime DatumPrijave { get; set; }
        public DateTime DatumUlaska { get; set; }
        public DateTime DatumIzlaska { get; set; }
        public Prevoz Prevoz { get; set; }
        public StatusPrijave Status { get; set; }
        public bool Platio { get; set; }
    }

}
