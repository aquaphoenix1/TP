using System;
using System.Collections.Generic;
using System.Linq;

namespace TProject.Way
{
    public class Coating : Type
    {
        public static long CurrentMaxID { private get; set; }      
        public static List<List<object>> ListSurface { get; set; }
        public double Coeff { get; set; }

        //Используется в "Работе с БД" для добавления 
        public Coating(string typeName, double coefficient) : base(typeName)
        {
            var coating = Coating.ListSurface.Select(i => i[0]).Max();
            CurrentMaxID = int.Parse(coating.ToString());
            this.Coeff = coefficient;
            this.ID = ++CurrentMaxID;
        }

        //Используется в "Работе с БД" для изменения 
        public Coating(int id, string typeName, double coefficient) : base(typeName)
        {
            this.ID = id;
            this.Coeff = coefficient;
            this.TypeName = typeName;
        }

       /* public override string ToString()
        {
            return String.Format(TypeName +
                " c коэффициентом торможения: {0}", Coeff);
        }
        */
       
    }

}
