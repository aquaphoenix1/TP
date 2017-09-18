namespace TProject
{
    class Driver : Entity
    {
        public Car DriverCar { get; set; }

        public class Car : Entity
        {
            public Fuel CarFuel { get; set; }

            public class Fuel : Entity, Type
            {
                public string Type { get; set; }
                public double Price { get; }

                public Fuel(string type, double price)
                {
                    this.Type = type;
                    this.Price = price;
                }
            }

            public Car(Fuel fuel, int id)
            {
                this.CarFuel = CarFuel;
                this.ID = id;
            }
        }

        public Driver(Car car, int id)
        {
            this.DriverCar = car;
            this.ID = id;
        }
    }
}
