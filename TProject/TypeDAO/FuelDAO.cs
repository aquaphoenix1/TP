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
                new SQLiteCommand(string.Format("Insert into Fuel values ({0} , \'{1}\', {2})", f.ID, f.TypeName, f.Price), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    f.ID,
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

        public bool Delete(long ID)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Fuel where ID = {0}", ID), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Fuel.ListFuel.RemoveAll(l => l.ElementAt(0).ToString() == ID.ToString());

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
                new SQLiteCommand(string.Format("UPDATE Fuel SET [Name] = '{0}', [Cost] = {1} where ID = {2}", f.TypeName, f.Price, f.ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedFuel = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).ToString() == f.ID.ToString());
                if (updatedFuel != null)
                {
                    updatedFuel[1] = f.TypeName;
                    updatedFuel[2] = f.Price;
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
