using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProject
{
    static class PensCase
    {
        public static Pen SelectedVertex { get; set; }
        public static Pen GeneralVertex { get; set; }
        public static Pen SelectedEdge { get; set; }
        public static Pen GeneralEdge { get; set; }
        public static Pen Createble { get; set; }
        public static Pen AtoB { get; set; }
        public static Pen BtoA { get; set; }
        public static Pen Reversible { get; set; }
        public static Brush Point { get; set; }

        public static void Initialize()
        {

        }

        static PensCase()
        {
            GeneralVertex = new Pen(Brushes.DarkBlue, Vertex.Radius_2);
            SelectedVertex = new Pen(Color.Aqua, Vertex.Radius_2);

            Point = new SolidBrush(Color.Blue);
            Color color = Color.BurlyWood;


            Createble = new Pen(SelectedVertex.Color, GeneralVertex.Width + 2);
            AtoB = new Pen(color, GeneralVertex.Width);
            BtoA = new Pen(color, GeneralVertex.Width);
            Reversible = new Pen(color, GeneralVertex.Width);

            Createble.StartCap = Createble.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            AtoB.EndCap = BtoA.StartCap = Reversible.StartCap = Reversible.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            AtoB.StartCap = BtoA.EndCap = System.Drawing.Drawing2D.LineCap.Round;

        }
    }
}
