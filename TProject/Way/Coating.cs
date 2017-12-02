using System.Collections.Generic;

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
    }
}
