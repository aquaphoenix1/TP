using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TProject
{
    class EdgeCollection : AbstractCollection<Edge>
    {

        public Edge SearhEdgeWithPoint(int x, int y)
        {    //((x_3 - x_1) / (x_2 - x_1) == (y_3 - y_1) / (y_2 - y_1))
            return ElementsList.Find(o => (
                (int)(o.GetVertexB().X - o.GetVertexA().X) / (x - o.GetVertexA().X) == (int)(o.GetVertexB().Y - o.GetVertexA().Y) / (y - o.GetVertexA().Y))
            );
        }
        public Edge SearhAllEdge(Vertex vertex)
        {
            return ElementsList.Find(o => o.VertexOne.ID == vertex.ID || o.VertexTwo.ID == vertex.ID);
        }

        /// <summary>
        /// Отрисовка коллекции
        /// </summary>
        /// <param name="e"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <param name="x"> координата из которой строится линия в тек момент</param>
        /// <param name="y"> координата из которой строится линия в тек момент</param>
        /// <param name="vertexes"> список вершин</param>
        /// <param name="isCreatingEdge"> строится ли линия в данный момент</param>
        public void DrawAllOnPicture(Graphics e, int dX, int dY, int x, int y, VertexCollection vertexes, bool isCreatingEdge)
        {
            foreach (var r in ElementsList)
            {
                e.DrawLine(PensCase.Reversible,
                    (r.GetVertexA().X + Vertex.Radius_2).UnScaling(), (r.GetVertexA().Y + Vertex.Radius_2).UnScaling(),
                    (r.GetVertexB().X + Vertex.Radius_2).UnScaling(), (r.GetVertexB().Y + Vertex.Radius_2).UnScaling());
            }
            if (isCreatingEdge)
                e.DrawLine(PensCase.Createble, (vertexes.SelRect.X + Vertex.Radius_2).UnScaling(), (vertexes.SelRect.Y + Vertex.Radius_2).UnScaling(), x, y);
         }
    }
}
