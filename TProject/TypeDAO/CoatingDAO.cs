using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TProject.Way;

namespace TProject.TypeDAO
{
    class CoatingDAO : DAO, ITypeDAO
    {
        public bool Insert(object obj)
        {
            try
            {
                Coating c = (Coating)obj;
                new SQLiteCommand(string.Format("Insert into Surface values ('{0}', {1})", c.TypeName.ToLower(), c.Coeff.ToString().Replace(',', '.')), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    c.TypeName.ToLower(),
                    c.Coeff
                };
                Coating.ListSurface.Add(list);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string nameSurface)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Surface where NameSurface = '{0}'", nameSurface.ToLower()), DAO.GetConnection()).ExecuteNonQuery();

                Coating.ListSurface.RemoveAll(l => l.ElementAt(0).ToString().ToLower().Equals(nameSurface.ToLower()));

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
                Coating c = (Coating)obj;
                new SQLiteCommand(string.Format("UPDATE Surface SET [NameSurface] = '{0}', [KoefSurface] = {1} where NameSurface = '{2}'", c.TypeName.ToLower(), c.Coeff.ToString().Replace(',', '.'), ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedCoating = Coating.ListSurface.FirstOrDefault(l => l.ElementAt(0).ToString().ToLower().Equals(ID.ToLower()));
                if (updatedCoating != null)
                {
                    updatedCoating[0] = c.TypeName.ToLower();
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
