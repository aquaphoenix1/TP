using System;
using System.Data.SQLite;

namespace TProject.TypeDAO
{
    class StreetDAO : DAO
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
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string name)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Street where Name = '{0}'", name), DAO.GetConnection()).ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}