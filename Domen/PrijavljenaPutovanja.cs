namespace Domen
{
    public class PrijavljenaPutovanja
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public Korisnik korisnik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public String Pasoš { get; set; }
        public String JMBG { get; set; }
        public List<string> Zemlje {  get; set; }
        public string ZemljeTekst => Zemlje != null ? string.Join(", ", Zemlje) : "";
        public int BrojDanaBoravka { get; set; }
        public DateTime DatumPrijave { get; set; }
        public DateTime DatumUlaska { get; set; }
        public DateTime DatumIzlaska { get; set; }
        public Prevoz Prevoz { get; set; }
        public StatusPrijave Status { get; set; }
        public bool Platio { get; set; }
    }

}
