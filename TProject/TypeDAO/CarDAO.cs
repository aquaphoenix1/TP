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
                new SQLiteCommand(string.Format("Insert into Auto values ({0},\'{1}\',{2},{3},{4})", c.ID, c.TypeName, c.CarFuel.ID, c.FuelConsumption, c.Speed), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    c.ID,
                    c.TypeName,
                    c.CarFuel.ID,
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

        public bool Delete(long ID)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Auto where ID = {0}", ID), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Car.ListAuto.RemoveAll(l => l.ElementAt(0).ToString() == ID.ToString());

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
                new SQLiteCommand(string.Format("UPDATE Auto SET [Model] = '{0}', [IDFuel] = {1}, [Сonsumption] = {2}, [Speed] = {4} where ID = {3}", c.TypeName, c.CarFuel.ID, c.FuelConsumption, c.ID, c.Speed), DAO.GetConnection()).ExecuteNonQuery();

                var updatedCar = Car.ListAuto.FirstOrDefault(l => l.ElementAt(0).ToString() == c.ID.ToString());
                if (updatedCar != null)
                {
                    updatedCar[1] = c.TypeName;
                    updatedCar[2] = c.CarFuel.ID;
                    updatedCar[3] = c.FuelConsumption;
                    updatedCar[4] = c.Speed;
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
