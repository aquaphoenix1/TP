using System.Collections.Generic;

namespace TProject.Driver
{
    public class Fuel : Type
    {
        public static long CurrentMaxID { get; set; }
        public static List<List<object>> ListFuel { get; set; }
        public double Price { get; set; }

        public Fuel(string typeName, double price) : base(typeName)
        {
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
