using System.Collections.Generic;
using System.Linq;

namespace TProject.Driver
{
    class Driver : Entity
    {
        public static long CurrentMaxID { private get; set; }
        public static List<List<object>> ListDriver { get; set; }
        public Car Car { get; set; }
        public bool IsViolateTL { get; set; }

        //Для добавления.Даниил
        public Driver(bool isViolateTL, Car car)
        {
            var driver = Driver.ListDriver.Select(i => i[0]).Max();
            if (driver == null) { CurrentMaxID = 0; } else { CurrentMaxID = int.Parse(driver.ToString()); }
            this.ID = ++CurrentMaxID;
            IsViolateTL = isViolateTL;
            Car = car;
        }
        //для изменения.Даниил
        public Driver(int id, bool isViolateTL, Car car)
        {
            this.ID = id;
            this.IsViolateTL = isViolateTL;
            this.Car = car;
        }
    }
}
