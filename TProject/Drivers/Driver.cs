using System.Collections.Generic;

namespace TProject.Driver
{
    class Driver : Entity
    {
        public static List<List<object>> ListDriver { get; set; }
        public Car Car { get; set; }
        public bool IsViolateTL { get; set; }

        public Driver(bool isViolateTL, Car car)
        {
            IsViolateTL = isViolateTL;
            Car = car;
        }
    }
}
