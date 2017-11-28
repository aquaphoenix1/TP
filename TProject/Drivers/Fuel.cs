using System.Collections.Generic;
using System.Linq;

namespace TProject.Driver
{
    public class Fuel : Type
    {
        public static long CurrentMaxID { private get; set; }
        public static List<List<object>> ListFuel { get; set; }
        public double Price { get; set; }

        //Используется в "Работе с БД" для добавления.Даниил 
        public Fuel(string typeName, double price) : base(typeName)
        {
            var fuel = Fuel.ListFuel.Select(i => i[0]).Max();
            if (fuel == null) { CurrentMaxID = 0; } else { CurrentMaxID = int.Parse(fuel.ToString()); }
            this.ID = ++CurrentMaxID;
            this.Price = price;
        }
        //Используется в "Работе с БД" для изменения - так как нужно найти соот-щую запись.Даниил
        public Fuel(int id, string typeName, double price)
        {
            this.ID = id;
            this.TypeName = typeName;
            this.Price = price;
        }       
    }
}
