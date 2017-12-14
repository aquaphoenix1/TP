using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    public class Coating : Type
    {
        public static List<List<object>> ListSurface { get; set; }
        public double Coeff { get; set; }

        public Coating(string typeName, double coefficient) : base(typeName)
        {
            this.Coeff = coefficient;
        }

        private Coating() { }

        public static Coating CreateCoating(string typeName, double coefficient)
        {
            return new Coating
            {
                Coeff = coefficient,
                TypeName = typeName
            };
        }

        internal static Coating GetCoatingByName(string name)
        {
            List<object> coat = ListSurface.First(coating => coating[0].ToString().Equals(name));

            return CreateCoating(coat[0].ToString(), double.Parse(coat[1].ToString()));
        }
    }
}
