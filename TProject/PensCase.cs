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
        public static Brush SelectedVertex { get; set; }
        public static Brush GeneralVertex { get; set; }
        public static Pen SelectedEdgeBilater { get; set; }
        public static Pen SelectedEdgeAtoB { get; set; }
        public static Pen CustomAtoB { get; set; }
        public static Pen CustomBilat{ get; set; }

        public static Pen GeneralEdge { get; set; }


        public static Pen Createble { get; set; }

        public static Pen GeneralEdgeAtoB { get; set; }
        public static Pen GeneralEdgeBilater { get; set; }

        public static Brush Point { get; set; }

        public static void Initialize()
        {

        }

        static PensCase()
        {
            Color generealEdgeColor = Color.DarkGray,
                  selectedVertex = Color.Aqua,
                  generalVert = Color.DarkBlue,
                  genEdge = Color.DarkBlue,
                  SelectedEdge = Color.DarkMagenta;

            Color custom = Color.Black;

            GeneralVertex = new SolidBrush(generalVert);
            GeneralEdge = new Pen(genEdge, Vertex.Radius_2);
            SelectedVertex = new SolidBrush(selectedVertex);

            CustomAtoB = new Pen(custom, Vertex.Radius_2);
            CustomBilat = new Pen(custom, Vertex.Radius_2);

            SelectedEdgeAtoB = new Pen(generealEdgeColor, GeneralEdge.Width);
            SelectedEdgeAtoB.Color = SelectedEdge;
            SelectedEdgeBilater = new Pen(generealEdgeColor, GeneralEdge.Width); ;
            SelectedEdgeBilater.Color = SelectedEdge;

            Point = new SolidBrush(generalVert);

            Createble = new Pen(selectedVertex, GeneralEdge.Width + 2);
            GeneralEdgeAtoB = new Pen(generealEdgeColor, GeneralEdge.Width);
            GeneralEdgeBilater = new Pen(generealEdgeColor, GeneralEdge.Width);

            Createble.StartCap = Createble.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;

            SelectedEdgeBilater.EndCap = SelectedEdgeBilater.StartCap = SelectedEdgeAtoB.EndCap =
                GeneralEdgeAtoB.EndCap = GeneralEdgeBilater.StartCap = CustomAtoB.EndCap = CustomBilat.EndCap = CustomBilat.StartCap =
                GeneralEdgeBilater.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            GeneralEdgeAtoB.StartCap = CustomAtoB.StartCap = SelectedEdgeAtoB.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        public static Pen GetCustomPen(bool isBiLat, int w)
        {
            if (isBiLat)
            {
                CustomBilat.Width = w;
                return CustomBilat;
            }

            CustomAtoB.Width = w;
            return CustomAtoB;
        }
        public static Pen GetPenForEdge(bool isSelected, bool isBiLat, int w)
        {
            if (isSelected)
            {
                if (isBiLat)
                {
                    SelectedEdgeBilater.Width = w;
                    return SelectedEdgeBilater;
                }
                SelectedEdgeAtoB.Width = w;
                return SelectedEdgeAtoB;
            }
            if (isBiLat)
            {
                GeneralEdgeBilater.Width = w;
                return GeneralEdgeBilater;
            }
            GeneralEdgeAtoB.Width = w;
            return GeneralEdgeAtoB;
        }
    }
}
