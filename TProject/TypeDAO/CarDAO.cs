using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TProject.Driver;

namespace TProject.TypeDAO
{
    class CarDAO : DAO, ITypeDAO
    {
        public bool Insert(object obj)
        {
            try
            {
                Car c = (Car)obj;
                new SQLiteCommand(string.Format("Insert into Auto values ('{0}','{1}',{2},{3})", c.TypeName.ToLower(), c.CarFuel.TypeName, c.FuelConsumption.ToString().Replace(',', '.'), c.Speed.ToString().Replace(',', '.')), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    c.TypeName.ToLower(),
                    c.CarFuel.TypeName,
                    c.FuelConsumption,
                    c.Speed
                };
                Car.ListAuto.Add(list);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string model)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Auto where Model = '{0}'", model.ToLower()), DAO.GetConnection()).ExecuteNonQuery();

                Car.ListAuto.RemoveAll(l => l.ElementAt(0).ToString().ToLower().Equals(model.ToLower()));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(object obj, string ID)
        {
            try
            {
                Car c = (Car)obj;
                new SQLiteCommand(string.Format("UPDATE Auto SET [Model] = '{0}', [Fuel] = '{1}', [Сonsumption] = {2}, [Speed] = {3} where Model = '{4}'", c.TypeName.ToLower(), c.CarFuel.TypeName, c.FuelConsumption.ToString().Replace(',', '.'), c.Speed.ToString().Replace(',', '.'), ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedCar = Car.ListAuto.FirstOrDefault(l => l.ElementAt(0).ToString().ToLower().Equals(ID.ToLower()));
                if (updatedCar != null)
                {
                    updatedCar[0] = c.TypeName.ToLower();
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
