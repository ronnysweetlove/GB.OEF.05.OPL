using Dapper;
using GB.OEF._05.CL.Entiteit;
using System.Data.SqlClient;

namespace GB.OEF._05.CL.Container
{
    public class DagboekContainer
    {
        public List<DagboekItem> DagboekItemsLijst()
        {
            List<DagboekItem> lijst = new List<DagboekItem>();

            string dbSql = @"SELECT dbID,
                                FORMAT(d.datum, 'dd-MM-yyyy') AS datum, 
                                ROUND((p.param1 * gewicht + p.param2) * tijd / 60, 0) AS kcal
                                FROM dagboek d
                                JOIN parameter p
                                ON d.paramID = p.paramID
                                ORDER BY d.datum ASC";

            using (SqlConnection connection = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                connection.Open();
                lijst = connection.Query<DagboekItem>(dbSql).ToList();
                connection.Close();
            }

            return lijst;
        }

        public int Totaal()
        {
            int totaal = 0;

            string dbSql = @"SELECT SUM(ROUND((p.param1 * gewicht + p.param2) * tijd / 60, 0))
                             FROM dagboek d
                             JOIN parameter p
                               ON d.paramID = p.paramID";

            using (SqlConnection connection = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                connection.Open();
                totaal = connection.ExecuteScalar<int>(dbSql);
                connection.Close();
            }

            return totaal;
        }

        public Dagboek DagboekObject(int dagboekID)
        {
            Dagboek oDagboek = null;

            string dbSql = "SELECT * FROM dagboek WHERE dbID = @dbID";

            using (SqlConnection connection = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                connection.Open();
                oDagboek = connection.QueryFirst<Dagboek>(dbSql, new { dbID = dagboekID });
                connection.Close();
            }

            return oDagboek;
        }

        public void Nieuw(Dagboek oDagboek)
        {
            string dbSql = "INSERT INTO dagboek(datum,gewicht,tijd,paramID) VALUES(@datum,@gewicht,@tijd,@paramID)";

            using (SqlConnection connection = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                connection.Open();
                connection.Execute(dbSql, oDagboek);
                connection.Close();
            }
        }

        public void Wijzig(Dagboek oDagboek)
        {
            string dbSql = "UPDATE dagboek set datum=@datum, gewicht=@gewicht, tijd=@tijd, paramID=@paramID WHERE dbID=@DbID";

            using (SqlConnection connection = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                connection.Open();
                connection.Execute(dbSql, oDagboek);
                connection.Close();
            }
        }

        public void Verwijder(Dagboek oDagboek)
        {
            string dbSql = "DELETE FROM dagboek WHERE DBid = @dbID";

            using (SqlConnection connection = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                connection.Open();
                connection.Execute(dbSql, oDagboek);
                connection.Close();
            }
        }
    }
}
