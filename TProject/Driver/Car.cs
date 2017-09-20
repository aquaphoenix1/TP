using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProject.Driver
{
    public class Car : Type
    {
        public Fuel CarFuel { get; set; }
        public int MaxSpeed { get; set; }
        public int FuelConsumption { get; set; }

        public Car(string brand, Fuel fuel, int maxSpeed, int consumption) : base(brand)
        {
            CarFuel = fuel;
            MaxSpeed = maxSpeed;
            FuelConsumption = consumption;
        }

    }

}
