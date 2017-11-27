using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProject.TypeDAO
{
    public interface ITypeDAO
    {

        bool Insert(object obj);
        bool Delete(long ID);
        //void Delete(Type obj);
        //void Delete(int id);
    }
}
