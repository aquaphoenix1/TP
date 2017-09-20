using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.Graph;
using TProject.Properties;
using TProject.Way;

namespace TProject
{
    public class VertexCollection:AbstractCollection<Vertex>
    {
        /// <summary>
        /// Область выбранной вершины
        /// </summary>
        public Rectangle SelRect { get; set; }
        /// <summary>
        /// Выбранная вершины
        /// </summary>
        public Vertex SelVertex { get; set; }

        public List<TrafficLight> tlList = new List<TrafficLight>();

        public void tickTL(object obj, EventArgs e)
        {
            foreach (var o in tlList)
                o.Inc();
        }

        /// <summary>
        /// Возвращает вершину, лежащую радиусе Radius от указанной точки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override Vertex SearhElementWithCoord(int x, int y)
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
            SelVertex = SearhElementWithCoord(x, y);
            if (res = SelVertex != null)
            {
                SelRect = SelVertex.GetRect();

                dX = x - SelRect.X;
                dY = y - SelRect.Y;
            }
            return res;
        }
        
        public void DrawAllOnPicture(Graphics e, bool tlNotInit)
        {
            int x, y, width;

            width = (int)(Vertex.Radius.UnScaling()) - 4;
            width = width - 4 < 10 ? 10 : width - 6;

            foreach (var r in ElementsList)
            {
                x = r.GetRect().X.UnScaling();
                y = r.GetRect().Y.UnScaling();

                Brush p = PensCase.Point;
                if (r == SelVertex)
                    p = PensCase.SelectedVertex;

                e.FillEllipse(p, x + 2, y + 2, width, width);

                if (r.TrafficLight != null)
                {
                    if(tlNotInit)
                        e.DrawImage(Resources.nonLight3, new Point[] { new Point(x + Vertex.Radius + 3, y), new Point(x + (Vertex.Radius + 18), y), new Point(x + 3 + Vertex.Radius, y + 30) });
                    else if (r.TrafficLight.isGreen)
                            e.DrawImage(Resources.greenLight3, new Point[] { new Point(x + Vertex.Radius + 3, y), new Point(x + (Vertex.Radius + 18), y), new Point(x + 3 + Vertex.Radius, y + 30) });
                        else
                            e.DrawImage(Resources.redLight3, new Point[] { new Point(x + Vertex.Radius + 3, y), new Point(x + (Vertex.Radius + 18), y), new Point(x + 3 + Vertex.Radius, y + 30) });
                }
            }
        }

        public void MoveSelVertex(int x, int y, int dX, int dY)
        {
            SelVertex.SetRectXY(x - dX, y - dY);
        }
    }
}