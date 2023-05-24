using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using DataKlasse;
using DataTableSample;

namespace DataTableSample
{
    public class DBLayer
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionKlasse"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        public List<Elever> GetAllDataFromElever()
        {
            try
            {
                List<Elever> EierHus = new List<Elever>();

                 conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT Elev.ElevID, Fornavn, Etternavn, Adresse, Elev.PostNr, Poststeder.Poststed, Klasse.KlasseNavn\r\nFrom Elev\r\nINNER JOIN Poststeder ON Poststeder.PostNr = Elev.PostNr\r\nINNER JOIN Klasse ON Klasse.KlasseID = Elev.KlasseID", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Elever ehd = new Elever();
                    ehd.ElevID = (int)reader["ElevID"];
                    ehd.Fornavn = (string)reader["Fornavn"];
                    ehd.Etternavn = (string)reader["Etternavn"];
                    ehd.Adresse = (string)reader["Adresse"];
                    ehd.PostNR = (int)reader["PostNR"];
                    ehd.KlasseNavn = (string)reader["KlasseNavn"];
                    ehd.FagNavn = (string)reader["FagNavn"];
                    EierHus.Add(ehd);
                }
                reader.Close();
                conn.Close();

                return EierHus;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }
        public DataTable GetElev(string Fornavn)
        {
            SqlParameter param;
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionKlasse"].ConnectionString;
            DataTable dt=new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //den samme sql queryen her som dere allerede har testet i sql manager - her med et parameter, som er telefonnummeret
                SqlCommand cmd = new SqlCommand("SELECT Elev.ElevID, Fornavn, Etternavn, Adresse, Elev.PostNr, Poststeder.Poststed, Klasse.KlasseNavn\r\nFrom Elev\r\nINNER JOIN Poststeder ON Poststeder.PostNr = Elev.PostNr\r\nINNER JOIN Klasse ON Klasse.KlasseID = Elev.KlasseID", conn);
                cmd.CommandType = CommandType.Text;
                param = new SqlParameter("@ForNavn", SqlDbType.NVarChar);
                cmd.Parameters.Add(param);
                param.Value = Fornavn;

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
               
                reader.Close();
                conn.Close();
            }
            return dt; //hele datasettet returneres. skal da kobles til feks en gridview
        }
    }
}