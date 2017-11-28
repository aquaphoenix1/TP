using System.Collections.Generic;
using System.Linq;

namespace TProject.Coll
{
    public class AbstractCollection<T>
    {
        /// <summary>
        /// Список элементов
        /// </summary>
        private List<T> list;
        public List<T> List { protected set { list = value; } get { return list; } }

        public AbstractCollection()
        {
            List = new List<T>();
        }

        /// <summary>
        /// Событие, требующее перерисовки pictureBox'a
        /// </summary>
        public event Viewer.ReDraw RePaint;

        public T GetVertex(int index)
        {
            return List.ElementAt(index);
        }
        public void Add(T vertex)
        {
            List.Add(vertex);
            RePaint();
        }
        public void Delete(int index)
        {
            List.RemoveAt(index);
            RePaint();
        }
        public void Delete(T vertex)
        {
            List.Remove(vertex);
            RePaint();
        }
        public int GetCountElements()
        {
            return List.Count();
        }
    }
}
