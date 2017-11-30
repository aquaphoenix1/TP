using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TProject.Way;

namespace TProject.TypeDAO
{
    class FineDAO : DAO
    {
        public bool Insert(Type obj)
        {
            try
            {
                Fine f = (Fine)obj;
                new SQLiteCommand(string.Format("Insert into Fine values ({0} , \'{1}\', {2})", f.ID, f.TypeName, f.Count), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    f.ID,
                    f.TypeName,
                    f.Count
                };
                Fine.ListFine.Add(list);

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
                new SQLiteCommand(string.Format("DELETE from Fine where ID = {0}", ID), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Fine.ListFine.RemoveAll(l => l.ElementAt(0).ToString() == ID.ToString());

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
                Fine f = (Fine)obj;
                new SQLiteCommand(string.Format("UPDATE Fine SET [NameFine] = '{0}', [CostFine] = {1} where ID = {2}", f.TypeName, f.Count, f.ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedFine = Fine.ListFine.FirstOrDefault(l => l.ElementAt(0).ToString() == f.ID.ToString());
                if (updatedFine != null)
                {
                    updatedFine[1] = f.TypeName;
                    updatedFine[2] = f.Count;
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
