using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHusEier
{
    public class BoligOgEier
    {
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public int PostNR { get; set; }
        public int TelefonNR { get; set; }
        public string Boligtype { get; set; }
        public int AntallSoverom { get; set; }
        public int AntallEtasjer { get; set; }
        public int Primerrom { get; set; }
        public int Bruksareal { get; set; }
        public int Tomteareal { get; set; }
        public int Byggeår { get; set; }
        public int BoligtypeID { get; set; }
    }
}
