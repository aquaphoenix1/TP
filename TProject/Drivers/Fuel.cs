using System.Collections.Generic;

namespace TProject.Driver
{
    public class Fuel : Type
    {
        public static List<List<object>> ListFuel { get; set; }
        public double Price { get; set; }

        public Fuel(string typeName, double price) : base(typeName)
        {
            this.Price = price;
        }

        private Fuel() { }

        public static Fuel CreateFuel(string typeName, double price)
        {
            return new Fuel
            {
                TypeName = typeName,
                Price = price
            };
        }
    }
}
