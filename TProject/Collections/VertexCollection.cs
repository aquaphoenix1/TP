using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.Properties;

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
                Math.Pow(x.UnScaling() - o.X, 2) + Math.Pow(y.UnScaling() - o.Y, 2) < Math.Pow(Vertex.Radius * 1.5, 2)))
           == null;
        }

        public bool SelectVertex(int x, int y, out int dX, out int dY)
        {
            dX = 0; dY = 0;
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

        public void DrawAllOnPicture(Graphics e)
        {
            int x, y, width;

            foreach (var r in ElementsList)
            {
                x = r.GetRect().X.UnScaling();
                y = r.GetRect().Y.UnScaling();
                width = (int)(r.GetRect().Width.UnScaling()) - 4;
                width = width - 4 < 4 ? 5 : width - 4;

                e.FillEllipse(PensCase.Point, x + 2, y + 2, width, width);

                if (r.TrafficLight != null)
                    e.DrawImage(Resources.nonLight3, new Point[] { new Point(x + Vertex.Radius + 3, y), new Point(x + (Vertex.Radius + 18), y), new Point(x + 3 + Vertex.Radius, y + 30) });
            }
        }

        public void MoveSelVertex(int x, int y, int dX, int dY)
        {
            SelVertex.SetRectXY(x - dX, y - dY);
        }
    }
}