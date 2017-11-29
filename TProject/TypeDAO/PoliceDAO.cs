using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TProject.Way;

namespace TProject
{
    class PoliceDAO : DAO, TypeDAO.ITypeDAO
    {
        public bool Insert(Type obj)
        {
            try
            {
                Police p = (Police)obj;
                new SQLiteCommand(string.Format("Insert into Policemen values ({0} , \'{1}\', {2})", p.ID, p.TypeName, p.Coeff), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>
                {
                    p.ID,
                    p.TypeName,
                    p.Coeff
                };
                Police.ListTypePolicemen.Add(list);

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

                var obj = Police.ListTypePolicemen.RemoveAll(l => l.ElementAt(0).ToString() == ID.ToString());

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
                Police p = (Police)obj;
                new SQLiteCommand(string.Format("UPDATE Policemen SET [TypePolice] = '{0}', [Koefficient] = {1} where ID = {2}", p.TypeName, p.Coeff, p.ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedPolice = Police.ListTypePolicemen.FirstOrDefault(l => l.ElementAt(0).ToString() == p.ID.ToString());
                if (updatedPolice != null)
                {
                    updatedPolice[1] = p.TypeName;
                    updatedPolice[2] = p.Coeff;
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
