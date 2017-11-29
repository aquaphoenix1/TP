using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    public class Coating : Type
    {
        public static long CurrentMaxID { get; set; }
        public static List<List<object>> ListSurface { get; set; }
        public double Coeff { get; set; }

        public Coating(string typeName, double coefficient) : base(typeName)
        {
            var coating = Coating.ListSurface.Select(i => i[0]).Max();
            if (coating == null)
            { CurrentMaxID = 0; }
            else
            { CurrentMaxID = int.Parse(coating.ToString()); }
            this.Coeff = coefficient;
            this.ID = ++CurrentMaxID;
        }

        private Coating() { }

        public static Coating CreateCoating(long id, string typeName, double coefficient)
        {
            return new Coating
            {
                ID = id,
                Coeff = coefficient,
                TypeName = typeName
            };
        }
    }
}
