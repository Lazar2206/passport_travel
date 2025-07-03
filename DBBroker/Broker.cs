
using Azure;
using Domen;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Diagnostics;

namespace DBBroker
{
    public class Broker
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-J9SCJBQ\\SQLEXPRESS;Initial Catalog=Korisnik;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlTransaction tran;
        private static Broker instance;

        public static Broker Instance
        {
            get
            {
                if (instance == null)
                    instance = new Broker();
                return instance;
            }
        }
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
        public bool PraviDrzavljanin(string JMBG, string ime, string prezime, string pasos)
        {
            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Srbija WHERE JMBG = @JMBG and ime=@ime and prezime=@prezime and brojPasoša=@pasos";
                cmd.Parameters.AddWithValue("@JMBG", JMBG);
                cmd.Parameters.AddWithValue("@ime", ime);
                cmd.Parameters.AddWithValue("@prezime", prezime);
                cmd.Parameters.AddWithValue("@pasos", pasos);
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

            string upit = $"insert into Korisnici values('{korisnik.JMBG}','{korisnik.Ime}','{korisnik.Prezime}','{korisnik.Email}','{korisnik.Username}','{korisnik.Password}','{korisnik.brojPasoša}')";

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

        public void PrijaviPutovanje(PrijavljenaPutovanja prijava)
        {
            // Priprema upita
            string upit = @"INSERT INTO PrijavljenaPutovanja 
        (KorisnickoIme, KorisnickoPrezime, korisnikId, jmbg, brojPasoša, zemlja, datum_prijave, datum_ulaska, datum_izlaska,
         prevoz, brojDanaBoravka, platio, statusPrijave)
        VALUES
        (@Ime, @Prezime, @KorisnikId, @JMBG, @Pasos, @Zemlje, @DatumPrijave, @DatumUlaska, @DatumIzlaska,
         @Prevoz, @BrojDanaBoravka, @Platio, @Status)";

            try
            {
                PoveziSe();
                BeginTranscation();

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = tran;
                cmd.CommandText = upit;

                // Dodavanje parametara
                cmd.Parameters.AddWithValue("@Ime", prijava.Ime);
                cmd.Parameters.AddWithValue("@Prezime", prijava.Prezime);
                cmd.Parameters.AddWithValue("@KorisnikId", prijava.KorisnikId);
                cmd.Parameters.AddWithValue("@JMBG", prijava.JMBG);
                cmd.Parameters.AddWithValue("@Pasos", prijava.Pasoš);
                cmd.Parameters.AddWithValue("@Zemlje", string.Join(", ", prijava.Zemlje));
                cmd.Parameters.AddWithValue("@DatumPrijave", prijava.DatumPrijave);
                cmd.Parameters.AddWithValue("@DatumUlaska", prijava.DatumUlaska);
                cmd.Parameters.AddWithValue("@DatumIzlaska", prijava.DatumIzlaska);
                cmd.Parameters.AddWithValue("@Prevoz", prijava.Prevoz.ToString());
                cmd.Parameters.AddWithValue("@BrojDanaBoravka", prijava.BrojDanaBoravka);
                cmd.Parameters.AddWithValue("@Platio", prijava.Platio ? "Da" : "Ne");
                cmd.Parameters.AddWithValue("@Status", prijava.Status.ToString());

                cmd.ExecuteNonQuery();
                Commit();

                Debug.WriteLine(">>>>> Prijava uspešno sačuvana.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>> Greška prilikom čuvanja prijave: " + ex.Message);
                Rollback();
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }


        public Korisnik PronadjiKorisnika(string username, string password)
        {
            try
            {
                PoveziSe();
                // Pseudokod, prilagodi tvojoj implementaciji baze
                string upit = "SELECT * FROM Korisnici WHERE Username = @username AND Password = @password";

                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Korisnik
                    {
                        Id = (int)reader["Id"],
                        Ime = reader["Ime"].ToString(),
                        Prezime = reader["Prezime"].ToString(),
                        Email = reader["Email"].ToString(),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        JMBG = reader["JMBG"].ToString(),
                        brojPasoša = reader["BrojPasoša"].ToString()
                    };
                }

                return null;
            }
            finally
            {

                ZatvoriKonekciju();
            }
        }

        public List<PrijavljenaPutovanja> VratiPutovanja(string jmbg)
        {
            List<PrijavljenaPutovanja> putovanja = new List<PrijavljenaPutovanja>();
            string upit = "SELECT * FROM PrijavljenaPutovanja WHERE jmbg = @jmbg";

            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = upit;
                cmd.Parameters.AddWithValue("@jmbg", jmbg);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PrijavljenaPutovanja p = new PrijavljenaPutovanja()
                    {
                        Id = (int)reader["PrijavaId"],
                        KorisnikId = (int)reader["korisnikId"],
                        Ime = reader["KorisnickoIme"].ToString(),
                        Prezime = reader["KorisnickoPrezime"].ToString(),
                        JMBG = reader["jmbg"].ToString(),
                        Pasoš = reader["brojPasoša"].ToString(),
                        DatumPrijave = (DateTime)reader["datum_prijave"],
                        DatumUlaska = (DateTime)reader["datum_ulaska"],
                        DatumIzlaska = (DateTime)reader["datum_izlaska"],
                        Status = (StatusPrijave)Enum.Parse(typeof(StatusPrijave), (string)reader["statusPrijave"]),
                        Prevoz = (Prevoz)Enum.Parse(typeof(Prevoz), (string)reader["prevoz"]),
                        Zemlje = reader["zemlja"] != DBNull.Value
                                 ? reader["zemlja"].ToString().Split(',').Select(z => z.Trim()).ToList()
                                 : new List<string>(),
                        Platio = reader["platio"] != DBNull.Value &&
                        (reader["platio"].ToString().ToLower() == "da" || reader["platio"].ToString() == "1"),
                        BrojDanaBoravka = (int)reader["brojDanaBoravka"]

                    };

                    putovanja.Add(p);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>Greška u brokeru: " + ex.Message);
            }
            finally
            {
                ZatvoriKonekciju();
            }

            return putovanja;
       
         }

        public void AzurirajPutovanje(PrijavljenaPutovanja prijava)
        {
            string upit = @"
        UPDATE prijavljenaPutovanja SET 
            KorisnickoIme = @Ime,
            KorisnickoPrezime = @Prezime,
            jmbg = @JMBG,
            brojPasoša = @Pasos,
            datum_prijave = @DatumPrijave,
            datum_ulaska = @DatumUlaska,
            datum_izlaska = @DatumIzlaska,
            prevoz = @Prevoz,
            statusPrijave = @Status,
            platio = @Platio,
            brojDanaBoravka = @BrojDana
        WHERE prijavaId = @Id AND korisnikId = @KorisnikId";

            try
            {
                PoveziSe();
                BeginTranscation();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = upit;
                cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("@Ime", prijava.Ime);
                cmd.Parameters.AddWithValue("@Prezime", prijava.Prezime);
                cmd.Parameters.AddWithValue("@JMBG", prijava.JMBG);
                cmd.Parameters.AddWithValue("@Pasos", prijava.Pasoš);
                cmd.Parameters.AddWithValue("@DatumPrijave", prijava.DatumPrijave);
                cmd.Parameters.AddWithValue("@DatumUlaska", prijava.DatumUlaska);
                cmd.Parameters.AddWithValue("@DatumIzlaska", prijava.DatumIzlaska);
                cmd.Parameters.AddWithValue("@Prevoz", prijava.Prevoz.ToString());
                cmd.Parameters.AddWithValue("@Status", prijava.Status.ToString());
                cmd.Parameters.AddWithValue("@Platio", prijava.Platio ? "Da" : "Ne");
                cmd.Parameters.AddWithValue("@BrojDana", prijava.BrojDanaBoravka);
                cmd.Parameters.AddWithValue("@Id", prijava.Id);
                cmd.Parameters.AddWithValue("@KorisnikId", prijava.KorisnikId);

                int brojRedova = cmd.ExecuteNonQuery();
                Debug.WriteLine($"Ažurirano redova: {brojRedova}");

                Commit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Greska u brokeru: " + ex.Message);
                Rollback();
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }

        public void DeleteTrip(PrijavljenaPutovanja delete)
        {
            string upit = $"DELETE FROM PrijavljenaPutovanja WHERE prijavaId={delete.Id}";
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
            catch (Exception ex)
            {

                Debug.WriteLine(">>>>>>Greska u brokeru: " + ex.Message);
                Rollback();
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }

        public bool BrojPasosaPostoji(String pasos)
        {
            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Korisnici WHERE brojPasoša = @brojPasoša";
                cmd.Parameters.AddWithValue("@brojPasoša", pasos);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }

        public bool PostojiRegKorisnik(string jmbg, string pasos)
        {
            try
            {
                PoveziSe();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Korisnici WHERE brojPasoša = @brojPasoša or jmbg=@jmbg";
                cmd.Parameters.AddWithValue("@brojPasoša", pasos);
                cmd.Parameters.AddWithValue("@jmbg", jmbg);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            finally
            {
                ZatvoriKonekciju();
            }
        }
    }
}
