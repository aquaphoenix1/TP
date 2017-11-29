using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TProject.Way;

namespace TProject.TypeDAO
{
    class CoatingDAO : DAO, TypeDAO.ITypeDAO
    {
        public bool Insert(Type obj)
        {
            try
            {
                Coating c = (Coating)obj;
                new SQLiteCommand(string.Format("Insert into Surface values ({0} , \'{1}\', {2})", c.ID, c.TypeName, c.Coeff), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    c.ID,
                    c.TypeName,
                    c.Coeff
                };
                Coating.ListSurface.Add(list);

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
                new SQLiteCommand(string.Format("DELETE from Surface where ID = {0}", ID), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Coating.ListSurface.RemoveAll(l => l.ElementAt(0).ToString() == ID.ToString());

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
                Coating c = (Coating)obj;
                new SQLiteCommand(string.Format("UPDATE Surface SET [NameSurface] = '{0}', [KoefSurface] = {1} where ID = {2}", c.TypeName, c.Coeff, c.ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedCoating = Coating.ListSurface.FirstOrDefault(l => l.ElementAt(0).ToString() == c.ID.ToString());
                if (updatedCoating != null)
                {
                    updatedCoating[1] = c.TypeName;
                    updatedCoating[2] = c.Coeff;
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
