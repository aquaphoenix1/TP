using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProject.TypeDAO
{
    public interface ITypeDAO
    {

        bool Insert(Type obj);  //добавление в базу и в лист
        bool Delete(long ID);   //удаление из бд и из листа
        bool Update(Type obj);  //изменение в бд и в листе
        //void Delete(Type obj);
        //void Delete(int id);
    }
}
