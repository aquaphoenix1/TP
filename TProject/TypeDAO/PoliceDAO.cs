using System;
using System.Data.SQLite;
using TProject.Way;

namespace TProject
{
    class PoliceDAO : DAO, TypeDAO.ITypeDAO
    {
        public bool Insert(object obj)
        {
            try
            {
                Police p = (Police)obj;
                new SQLiteCommand(string.Format("Insert into Policemen values ({0} , \'{1}\', {2})", p.ID, p.TypeName, p.Coeff), DAO.GetConnection()).ExecuteNonQuery();

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
