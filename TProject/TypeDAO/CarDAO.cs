﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TProject.Driver;

namespace TProject.TypeDAO
{
    //Auto [ID] , [Model] char(30), [IDFuel] Integer , [Сonsumption] real 
    class CarDAO : DAO, TypeDAO.ITypeDAO
    {
        //Добаваление в бд 
        public bool Insert(Type obj)
        {
            try
            {
                //вроде бы должно работать но у с.ID = 1 а такой ID уже есть страно посмотрел в отладке действительно статическое поле становиться равно 1 -страно 
                //поэтому здесь нахожу максимальный и прибавляю к нему максимальный.В дальнейшем переделаю.Сейчас так.
                Car.ListAuto.FirstOrDefault();
                Car  c = (Car)obj;
                new SQLiteCommand(string.Format("Insert into Auto values ({0},\'{1}\',{2},{3})", c.ID, c.Model, c.CarFuel.ID, c.FuelConsumption), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>();
                list.Add(c.ID);
                list.Add(c.Model);
                list.Add(c.CarFuel.ID);
                list.Add(c.FuelConsumption);
                Car.ListAuto.Add(list);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Удаление из бд и из листа ListTypePolicemen
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
        //Изменение в бд и в листе ListTypePolicemen
        public bool Update(Type obj)
        {
            try
            {
                Car c = (Car)obj;
                new SQLiteCommand(string.Format("UPDATE Auto SET [Model] = '{0}', [IDFuel] = {1}, [Сonsumption] = {2} where ID = {3}", c.Model, c.CarFuel.ID, c.FuelConsumption, c.ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedCar = Car.ListAuto.FirstOrDefault(l => l.ElementAt(0).ToString() == c.ID.ToString());
                if (updatedCar != null)
                {
                    updatedCar[1] = c.Model;
                    updatedCar[2] = c.CarFuel.ID;
                    updatedCar[3] = c.FuelConsumption;
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
