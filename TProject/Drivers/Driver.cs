using System.Collections.Generic;

namespace TProject.Driver
{
    public class Driver
    {
        /// <summary>
        /// Список всех водителей
        /// </summary>
        public static List<List<object>> ListDriver { get; set; }

        public Car Car { get; set; }

        /// <summary>
        /// Нарушитель
        /// </summary>
        public bool IsViolateTL { get; set; }

        public string FIO { get; set; }

        /// <summary>
        /// Создание водителя
        /// </summary>
        /// <param name="FIO">ФИО</param>
        /// <param name="isViolateTL">Нарушитель</param>
        /// <param name="car">Автомобиль</param>
        public Driver(string FIO, bool isViolateTL, Car car)
        {
            this.FIO = FIO;
            IsViolateTL = isViolateTL;
            Car = car;
        }

        private Driver() { }

        /// <summary>
        /// Создание водителя
        /// </summary>
        /// <param name="FIO">ФИО</param>
        /// <param name="isViolateTL">Нарушитель</param>
        /// <param name="car">Автомобиль</param>
        /// <returns>Водитель</returns>
        public static Driver CreateDriver(string FIO, bool isViolateTL, Car car)
        {
            return new Driver
            {
                FIO = FIO,
                Car = car,
                IsViolateTL = isViolateTL
            };
        }
    }
}
