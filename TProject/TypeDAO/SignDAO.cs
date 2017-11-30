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
                new SQLiteCommand(string.Format("Insert into Sign values ({0} , \'{1}\', {2})", s.ID, s.TypeName, s.Count), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    s.ID,
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

        public bool Delete(long ID)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Sign where ID = {0}", ID), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Sign.ListSigns.RemoveAll(l => l.ElementAt(0).ToString() == ID.ToString());

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
                new SQLiteCommand(string.Format("UPDATE Sign SET [Type] = '{0}', [Value] = {1} where ID = {2}", s.TypeName, s.Count, s.ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedSign = Sign.ListSigns.FirstOrDefault(l => l.ElementAt(0).ToString() == s.ID.ToString());
                if (updatedSign != null)
                {
                    updatedSign[1] = s.TypeName;
                    updatedSign[2] = s.Count;
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
