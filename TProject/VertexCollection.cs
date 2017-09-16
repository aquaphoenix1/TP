using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TProject
{
    class VertexCollection:AbstractCollection<Vertex>
    {
        /// <summary>
        /// Возвращает вершину, лежащую радиусе Radius от указанной точки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Vertex SearhVertexPoint(int x, int y)
        {
            Vertex v = null;
            foreach (var o in ElementsList)
            {
                if ((x < o.X + o.GetRect().Width) && (x > o.X) && (y < o.Y + o.GetRect().Height) && (y > o.Y))
                    v = o;
            }
            return v;
        }

        /// <summary>
        /// Проверяет наличие вершин в радиусе Radius^2 от указанной точки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsAllowedRadius(int x, int y)
        {
           return ElementsList.Find(o =>(
                Math.Pow(x - o.X, 2) + Math.Pow(y - o.Y, 2) < Math.Pow(Vertex.Radius * 2, 2)))
           == null;
        }

        public override void DrawAllOnPicture(PaintEventArgs e)
        { 
            foreach (var r in ElementsList)
            {
                e.Graphics.DrawEllipse(Vertex.GeneralVertex, r.GetRect());
            }
        }
    }
}


//private List<Vertex> vertexPointList;

//public int GetCountVertex()
//{
//    return vertexPointList.Count();
//}
//public VertexCollection()
//{
//    vertexPointList = new List<Vertex>();
//}
//public void AddVertexPoint(Vertex rectangle)
//{
//    vertexPointList.Add(rectangle);
//}
//public Vertex SearhVertexPoint(int x, int y)
//{
//    return vertexPointList.Find(o => (x < o.X + o.PointOnMap.Width) && (x > o.X) && (y < o.Y + o.PointOnMap.Height) && (y > o.Y));
//}
//public void RemoveVertexPoint(Vertex rectangle)
//{
//    vertexPointList.Remove(rectangle);
//}
//public List<Vertex> GetVertexPointList()
//{
//    return vertexPointList;
//}