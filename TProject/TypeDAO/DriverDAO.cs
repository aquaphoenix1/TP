﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProject.TypeDAO
{
    class DriverDAO : DAO
    {
        string typeDriver;
        //Добаваление в бд 
        public bool Insert(Entity obj)
        {
            try
            {
                Driver.Driver d = (Driver.Driver)obj;
                if (d.IsViolateTL == false) { typeDriver = "Нет"; } else { typeDriver = "Да"; }
                new SQLiteCommand(string.Format("Insert into Driver values ({0},\'{1}\',{2})", d.ID, typeDriver, d.Car.ID), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>();
                list.Add(d.ID);
                list.Add(d.IsViolateTL);
                list.Add(d.Car.ID);
                Driver.Driver.ListDriver.Add(list);

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
                new SQLiteCommand(string.Format("DELETE from Driver where ID = {0}", ID), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Driver.Driver.ListDriver.RemoveAll(l => l.ElementAt(0).ToString() == ID.ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }
        //Изменение в бд и в листе ListTypePolicemen
        public bool Update(Entity obj)
        {
            try
            {
                Driver.Driver d = (Driver.Driver)obj;
                if (d.IsViolateTL == false) { typeDriver = "Нет"; } else { typeDriver = "Да"; }
                new SQLiteCommand(string.Format("UPDATE Driver SET [TypeDriver] = '{0}', [IDAuto] = {1}  where [ID]= {2}", typeDriver, int.Parse(d.Car.ID.ToString()), d.ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedDriver = Driver.Driver.ListDriver.FirstOrDefault(l => l.ElementAt(0).ToString() == d.ID.ToString());
                if (updatedDriver != null)
                {
                    updatedDriver[0] = d.ID;
                    updatedDriver[1] = d.IsViolateTL;
                    updatedDriver[2] = d.Car.ID;
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
