using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TProject.Driver;

namespace TProject.TypeDAO
{
    class FuelDAO : DAO, TypeDAO.ITypeDAO
    {
        //Добаваление в бд и в лист ListTypePolicemen
        public bool Insert(Type obj)
        {
            try
            {
                //[ID] Integer primary key, [Name] char(30) not null, [Cost]
                Fuel f = (Fuel)obj;
                new SQLiteCommand(string.Format("Insert into Fuel values ({0} , \'{1}\', {2})", f.ID, f.TypeName, f.Price), DAO.GetConnection()).ExecuteNonQuery();

                List<object> list = new List<object>();
                list.Add(f.ID);
                list.Add(f.TypeName);
                list.Add(f.Price);
                Fuel.ListFuel.Add(list);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Удаление из бд и из листа ListTypePolicemen
        public bool Delete(long ID)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE from Fuel where ID = {0}", ID), DAO.GetConnection()).ExecuteNonQuery();

                var obj = Fuel.ListFuel.RemoveAll(l => l.ElementAt(0).ToString() == ID.ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }
        //Изменение в бд и в листе ListTypePolicemen
        public bool Update(Type obj)
        {
            try
            {
                Fuel f = (Fuel)obj;
                new SQLiteCommand(string.Format("UPDATE Fuel SET [Name] = '{0}', [Cost] = {1} where ID = {2}", f.TypeName, f.Price, f.ID), DAO.GetConnection()).ExecuteNonQuery();

                var updatedFuel = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).ToString() == f.ID.ToString());
                if (updatedFuel != null)
                {
                    updatedFuel[1] = f.TypeName;
                    updatedFuel[2] = f.Price;
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
