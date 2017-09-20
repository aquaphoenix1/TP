using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProject.Way
{
    public class Coating : Type
    {
        public static List<Coating> collection;

        public double Coeff { get; set; }

        public static void Init() { }

        static Coating()
        {
            collection = new List<Coating>();
            collection.Add(new Coating("Асфальтовое покрытие", 1));
            collection.Add(new Coating("Грунтовка покрытие", 0.4));
            collection.Add(new Coating("Бетон", 0.8));
            collection.Add(new Coating("Щебень", 0.2));
        }

        public Coating(string typeName, double coefficient):base(typeName)
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
