using Dapper.Contrib.Extensions;

namespace GB.OEF._05.CL.Entiteit
{
    public class Parameter
    {
        [ExplicitKey]
        public int ParamID { get; set; }
        public int Snelheid { get; set; }
        public Single Param1 { get; set; }
        public Single Param2 { get; set; }

        public Parameter(int paramID, int snelheid, Single param1, Single param2)
        {
            ParamID = paramID;
            Snelheid = snelheid;
            Param1 = param1;
            Param2 = param2;
        }

        public override string ToString()
        {
            return $"{Snelheid} km/u";
        }
    }
}
