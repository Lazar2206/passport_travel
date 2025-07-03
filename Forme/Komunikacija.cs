using Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ZajednickaKomunikacija;

namespace Forme
{
    public class Komunikacija
    {
        private Socket socket; //pošta
        private JsonNetworkSerializer json;

        public bool PoveziSe()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("127.0.0.1", 9000);
                Debug.WriteLine("Uspešno povezivanje sa serverom");
                json = new JsonNetworkSerializer(socket);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Nespešno povezivanje sa serverom" + ex.Message);
                return false;

            }
        }
        public void PošaljiPoruku(Poruka poruka)
        {
            try
            {
                json.PosaljiPoruku(poruka);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>Server je prestao a radom: " + ex.Message);
                socket.Close();
                throw ex;
            }
        }
        public Poruka PrimiPoruku()
        {
            try
            {
                return json.PrimiPoruku<Poruka>();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>>Server je prestao sa radom: " + ex.Message);
                socket.Close();
                throw ex;
            }
        }
        public T ReadType<T>(Object podaci)
        {
            return json.ReadType<T>(podaci);
        }

        public void Logout()
        {
            Poruka zahtev = new Poruka()
            {
                Object = new object(),
                Operacija = Operacija.Logout
            };
            PošaljiPoruku(zahtev);


            socket.Close();
        }
    }
}
