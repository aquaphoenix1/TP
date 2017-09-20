using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProject.Driver
{
    public class Fuel : Type
    {
        public double Price { get; }

        public Fuel(string typeName, double price):base(typeName)
        {
            Price = price;
        }
    }
}
