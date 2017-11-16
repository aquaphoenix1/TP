using System.Collections.Generic;

namespace TProject.Driver
{
    public class Car : Type
    {
        public static List<List<object>> ListAuto { get; set; }
        public Fuel CarFuel { get; set; }
        public string Model { get; set; }
        public double FuelConsumption { get; set; }

        public Car(string model, Fuel fuel, double consumption) : base(model)
        {
            CarFuel = fuel;
            Model = model;
            FuelConsumption = consumption;
        }
    }
}
