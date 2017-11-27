using System.Collections.Generic;
using System.Linq;

namespace TProject.Driver
{
    //Auto ([ID] Integer, [Model] char(30), [IDFuel] Integer, [Сonsumption] real 
    public class Car : Type
    {
        public static long CurrentMaxID { private get; set; }
        public static List<List<object>> ListAuto { get; set; }
        public Fuel CarFuel { get; set; }
        public string Model { get; set; }
        public double FuelConsumption { get; set; }

        //Используется в "Работе с БД" для добавления 
        public Car(string model, Fuel fuel, double consumption) : base(model)
        {

            var findcar = Car.ListAuto.Select(i => i[0]).Max();
            CurrentMaxID = long.Parse(findcar.ToString());
            this.ID = ++CurrentMaxID;
            this.CarFuel = fuel;
            this.Model = model;
            this.FuelConsumption = consumption;
        }

        //Используется в "Работе с БД" для изменения - так как нужно найти соот-щую запись 
        public Car(int id, string model, Fuel fuel, double consumption)
        {
            this.ID = id;
            this.Model = model;
            this.CarFuel = fuel;
            this.FuelConsumption = consumption;
        }

    }
}
