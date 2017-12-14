using System.Collections.Generic;

namespace TProject.Driver
{
    public class Car : Type
    {
        /// <summary>
        /// Список всех автомобилей
        /// </summary>
        public static List<List<object>> ListAuto { get; set; }

        public Fuel CarFuel { get; set; }

        public double FuelConsumption { get; set; }

        public double Speed { get; set; }

        /// <summary>
        /// Создание автомобиля
        /// </summary>
        /// <param name="model">Модель</param>
        /// <param name="fuel">Топливо</param>
        /// <param name="consumption">Потребление топлива</param>
        /// <param name="speed">Скорость автомобиля</param>
        public Car(string model, Fuel fuel, double consumption, double speed) : base(model)
        {
            this.CarFuel = fuel;
            this.FuelConsumption = consumption;
            this.Speed = speed;
        }

        private Car() { }

        /// <summary>
        /// Создание автомобиля. Фабрика.
        /// </summary>
        /// <param name="model">Модель</param>
        /// <param name="fuel">Топливо</param>
        /// <param name="consumption">Потребление топлива</param>
        /// <param name="speed">Скорость автомобиля</param>
        /// <returns>Автомобиль</returns>
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
