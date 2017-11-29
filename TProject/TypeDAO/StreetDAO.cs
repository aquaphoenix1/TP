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
                string[] array = (string[])obj;
                long id = long.Parse(array[0]);
                new SQLiteCommand(string.Format("Insert into Street values ({0} , \'{1}\')", id, array[1]), DAO.GetConnection()).ExecuteNonQuery();

                System.Collections.Generic.List<object> list = new System.Collections.Generic.List<object>();
                list.Add(id);
                list.Add(array[1]);

                Graph.Edge.StreetList.Add(list);

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
                new SQLiteCommand(string.Format("DELETE from Policemen where ID = {0}", ID), DAO.GetConnection()).ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}