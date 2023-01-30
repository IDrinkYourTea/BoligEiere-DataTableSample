namespace Data
{
    public class BoligOgEier
    {
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public int PostNR { get; set; }
        public int TelefonNR { get; set; }
        public int Boligtype { get; set; }
        public int AntallSoverom { get; set; }
        public int AntallEtasjer { get; set; }
        public int Primerrom { get; set; }
        public int Bruksareal { get; set; }
        public int Tomteareal { get; set; }
        public int Byggeår { get; set; }
    }
}