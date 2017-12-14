using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TProject.Driver;

namespace TProject.TypeDAO
{
    class FuelDAO : DAO, ITypeDAO
    {
        public bool Insert(object obj)
        {
            try
            {
                Fuel f = (Fuel)obj;
                new SQLiteCommand(string.Format("Insert into Fuel values ('{0}', {1})", f.TypeName.ToUpper(), f.Price.ToString().Replace(',', '.')), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    f.TypeName.ToUpper(),
                    f.Price
                };
                Fuel.ListFuel.Add(list);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string name)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Fuel where Name = '{0}'", name.ToUpper()), DAO.GetConnection()).ExecuteNonQuery();

                Fuel.ListFuel.RemoveAll(l => l.ElementAt(0).ToString().ToUpper().Equals(name.ToUpper()));

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
                Fuel f = (Fuel)obj;
                new SQLiteCommand(string.Format("UPDATE Fuel SET [Name] = '{0}', [Cost] = {1} where Name = '{2}'", f.TypeName.ToUpper(), f.Price.ToString().Replace(',', '.'), ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedFuel = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).ToString().ToUpper().Equals(ID.ToUpper()));
                if (updatedFuel != null)
                {
                    updatedFuel[0] = f.TypeName.ToUpper();
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
