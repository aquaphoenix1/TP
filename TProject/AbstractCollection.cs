using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TProject
{
    abstract class AbstractCollection<T>
    {
        public List<T> ElementsList { get; set; }

        /// <summary>
        /// Отрисовывает элементы коллекции на объекте, для которого вызвано событие 
        /// Paint
        /// </summary>
        /// <param name="e"></param>
        public abstract void  DrawAllOnPicture(PaintEventArgs e);

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
