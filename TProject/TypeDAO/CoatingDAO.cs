using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                new SQLiteCommand(string.Format("Insert into Surface values ({0} , \'{1}\', {2})",c.ID,c.TypeName, c.Coeff), DAO.GetConnection()).ExecuteNonQuery();


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

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
