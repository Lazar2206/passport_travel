using Domen;
using Logika;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ZajednickaKomunikacija;

namespace ServerskaStrana
{
    public class ClientHandler
    {
        private Socket klijent;

        private JsonNetworkSerializer json;
        private bool kraj;
        public Korisnik prijavljeniKorisnik { get; set; }
        public ClientHandler(Socket klijent)
        {
            this.klijent = klijent;

            json = new JsonNetworkSerializer(klijent);

        }
        public void PošaljiPoruku(Poruka poruka)
        {
            json.PosaljiPoruku(poruka);
        }
        public Poruka PrimiPoruku()
        {
            return json.PrimiPoruku<Poruka>();
        }
        public void HandleClient()
        {
            try
            {
                kraj = false;
                while (!kraj)
                {

                    //primanje zahteva
                    Poruka zahtev = PrimiPoruku();
                    Poruka odgovor = new Poruka()
                    {
                        Object = new object(),
                    };
                    //obrada zahteva

                    switch (zahtev.Operacija)
                    {
                        case Operacija.Login:
                            Korisnik korisnik1 = json.ReadType<Korisnik>(zahtev.Object);
                            if (Kontroler.Instance.Login(korisnik1))
                            {
                                odgovor.Operacija = Operacija.Uspesno;
                                prijavljeniKorisnik = korisnik1;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspesno;
                            }
                            //slanje odgovora
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.Register:
                            Korisnik korisnik2 = json.ReadType<Korisnik>(zahtev.Object);
                            Kontroler.Instance.DodajKorisnika(korisnik2);
                                odgovor.Operacija = Operacija.Uspesno;
                                //slanje odgovora
                                PošaljiPoruku(odgovor);
                                break;
                        case Operacija.ScheduleTrip:
                            PrijavljenaPutovanja prijava1 = json.ReadType<PrijavljenaPutovanja>(zahtev.Object);
                            Kontroler.Instance.PrijaviPutovanje(prijava1);
                            odgovor.Operacija = Operacija.Uspesno;
                            //slanje odgovora
                            PošaljiPoruku(odgovor);
                            break;
                             case Operacija.DeleteTrip:
                            PrijavljenaPutovanja prijava2 = json.ReadType<PrijavljenaPutovanja>(zahtev.Object);
                            Kontroler.Instance.DeleteTrip(prijava2);
                            odgovor.Operacija = Operacija.Uspesno;
                            //slanje odgovora
                            PošaljiPoruku(odgovor);
                            break;
                             case Operacija.ChangeTrip:
                            PrijavljenaPutovanja prijava3 = json.ReadType<PrijavljenaPutovanja>(zahtev.Object);
                            Kontroler.Instance.AzurirajPutovanje(prijava3);
                            odgovor.Operacija = Operacija.Uspesno;
                            //slanje odgovora
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.Logout:
                            Logout();
                            break;
                       


                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>>CH je prestao sa radom: " + ex.Message);
            }
            //primanje zahteva


            //obrada zahteva

            //slanje odgovora
            //
        }
        public void Logout()
        {
            kraj = true;
            Kontroler.Instance.Logout(prijavljeniKorisnik);
            klijent.Close(); //stavimo kursor alt i možemo da pomerimo liniju koda
        }
    }
}
