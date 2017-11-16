using System;
using System.Collections.Generic;

namespace TProject.Way
{
    public class Coating : Type
    {
        public static List<List<object>> ListSurface { get; set; }

        public double Coeff { get; set; }

        public Coating(string typeName, double coefficient) : base(typeName)
        {
            Coeff = coefficient;
        }

        public override string ToString()
        {
            return String.Format(TypeName +
                " c коэффициентом торможения: {0}", Coeff);
        }
    }

}
