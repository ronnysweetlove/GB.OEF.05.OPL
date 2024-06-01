using Dapper;
using GB.OEF._05.CL.Entiteit;
using System.Data.SqlClient;

namespace GB.OEF._05.CL.Container
{
    public class ParamContainer
    {
        public List<Parameter> Lijst = new List<Parameter>();

        public ParamContainer()
        {
            string dbSql = @"SELECT *
                                FROM parameter
                                ORDER BY snelheid";

            using (SqlConnection connection = new SqlConnection(Helper.Helper.GetConnectionString()))
            {
                connection.Open();
                Lijst = connection.Query<Parameter>(dbSql).ToList();
                connection.Close();
            }
        }
        public List<Parameter> ParameterLijst()
        {
            return Lijst;
        }

        public int ParameterIndex(int paramID)
        {
            return Lijst.FindIndex(p => p.ParamID == paramID);
        }
    }
}
