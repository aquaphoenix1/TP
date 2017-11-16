using System.Collections.Generic;

namespace TProject.Driver
{
    public class Fuel : Type
    {
        public static List<List<object>> ListFuel { get; set; }
        public double Price { get; }

        public Fuel(string typeName, double price) : base(typeName)
        {
            Price = price;
        }
    }
}
