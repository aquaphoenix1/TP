using System.Collections.Generic;

namespace TProject.Driver
{
    public class Car : Type
    {
        public static List<List<object>> ListAuto { get; set; }
        public Fuel CarFuel { get; set; }
        public double FuelConsumption { get; set; }
        public double Speed { get; set; }

        public Car(string model, Fuel fuel, double consumption, double speed) : base(model)
        {
            this.CarFuel = fuel;
            this.FuelConsumption = consumption;
            this.Speed = speed;
        }

        private Car() { }

        public static Car CreateCar(string model, Fuel fuel, double consumption, double speed)
        {
            return new Car
            {
                TypeName = model,
                CarFuel = fuel,
                FuelConsumption = consumption,
                Speed = speed
            };
        }
    }
}
