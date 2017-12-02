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
                new SQLiteCommand(string.Format("Insert into Surface values ('{0}', {1})", c.TypeName, c.Coeff), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
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

        public bool Delete(string nameSurface)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Surface where NameSurface = '{0}'", nameSurface), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Coating.ListSurface.RemoveAll(l => l.ElementAt(0).ToString().Equals(nameSurface));

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
                new SQLiteCommand(string.Format("UPDATE Surface SET [KoefSurface] = {0} where NameSurface = '{1}'", c.Coeff, c.TypeName), DAO.GetConnection()).ExecuteNonQuery();

                var updatedCoating = Coating.ListSurface.FirstOrDefault(l => l.ElementAt(0).ToString().Equals(c.TypeName));
                if (updatedCoating != null)
                {
                    updatedCoating[1] = c.Coeff;
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
