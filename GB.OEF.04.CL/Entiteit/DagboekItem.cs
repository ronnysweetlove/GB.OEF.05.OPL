namespace GB.OEF._05.CL.Entiteit
{
    public class DagboekItem
    {
        public int DbID { get; set; }
        public string Datum { get; set; }
        public double KCal { get; set; }

        public DagboekItem(int dbID, string datum, double kcal)
        {
            DbID = dbID;
            Datum = datum;
            KCal = kcal;
        }

        public override string ToString()
        {
            return $"{Datum} \t {KCal}kCal";
        }
    }
}
