using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TProject
{
    public abstract class AbstractCollection<T>
    {
        public List<T> ElementsList { get; set; }

        public delegate void UpdateList();
        public event UpdateList eventUpdateList;

        public abstract T SearhElementWithCoord(int x, int y);

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
            eventUpdateList();
            ElementsList.Add(elem);
        }
        public void RemoveElement(T elem)
        {
            eventUpdateList();
            ElementsList.Remove(elem);
        }
        public List<T> GetElementsList()
        {
            return ElementsList;
        }
    }
}
