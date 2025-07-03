﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace ServerskaStrana
{
    public class Server
    {
        private Socket socket; //osluškujući socket
        private List<ClientHandler> clientHandlers = new List<ClientHandler>();
        private bool kraj;

        public void start()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
            socket.Bind(iPEndPoint);

            socket.Listen(10); //koliko ljudi ODJEDNOM može da uđe u poštu
                               //NIKAKO da kažemp da je maksimalan broj klijenata

        }

        public void Accept()
        {
            try
            {
                kraj = false;
                while (!kraj) //beskonačna petlja -problemčić
                {
                    Debug.WriteLine("Čekam klijenta da se poveže");
                    Socket klijent = socket.Accept(); //prihvatili smo klijenta
                    Debug.WriteLine("Uspešno povezivanje sa klijetom");
                    //obrada zahteva 

                    ClientHandler ch = new ClientHandler(klijent);
                    clientHandlers.Add(ch);
                    Thread nit = new Thread(ch.HandleClient);
                    nit.Start();

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Server je prestao sa radom: " + ex.Message);
            }
        }
        public void Logout(Korisnik k)
        {
            foreach (ClientHandler ch in clientHandlers)
            {
                if (k.Username.Equals(ch.prijavljeniKorisnik.Username) && k.Password.Equals(ch.prijavljeniKorisnik.Password))
                {
                    ch.Logout();
                    clientHandlers.Remove(ch);
                    return;
                }
            }
        }
        public void Stop()
        {
            //odjavljivanje svih klijenata
            foreach (ClientHandler ch in clientHandlers)
            {
                ch.Logout();
            }
            clientHandlers = new List<ClientHandler>();
            //zaustavljanje servera
            kraj = true;
            socket.Close();

        }
    }
}
