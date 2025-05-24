
using Azure;
using Domen;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace DBBroker
{
    public class Broker
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-J9SCJBQ\\SQLEXPRESS;Initial Catalog=Korisnik;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlTransaction tran;

        public void PoveziSe()
        {
            con.Open();
            Debug.WriteLine(">>>>Uspesno povezivanje sa bazom");
        }

        public void ZatvoriKonekciju()
        {
            con.Close();
            Debug.WriteLine(">>>Uspesno zatvaranje konekcije sa bazom");
        }
        public void BeginTranscation()
        {
            tran = con.BeginTransaction();
        }

        public void Commit()
        {
            tran.Commit();
        }

        public void Rollback()
        {
            tran.Rollback();
        }

        public bool UsernamePostoji(string username)
        {
            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Korisnici WHERE username = @username";
                cmd.Parameters.AddWithValue("@username", username);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }
        public bool JmbgPostoji(string JMBG)
        {
            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Korisnici WHERE JMBG = @JMBG";
                cmd.Parameters.AddWithValue("@JMBG", JMBG);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }
        public void DodajKorisnika(Korisnik korisnik)
        {
            if (UsernamePostoji(korisnik.Username))
            {
                Debug.WriteLine(">>>>> Korisnicko ime vec postoji");
                return; // ili izbaci izuzetak ako želiš da signaliziraš pozivaocu
            }

            string upit = $"insert into Korisnici values('{korisnik.Ime}','{korisnik.Prezime}','{korisnik.Email}','{korisnik.Username}','{korisnik.Password}','{korisnik.JMBG}','{korisnik.brojPasoša}')";

            try
            {
                PoveziSe();
               BeginTranscation();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = upit;
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                Commit();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                Debug.WriteLine(">>>>> Korisnicko ime vec postoji - SQL constraint.");
                Rollback();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>> Greska u brokeru: " + ex.Message);
                Rollback();
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }
        public List<Korisnik> VratiSveKorisnike()
        {
            List<Korisnik> korisnici = new List<Korisnik>();
            string upit = "select* from Korisnici";
            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = upit;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Korisnik p = new Korisnik()
                    {
                        Ime = (string)reader["ime"],
                      Prezime = (string)reader["prezime"],
                       Email = (string)reader["email"],
                      Username = (string)reader["username"],
                       Password = (string)reader["Password"],
                      JMBG = (string)reader["jmbg"],
                        brojPasoša = (string)reader["brojPasoša"]
                    };
                    korisnici.Add(p);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>>>>Greska u brokeru: " + ex.Message);
            }
            finally
            {
                ZatvoriKonekciju();
            }



            return korisnici;

        }
    }
}
