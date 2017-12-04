using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TProject.Way;

namespace TProject.TypeDAO
{
    class FineDAO : DAO, ITypeDAO
    {
        public bool Insert(object obj)
        {
            try
            {
                Fine f = (Fine)obj;
                new SQLiteCommand(string.Format("Insert into Fine values ('{0}', {1})", f.TypeName, f.Count.ToString().Replace(',', '.')), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
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

        public bool Delete(string nameFine)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Fine where NameFine = '{0}'", nameFine), DAO.GetConnection()).ExecuteNonQuery();

                Fine.ListFine.RemoveAll(l => l.ElementAt(0).ToString().Equals(nameFine));

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
                Fine f = (Fine)obj;
                new SQLiteCommand(string.Format("UPDATE Fine SET [NameFine] = '{0}', [CostFine] = {1} where NameFine = '{2}'", f.TypeName, f.Count.ToString().Replace(',', '.'), ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedFine = Fine.ListFine.FirstOrDefault(l => l.ElementAt(0).ToString().Equals(ID));
                if (updatedFine != null)
                {
                    updatedFine[0] = f.TypeName;
                    updatedFine[1] = f.Count;
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
