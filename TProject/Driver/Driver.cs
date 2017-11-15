using System.Collections.Generic;

namespace TProject.Driver
{
    class Driver : Type
    {
        public static List<List<object>> ListDriver { get; set; }
        public Car Car { get; set; }
        public string DriverName { get; set; }

        public int OverSpeed { get; set; }
        public bool IsViolateTL { get; set; }

        public Driver(string typeName, string driverName, bool isViolateTL, int overSpeed, Car car):base(typeName)
        {
            OverSpeed = overSpeed;
            IsViolateTL = isViolateTL;
            Car = car;
            DriverName = driverName;
        }
    }
}
