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

        static Pen Createble { get; set; }
        static Pen AtoB { get; set; }
        static Pen BtoA { get; set; }
        static Pen Reversible { get; set; }

        static EdgeCollection()
        { 
            Color color = Color.BurlyWood;
            Createble = new Pen(Vertex.ActivVertex.Color, Vertex.GeneralVertex.Width + 2);
            AtoB = new Pen(color, Vertex.GeneralVertex.Width);
            BtoA = new Pen(color, Vertex.GeneralVertex.Width);
            Reversible = new Pen(color, Vertex.GeneralVertex.Width);

            Createble.StartCap = Createble.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;

            AtoB.EndCap = BtoA.StartCap = Reversible.StartCap = Reversible.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            AtoB.StartCap = BtoA.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        public Edge SearhEdgeWithPoint(int x, int y) //A, C(x,y), B
        {    //((x_3 - x_1) / (x_2 - x_1) == (y_3 - y_1) / (y_2 - y_1))
            return ElementsList.Find(o => (
                (int)(o.GetVertexB().X - o.GetVertexA().X) / (x - o.GetVertexA().X) == (int)(o.GetVertexB().Y - o.GetVertexA().Y) / (y - o.GetVertexA().Y))
            );
        }
        public Edge SearhAllEdge(Vertex vertex)
        {
            return ElementsList.Find(o => o.VertexOne.Id == vertex.Id || o.VertexTwo.Id == vertex.Id);
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
        public void DrawAllOnPicture(PaintEventArgs e, int dX, int dY, int x, int y, VertexCollection vertexes, bool isCreatingEdge)
        {
            //int width = (int)(Vertex.GeneralVertex.Width.UnScaling() - 4;

            //Createble = new Pen(Vertex.ActivVertex.Color, Vertex.GeneralVertex.Width + 2));
            foreach (var r in ElementsList)
            {
                e.Graphics.DrawLine(Reversible,
                    (r.GetVertexA().X + Vertex.Radius_2).UnScaling(), (r.GetVertexA().Y + Vertex.Radius_2).UnScaling(),
                    (r.GetVertexB().X + Vertex.Radius_2).UnScaling(), (r.GetVertexB().Y + Vertex.Radius_2).UnScaling());
            }
            if (isCreatingEdge)
                e.Graphics.DrawLine(Createble, (vertexes.SelRect.X + Vertex.Radius_2).UnScaling(),(vertexes.SelRect.Y + Vertex.Radius_2).UnScaling(), x, y);
        }
    }
}
