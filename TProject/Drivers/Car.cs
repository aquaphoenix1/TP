using System.Collections.Generic;

namespace TProject.Driver
{
    public class Car : Type
    {
        public static long CurrentMaxID { get; set; }
        public static List<List<object>> ListAuto { get; set; }
        public Fuel CarFuel { get; set; }
        public double FuelConsumption { get; set; }

        public Car(string model, Fuel fuel, double consumption) : base(model)
        {
            this.ID = ++CurrentMaxID;
            this.CarFuel = fuel;
            this.FuelConsumption = consumption;
        }

        private Car() { }

        public static Car CreateCar(long id, string model, Fuel fuel, double consumption)
        {
            return new Car
            {
                ID = id,
                TypeName = model,
                CarFuel = fuel,
                FuelConsumption = consumption
            };
        }
    }
}
