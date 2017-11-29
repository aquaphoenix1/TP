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

        private Police() { }

        public static Police CreatePolice(long id, string typeName, double coefficient)
        {
            Police police = new Police
            {
                ID = id,
                TypeName = typeName,
                Coeff = coefficient
            };

            return police;
        }
    }
}
