using System.Collections.Generic;

namespace TProject.Driver
{
    public class Driver
    {
        public static List<List<object>> ListDriver { get; set; }
        public Car Car { get; set; }
        public bool IsViolateTL { get; set; }
        public string FIO { get; set; }

        public Driver(string FIO, bool isViolateTL, Car car)
        {
            this.FIO = FIO;
            IsViolateTL = isViolateTL;
            Car = car;
        }

        private Driver() { }

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
