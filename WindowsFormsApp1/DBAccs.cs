using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{   
    
    class DBAccs
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private static string korisnikTEMP;
        public DBAccs()
        {
            Initialize();
        }

        
        private void Initialize()
        {
            server = "localhost";
            database = "world";
            uid =  "root";
            password = "tempPW";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public string KorisnikTEMP {
            get
            {
                return korisnikTEMP;
            }
        }
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void InsertKorisnik(string Username, string Password, string Ime, string Prezime)
        {
            string query = "INSERT INTO korisnici (Username, Password, Ime, Prezime) VALUES ('"+Username+"',SHA('"+Password+"'),'"+Ime+"','"+Prezime+"');";
            MySqlCommand cmd = new MySqlCommand(query, connection);


            cmd.ExecuteNonQuery();
        }

        
        public void Insert(string Marka, string Model, string Kvar, string ImePrezime, string BrojTelefona, string IMEI, string Serviser, string Cena)
        {   
            
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            
            string query = "INSERT INTO kvarovi (Marka, Model, Kvar, ImePrezime, BrojTelefona, IMEI, Serviser, Cena, Korisnik, Datum) VALUES('"+Marka+"','"+Model+"','"+Kvar+"','"+ImePrezime+"','"+BrojTelefona+"','"+IMEI+"','"+Serviser+"','"+Cena+"','"+korisnikTEMP+"','"+sqlFormattedDate+"');";
            
            
                
                MySqlCommand cmd = new MySqlCommand(query, connection);

                
                cmd.ExecuteNonQuery();

                
                
            
        }

        
        public void Update(string tipizmene, string vrednostizmene, string pretragaizmene, string vrednostpretrage)
        {
            string query = "UPDATE `kvarovi` SET `"+tipizmene+"`= '"+vrednostizmene+"' WHERE  `"+pretragaizmene+"`='"+vrednostpretrage+"';";
            MySqlCommand cmd = new MySqlCommand(query, connection);


            cmd.ExecuteNonQuery();
        }
        
        public bool GetUser(string username, string password)
        {
            
            string query = "SELECT COUNT(*) FROM korisnici WHERE username = '"+username+"' && password = SHA('"+password+"');";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            int check = Convert.ToInt32(cmd.ExecuteScalar());
            korisnikTEMP = username;
            if (check > 0)
            {
                MessageBox.Show("Uspesno ste se prijavili");
                return true;
                
            }

            else
            {
                MessageBox.Show("Pogresan unos");
                return false;
            }            
        } 
        
        public MySqlDataAdapter Search(string tip,string vrednost )
        {
            string query = "SELECT * FROM `kvarovi` WHERE " + tip + " LIKE " + "'" +vrednost+ "%'"+";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter pretraga = new MySqlDataAdapter(cmd);
            return pretraga;

        }
        public void Delete(int sifrabrisanja)
        {
            
            
                string query = "DELETE FROM `kvarovi` WHERE  `sifra`=" + sifrabrisanja + ";";
                MySqlCommand cmd = new MySqlCommand(query, connection);


                cmd.ExecuteNonQuery();
            
        }
        public MySqlDataAdapter Adapter()
        {   
            string query = "SELECT * FROM kvarovi;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            return adap;
        }
        public MySqlDataAdapter AdapterKorisnik()
        {
            string query = "SELECT * FROM korisnici;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            return adap;
        }
        public int Privilegije()
        {
            string query = "SELECT `FLAG` from `korisnici` WHERE `username` = '" + korisnikTEMP + "';";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            return Convert.ToInt32(cmd.ExecuteScalar()); ;
        }
        public int Provera(string korisnikchild)
        {
            string query = "SELECT COUNT(*) from `korisnici` WHERE `username` = '" + korisnikchild + "';";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            return Convert.ToInt32(cmd.ExecuteScalar()); ;
        }


        public void Backup()
        {
        }

        
        public void Restore()
        {
        }
    

}
}
