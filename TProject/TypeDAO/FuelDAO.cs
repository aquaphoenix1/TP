using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TProject.Driver;

namespace TProject.TypeDAO
{
    class FuelDAO : DAO
    {
        public bool Insert(Type obj)
        {
            try
            {
                Fuel f = (Fuel)obj;
                new SQLiteCommand(string.Format("Insert into Fuel values ('{0}', {1})", f.TypeName, f.Price), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    f.TypeName,
                    f.Price
                };
                Fuel.ListFuel.Add(list);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string name)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Fuel where Name = {0}", name), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Fuel.ListFuel.RemoveAll(l => l.ElementAt(0).ToString().Equals(name));

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
                Fuel f = (Fuel)obj;
                new SQLiteCommand(string.Format("UPDATE Fuel SET [Cost] = {0} where Name = '{1}'", f.Price, f.TypeName), DAO.GetConnection()).ExecuteNonQuery();

                var updatedFuel = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).ToString().Equals(f.TypeName));
                if (updatedFuel != null)
                {
                    updatedFuel[1] = f.Price;
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
