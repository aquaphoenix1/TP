using System.Collections.Generic;
using System.Linq;

namespace TProject.Driver
{
    public class Fuel : Type
    {
        public static long CurrentMaxID { get; set; }
        public static List<List<object>> ListFuel { get; set; }
        public double Price { get; set; }
        
        public Fuel(string typeName, double price) : base(typeName)
        {
            var fuel = Fuel.ListFuel.Select(i => i[0]).Max();
            if (fuel == null) { CurrentMaxID = 0; } else { CurrentMaxID = int.Parse(fuel.ToString()); }
            this.ID = ++CurrentMaxID;
            this.Price = price;
        }   
        
        private Fuel() { }

        public static Fuel CreateFuel(long id, string typeName, double price)
        {
            return new Fuel
            {
                ID = id,
                TypeName = typeName,
                Price = price
            };
        }
    }
}
