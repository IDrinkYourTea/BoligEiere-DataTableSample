using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using DataHusEier;
using DataTableSample;

namespace DataTableSample
{
    public class DBLayer
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["BoligEier"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        public List<BoligOgEier> GetAllDataFromEierAndHus()
        {
            try
            {
                List<BoligOgEier> EierHus = new List<BoligOgEier>();

                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT Eier.ID, Eier.Fornavn, Eier.Etternavn, Eier.Adresse, Eier.PostNR, Boligtype, Boligtype.BoligtypeID, Bolig.AntallSoverom, Bolig.AntallEtasjer, Bolig.Primerrom, Bolig.Bruksareal, Bolig.Tomteareal, Bolig.Byggeår, TelefonNR.TelefonNR FROM EierBolig INNER JOIN Eier ON Eier.ID = EierBolig.ID INNER JOIN Bolig ON Bolig.BoligID = EierBolig.BoligID INNER JOIN Boligtype ON Boligtype.BoligtypeID = Bolig.BoligtypeID INNER JOIN TelefonNR ON TelefonNR.ID = Eier.ID ORDER BY Eier.ID", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BoligOgEier ehd = new BoligOgEier();
                    ehd.ID = (int)reader["ID"];
                    ehd.Fornavn = (string)reader["Fornavn"];
                    ehd.Etternavn = (string)reader["Etternavn"];
                    ehd.Adresse = (string)reader["Adresse"];
                    ehd.PostNR = (int)reader["PostNR"];
                    ehd.Boligtype = (string)reader["Boligtype"];
                    ehd.BoligtypeID = (int)reader["BoligtypeID"];
                    ehd.AntallSoverom = (int)reader["AntallSoverom"];
                    ehd.AntallEtasjer = (int)reader["AntallEtasjer"];
                    ehd.Primerrom = (int)reader["Primerrom"];
                    ehd.Bruksareal = (int)reader["Bruksareal"];
                    ehd.Tomteareal = (int)reader["Tomteareal"];
                    ehd.Byggeår = (int)reader["Byggeår"];
                    ehd.TelefonNR = (int)reader["Telefonnr"];
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
        public DataTable GetBoligAndOwners()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["HusOgEier"].ConnectionString;
            DataTable dt=new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //den samme sql queryen her som dere allerede har testet i sql manager - her med et parameter, som er telefonnummeret
                SqlCommand cmd = new SqlCommand("SELECT Eier.ID, Eier.Fornavn, Eier.Etternavn, Eier.Adresse, Eier.PostNR, Bolig.BoligID, Bolig.AntallSoverom, Bolig.AntallEtasjer, Bolig.Primerrom, Bolig.Bruksareal, Bolig.Tomteareal, Bolig.Byggeår, Boligtype.Boligtype, TelefonNR.TelefonNR\r\nFROM EierBolig\r\nINNER JOIN Eier ON Eier.ID = EierBolig.ID\r\nINNER JOIN Bolig ON Bolig.BoligID = EierBolig.BoligID\r\nINNER JOIN Boligtype ON Boligtype.BoligtypeID = Bolig.BoligtypeID\r\nINNER JOIN TelefonNR ON TelefonNR.ID = Eier.ID\r\nORDER BY Eier.ID", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
               
                reader.Close();
                conn.Close();
            }
            return dt; //hele datasettet returneres. skal da kobles til feks en gridview
        }

        /// <summary>
        /// Returnerer alt fra tabellen boliger. Ikke hensiktsmessig om det er mange boliger.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBolig()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligEier"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Bolig", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
            return dt;
        }
public List<BoligOgEier> GetAllDataFromEierAndHusWhereTLFnr(int TextBoxTLFnr)
        {
            try
            {
                List<BoligOgEier> EierHus = new List<BoligOgEier>(); conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT Eier.ID, Eier.Fornavn, Eier.Etternavn, Eier.Adresse, Eier.PostNR, Boligtype, Boligtype.BoligtypeID, Bolig.AntallSoverom, Bolig.AntallEtasjer, Bolig.Primerrom, Bolig.Bruksareal, Bolig.Tomteareal, Bolig.Byggeår, TelefonNR.TelefonNR FROM EierBolig INNER JOIN Eier ON Eier.ID = EierBolig.ID INNER JOIN Bolig ON Bolig.BoligID = EierBolig.BoligID INNER JOIN Boligtype ON Boligtype.BoligtypeID = Bolig.BoligtypeID INNER JOIN TelefonNR ON TelefonNR.ID = Eier.ID WHERE TelefonNR = @tlf ORDER BY Eier.ID", conn); 
                cmd.Parameters.AddWithValue("tlf", TextBoxTLFnr); 
                SqlDataReader reader = cmd.ExecuteReader(); while (reader.Read())
                {
                    BoligOgEier ehd = new BoligOgEier();
                    ehd.ID = (int)reader["ID"];
                    ehd.Fornavn = (string)reader["Fornavn"];
                    ehd.Etternavn = (string)reader["Etternavn"];
                    ehd.Adresse = (string)reader["Adresse"];
                    ehd.PostNR = (int)reader["PostNR"];
                    ehd.Boligtype = (string)reader["Boligtype"];
                    ehd.BoligtypeID = (int)reader["BoligtypeID"];
                    ehd.AntallSoverom = (int)reader["AntallSoverom"];
                    ehd.AntallEtasjer = (int)reader["AntallEtasjer"];
                    ehd.Primerrom = (int)reader["Primerrom"];
                    ehd.Bruksareal = (int)reader["Bruksareal"];
                    ehd.Tomteareal = (int)reader["Tomteareal"];
                    ehd.Byggeår = (int)reader["Byggeår"];
                    ehd.TelefonNR = (int)reader["Telefonnr"];
                    EierHus.Add(ehd);
                }
                reader.Close();
                conn.Close(); return EierHus;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }


    }
}