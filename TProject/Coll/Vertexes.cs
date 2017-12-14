using System.Linq;
using TProject.Graph;

namespace TProject.Coll
{
    public class Vertexes : AbstractCollection<Vertex>
    {

        /// <summary>
        /// Возвращает вершину, заданную парой коорднинат
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool GetSelected(int x, int y)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (MakeMap.IsPointInRectangle(List.ElementAt(i).X, List.ElementAt(i).Y, x, y))
                {
                    MakeMap.ViewPort.SelectVertex(List.ElementAt(i));
                    return true;
                }
            }

            MakeMap.ViewPort.UnSelectAll();
            return false;
        }
        /// <summary>
        /// Возвращает вершину, заданную парой координат и делает её текущей
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="selected"></param>
        /// <returns></returns>
        public bool GetSelected(int x, int y, out Vertex selected)
        {
            selected = null;
            for (int i = 0; i < List.Count; i++)
            {
                if (MakeMap.IsPointInRectangle(List.ElementAt(i).X, List.ElementAt(i).Y, x, y))
                {
                    selected = List.ElementAt(i);
                    MakeMap.ViewPort.Invalidate();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// возвращает вершину, заданную id, из списка 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vertex GetForId(long id)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (List.ElementAt(i).ID == id)
                {
                    return List.ElementAt(i);
                }
            }

            return null;
        }
    }
}
