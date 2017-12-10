using System;
using System.Data.SQLite;
using System.Linq;

namespace TProject.TypeDAO
{
    class StreetDAO : DAO, ITypeDAO
    {
        public bool Insert(object obj)
        {
            try
            {
                string str = obj.ToString();
                new SQLiteCommand(string.Format("Insert into Street values ('{0}')", str), DAO.GetConnection()).ExecuteNonQuery();

                System.Collections.Generic.List<object> list = new System.Collections.Generic.List<object>
                {
                    str
                };

                Graph.Edge.StreetList.Add(list);

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
                new SQLiteCommand(string.Format("DELETE from Street where Name = '{0}'", name), DAO.GetConnection()).ExecuteNonQuery();

                Graph.Edge.StreetList.RemoveAll(l => l.ElementAt(0).ToString().Equals(name));

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
                new SQLiteCommand(string.Format("UPDATE Street SET [Name] = '{0}' where Name = '{1}'", obj.ToString(), ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedStreet = Graph.Edge.StreetList.First(l => l.ElementAt(0).ToString().Equals(ID));
                if (updatedStreet != null)
                {
                    updatedStreet[0] = obj;
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