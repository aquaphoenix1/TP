using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TProject.Way;

namespace TProject.TypeDAO
{
    class SignDAO : DAO
    {
        public bool Insert(Type obj)
        {
            try
            {
                Sign s = (Sign)obj;
                new SQLiteCommand(string.Format("Insert into Sign values ('{0}', {1})", s.TypeName, s.Count), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    s.TypeName,
                    s.Count
                };
                Sign.ListSigns.Add(list);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string type)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Sign where Type = '{0}'", type), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Sign.ListSigns.RemoveAll(l => l.ElementAt(0).ToString().Equals(type));

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
                Sign s = (Sign)obj;
                new SQLiteCommand(string.Format("UPDATE Sign SET [Value] = {0} where Type = '{1}'", s.Count, s.TypeName), DAO.GetConnection()).ExecuteNonQuery();

                var updatedSign = Sign.ListSigns.FirstOrDefault(l => l.ElementAt(0).ToString().Equals(s.TypeName));
                if (updatedSign != null)
                {
                    updatedSign[1] = s.Count;
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
