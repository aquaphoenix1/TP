using System.Collections.Generic;
using System.Linq;

namespace TProject.Coll
{
    /// <summary>
    /// Базовый абстрактный класс коллекций
    /// </summary>
    /// <typeparam name="T">тип элементов коллекции</typeparam>
    public class AbstractCollection<T>
    {
        /// <summary>
        /// Список элементов коллекции
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
        public event MakeMap.ReDraw RePaint;

        public T GetElement(int index)
        {
            return List.ElementAt(index);
        }
        /// <summary>
        /// Добавляет элемент в коллекцию и вызывает событие отрисовки изменений
        /// </summary>
        /// <param name="vertex"></param>
        public void Add(T vertex)
        {
            List.Add(vertex);
            RePaint();
        }
        /// <summary>
        /// Добавляет элемент в коллекцию и не вызывает событий
        /// </summary>
        /// <param name="element"></param>
        public void AddNoEvent(T element)
        {
            List.Add(element);
        }
        /// <summary>
        /// Удаляет элемент из коллекции по заданному индексу
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            List.RemoveAt(index);
            RePaint();
        }
        /// <summary>
        /// Удаляет элемент из коллекции, совпадаюший с заданным
        /// </summary>
        /// <param name="vertex"></param>
        public void Delete(T vertex)
        {
            List.Remove(vertex);
            RePaint();
        }
        /// <summary>
        /// Возвращает все элементы коллекции в виде списка
        /// </summary>
        /// <returns></returns>
        public int GetCountElements()
        {
            return List.Count();
        }
    }
}
