﻿namespace TProject.Driver
{
    class Driver : Type
    {
        public Car Car { get; set; }
        public string DriverName { get; set; }

        public int OverSpeed { get; set; }
        public bool isViolateTL { get; set; }

        public Driver(string typeName, string driverName,Car car):base(typeName)
        {
            Car = car;
            DriverName = driverName;
        }
    }
}
