namespace GB.OEF._05.CL.Entiteit
{
    public class Dagboek
    {
        public int DbID { get; set; }
        public DateTime Datum { get; set; }
        public int Gewicht { get; set; }
        public int Tijd { get; set; }
        public int ParamID { get; set; }

        public Dagboek(int dbID, DateTime datum, int gewicht, int tijd, int paramID)
        {
            DbID = dbID;
            Datum = datum;
            Gewicht = gewicht;
            Tijd = tijd;
            ParamID = paramID;
        }
    }
}
