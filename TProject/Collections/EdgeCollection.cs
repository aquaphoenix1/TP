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

        public Edge SelEdge { get; set; }

        public override Edge SearhElementWithCoord(int x, int y)
        {
            Edge e = null;

            foreach (var o in ElementsList)
            {
                int val = (x - o.GetHead().X) * (o.GetEnd().Y - o.GetHead().Y) / (o.GetEnd().X - o.GetHead().X) + o.GetHead().Y;
                if (val + Vertex.Radius > y && val - Vertex.Radius < y && x < Math.Max(o.GetHead().X, o.GetEnd().X) && x > Math.Min(o.GetHead().X, o.GetEnd().X))
                    e = o;
            }
            return e;
        }
        //public Edge SearhAllEdge(Vertex vertex)
        //{
        //    return ElementsList.Find(o => o.GetHead().ID == vertex.ID || o.GetEnd().ID == vertex.ID);
        //}

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
            int width = (int)(Vertex.Radius.UnScaling()) - 4;
            width = width - 4 < 4 ? 5 : width - 4;

            foreach (var r in ElementsList)
            {
                e.DrawLine(PensCase.GetPenForEdge(r == SelEdge, r.IsBilateral, width),
                    (r.GetHead().X + Vertex.Radius_2).UnScaling(), (r.GetHead().Y + Vertex.Radius_2).UnScaling(),
                    (r.GetEnd().X + Vertex.Radius_2).UnScaling(), (r.GetEnd().Y + Vertex.Radius_2).UnScaling());
            }
                
            if (isCreatingEdge)
                e.DrawLine(PensCase.Createble, (vertexes.SelRect.X + Vertex.Radius_2).UnScaling(), (vertexes.SelRect.Y + Vertex.Radius_2).UnScaling(), x, y);
         }
    }
}
