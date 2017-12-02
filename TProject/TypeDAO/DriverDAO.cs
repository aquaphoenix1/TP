using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace TProject.TypeDAO
{
    class DriverDAO : DAO
    {
        public bool Insert(Type obj)
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
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string FIO)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Driver where FIO = '{0}'", FIO), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Driver.Driver.ListDriver.RemoveAll(l => l.ElementAt(0).ToString().Equals(FIO));

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
                Driver.Driver d = (Driver.Driver)obj;
                new SQLiteCommand(string.Format("UPDATE Driver SET [TypeDriver] = '{0}', [Model] = '{1}' where [FIO]= /'{2}/'", d.IsViolateTL.ToString(), d.Car.TypeName, d.FIO), DAO.GetConnection()).ExecuteNonQuery();

                var updatedDriver = Driver.Driver.ListDriver.FirstOrDefault(l => l.ElementAt(0).ToString().Equals(d.FIO));
                if (updatedDriver != null)
                {
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
