using System.Collections.Generic;
using System.Linq;

namespace TProject.Driver
{
    class Driver : Entity
    {
        public static long CurrentMaxID { get; set; }
        public static List<List<object>> ListDriver { get; set; }
        public Car Car { get; set; }
        public bool IsViolateTL { get; set; }

        public Driver(bool isViolateTL, Car car)
        {
            this.ID = ++CurrentMaxID;
            IsViolateTL = isViolateTL;
            Car = car;
        }

        private Driver() { }

        public static Driver CreateDriver(long id, bool isViolateTL, Car car)
        {
            return new Driver
            {
                ID = id,
                Car = car,
                IsViolateTL = isViolateTL
            };
        }
    }
}
