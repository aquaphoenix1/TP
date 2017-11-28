using System.Collections.Generic;

namespace TProject.Way
{
    public class Police : Type
    {
        public static long CurrentMaxID { get; set; }
        public static List<List<object>> ListTypePolicemen { get; set; }
        public double Coeff { get; set; }

        public Police(string typeName, double coefficient) : base(typeName)
        {
            this.ID = ++CurrentMaxID;
            this.Coeff = coefficient;
        }
    }
}
