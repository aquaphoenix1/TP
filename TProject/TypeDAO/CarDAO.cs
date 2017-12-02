using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TProject.Driver;

namespace TProject.TypeDAO
{
    class CarDAO : DAO
    {
        public bool Insert(Type obj)
        {
            try
            {
                Car.ListAuto.FirstOrDefault();
                Car c = (Car)obj;
                new SQLiteCommand(string.Format("Insert into Auto values ('{1}','{2}',{3},{4})", c.TypeName, c.CarFuel.TypeName, c.FuelConsumption, c.Speed), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    c.TypeName,
                    c.CarFuel.TypeName,
                    c.FuelConsumption,
                    c.Speed
                };
                Car.ListAuto.Add(list);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string model)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Auto where Model = '{0}'", model), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Car.ListAuto.RemoveAll(l => l.ElementAt(0).ToString().Equals(model));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Type obj)
        {
            try
            {
                Car c = (Car)obj;
                new SQLiteCommand(string.Format("UPDATE Auto SET [Model] = '{0}', [Fuel] = '{1}', [Сonsumption] = {2}, [Speed] = {3} where Model = '{0}'", c.CarFuel.TypeName, c.CarFuel.TypeName, c.FuelConsumption, c.Speed), DAO.GetConnection()).ExecuteNonQuery();

                var updatedCar = Car.ListAuto.FirstOrDefault(l => l.ElementAt(0).ToString().Equals(c.TypeName));
                if (updatedCar != null)
                {
                    updatedCar[0] = c.TypeName;
                    updatedCar[1] = c.CarFuel.TypeName;
                    updatedCar[2] = c.FuelConsumption;
                    updatedCar[3] = c.Speed;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
