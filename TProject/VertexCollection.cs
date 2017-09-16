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
        /// Область выбранной вершины
        /// </summary>
        public Rectangle SelRect { get; set; }
        /// <summary>
        /// Выбранная вершины
        /// </summary>
        public Vertex SelVertex { get; set; }

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

        public bool SelectVertex(int x, int y, ref int dX, ref int dY)
        {
            bool res = false;
            SelVertex = SearhVertexPoint(x, y);
            if (res = SelVertex != null)
            {
                SelRect = SelVertex.GetRect();

                dX = x - SelRect.X;
                dY = y - SelRect.Y;
            }
            return res;
        }

        public void DrawAllOnPicture(PaintEventArgs e)
        { 
            foreach (var r in ElementsList)
            {
                e.Graphics.DrawEllipse(Vertex.GeneralVertex, r.GetRect());
            }
        }

        public void MoveSelVertex(int x, int y, int dX, int dY)
        {
            SelVertex.GetRect().X = x - dX;
            SelVertex.GetRect().Y = y - dY;
        }
    }
}