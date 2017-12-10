using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace TProject.TypeDAO
{
    class DriverDAO : DAO, ITypeDAO
    {
        public bool Insert(object obj)
        {
            try
            {
                Driver.Driver d = (Driver.Driver)obj;
                new SQLiteCommand(string.Format("Insert into Driver values ('{0}','{1}','{2}')", d.FIO, d.IsViolateTL.ToString(), d.Car.TypeName), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    d.FIO,
                    d.IsViolateTL,
                    d.Car.TypeName
                };
                Driver.Driver.ListDriver.Add(list);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string FIO)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Driver where FIO = '{0}'", FIO), DAO.GetConnection()).ExecuteNonQuery();

                Driver.Driver.ListDriver.RemoveAll(l => l.ElementAt(0).ToString().Equals(FIO));

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
                Driver.Driver d = (Driver.Driver)obj;
                new SQLiteCommand(string.Format("UPDATE Driver SET [FIO] = '{0}', [TypeDriver] = '{1}', [Model] = '{2}' where FIO= '{3}'", d.FIO, d.IsViolateTL.ToString(), d.Car.TypeName, ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedDriver = Driver.Driver.ListDriver.FirstOrDefault(l => l.ElementAt(0).ToString().Equals(ID));
                if (updatedDriver != null)
                {
                    updatedDriver[0] = d.FIO;
                    updatedDriver[1] = d.IsViolateTL;
                    updatedDriver[2] = d.Car.TypeName;
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
