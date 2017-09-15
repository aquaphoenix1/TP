using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TProject
{
    class AbstractCollection<T>
    {
        public List<T> ElementsList { get; set; }

        public int GetCountElements()
        {
            return ElementsList.Count();
        }
        public AbstractCollection()
        {
            ElementsList = new List<T>();
        }
        public void AddElement(T elem)
        {
            ElementsList.Add(elem);
        }
        public void RemoveElement(T elem)
        {
            ElementsList.Remove(elem);
        }
        public List<T> GetElementsList()
        {
            return ElementsList;
        }

      
    }
}
