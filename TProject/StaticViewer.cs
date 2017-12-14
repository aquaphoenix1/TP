using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using TProject.Properties;
using TProject.Way;

namespace TProject
{
    class StaticViewer
    {

        /// <summary>
        /// Смещение курсора от центра точки
        /// </summary>
        public int dX, dY;
        private Font font;
        /// <summary>
        /// Ширина точки
        /// </summary>
        private static int width;
        public static int Width { get { return width; } set { width = value; } }
        Brush blackFontBrush = new SolidBrush(Color.Black);
        Brush redFontBrush = new SolidBrush(Color.Red);
        // #region Отрисовка элементов, содержащихся на карте
        /// <summary>
        /// Происходит при перерисовке pictureBox, содержащего карту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            Viewer.DrawEdges(graph);
            Viewer.DrawVertexes(graph);
            if (Route.Start != null)
            {
                Viewer.DrawStartPoint(graph);
            }
            if (Route.End != null)
            {
                Viewer.DrawEndPoint(graph);
            }
        }

        private StaticViewer(Font font)
        {
            this.font = font;
        }
        private static StaticViewer viewer;
        public static StaticViewer Viewer => viewer;

        public static StaticViewer CreateViewer(Font font)
        {
            return (viewer = new StaticViewer(font));
        }


        /// <summary>
        /// отрисовывает все перегоны, содержащиеся на карте
        /// </summary>
        /// <param name="graph"></param>
        public void DrawEdges(Graphics graph)
        {
            Pen pen = new Pen(Color.Green, Width.UnScaling() - 2)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.ArrowAnchor
            };

            foreach (var item in Map.edges.List)
            {
                if (!item.Equals(MakeMap.ViewPort.SelectedEdge))
                {
                    Pen penOne = PensCase.GetCustomPen(false, Width.UnScaling() + 3);
                    Pen penTwo = PensCase.GetPenForEdge(false, false, Width.UnScaling());
                    if (!item.IsBilateral)
                    {
                        penOne.StartCap = LineCap.Round;
                        penTwo.StartCap = LineCap.Round;
                        pen.StartCap = LineCap.Round;
                        penOne.EndCap = LineCap.ArrowAnchor;
                        penTwo.EndCap = LineCap.ArrowAnchor;
                        pen.EndCap = LineCap.ArrowAnchor;
                    }
                    else
                    {
                        penOne.StartCap = LineCap.ArrowAnchor;
                        penTwo.StartCap = LineCap.ArrowAnchor;
                        pen.StartCap = LineCap.ArrowAnchor;
                        penOne.EndCap = LineCap.ArrowAnchor;
                        penTwo.EndCap = LineCap.ArrowAnchor;
                        pen.EndCap = LineCap.ArrowAnchor;
                    }
                    graph.DrawLine(penOne, item.GetHead().X.UnScaling() + dX, item.GetHead().Y.UnScaling() + dY,
                        item.GetEnd().X.UnScaling() + dX, item.GetEnd().Y.UnScaling() + dY);
                    graph.DrawLine(penTwo, item.GetHead().X.UnScaling() + dX, item.GetHead().Y.UnScaling() + dY,
                        item.GetEnd().X.UnScaling() + dX, item.GetEnd().Y.UnScaling() + dY);
                    if (item.IsInWay)
                    {
                        graph.DrawLine(pen,
                          (item.GetHead().X).UnScaling() + Width / 2, (item.GetHead().Y).UnScaling() + Width / 2,
                          (item.GetEnd().X).UnScaling() + Width / 2, (item.GetEnd().Y).UnScaling() + Width / 2);
                    }
                    if (MakeMap.ViewPort.IsStreetLength_Visible)
                    {
                        graph.DrawString(Math.Round(item.GetLength(MakeMap.ViewPort.ScaleCoefficient), 2).ToString(), new Font(font.FontFamily, 10f, FontStyle.Italic | FontStyle.Bold,
                            GraphicsUnit.Point, font.GdiCharSet), blackFontBrush,
                            (item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 - 25),
                            (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2 - 10));
                    }
                }
                if (item.Policemen != null && MakeMap.ViewPort.IsPolice_Visible)
                {
                    graph.DrawImage(Resources.star, new Rectangle(item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 + 25,
                            (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2 + 10), Width * 2, Width * 2));
                }
            }
            if (MakeMap.ViewPort.IsSign_Visible)
            {
                foreach (var item in Map.edges.List.Where(o => o.SignMaxSpeed != null || !o.IsBilateral))
                {
                    if (item.SignMaxSpeed != null)
                    {
                        graph.FillEllipse(new SolidBrush(Color.White),
                            (item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 + 24)
                            , (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2 - 4), Width * 2 + 3, Width * 2 + 3);
                        graph.DrawEllipse(new Pen(Color.Red, (float)(Width / 2 - 2)),
                            (item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 + 24)
                            , (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2 - 4), Width * 2 + 3, Width * 2 + 3);


                        graph.DrawString(item.SignMaxSpeed.Count.ToString(), new Font(font.FontFamily, 10f, FontStyle.Bold,
                           GraphicsUnit.Point, font.GdiCharSet), blackFontBrush,
                           (item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 + 26),
                           (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2));
                    }
                    if (!item.IsBilateral)
                    {
                        graph.DrawImage(Resources.oneWaySign, new Rectangle(item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 + 24,
                           (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2-30), Width * 2 + 3, Width * 2 + 3));
                    }
                }
            }

            if (MakeMap.ViewPort.SelectedEdge != null)
            {
                Pen selectedPen = PensCase.GetPenForEdge(true, false, Width.UnScaling());
                if (MakeMap.ViewPort.SelectedEdge.IsBilateral)
                {
                    selectedPen.StartCap = LineCap.ArrowAnchor;
                    selectedPen.EndCap = LineCap.ArrowAnchor;
                }
                else
                {
                    selectedPen.StartCap = LineCap.Round;
                    selectedPen.EndCap = LineCap.ArrowAnchor;
                }

                graph.DrawLine(selectedPen, MakeMap.ViewPort.SelectedEdge.GetHead().X.UnScaling() + dX, MakeMap.ViewPort.SelectedEdge.GetHead().Y.UnScaling() + dY,
                    MakeMap.ViewPort.SelectedEdge.GetEnd().X.UnScaling() + dX, MakeMap.ViewPort.SelectedEdge.GetEnd().Y.UnScaling() + dY);
                if (MakeMap.ViewPort.IsStreetLength_Visible)
                {
                    graph.DrawString(Math.Round(MakeMap.ViewPort.SelectedEdge.GetLength(MakeMap.ViewPort.ScaleCoefficient), 2).ToString(), new Font(font.FontFamily, 10f, FontStyle.Italic | FontStyle.Bold,
                        GraphicsUnit.Point, font.GdiCharSet), blackFontBrush,
                        (MakeMap.ViewPort.SelectedEdge.GetHead().X.UnScaling() + (MakeMap.ViewPort.SelectedEdge.GetEnd().X.UnScaling() - MakeMap.ViewPort.SelectedEdge.GetHead().X.UnScaling()) / 2 - 25),
                        (MakeMap.ViewPort.SelectedEdge.GetHead().Y.UnScaling() + (MakeMap.ViewPort.SelectedEdge.GetEnd().Y.UnScaling() - MakeMap.ViewPort.SelectedEdge.GetHead().Y.UnScaling()) / 2 - 10));
                }
            }
        }
        /// <summary>
        /// Отрисовывает все перекрестки, содержащиеся на карте
        /// </summary>
        /// <param name="graph"></param>
        public void DrawVertexes(Graphics graph)
        {
            foreach (var item in Map.vertexes.List)
            {
                graph.FillEllipse(PensCase.Point, item.X.UnScaling(), item.Y.UnScaling(), Width, Width);
                if (item.TrafficLight != null && MakeMap.ViewPort.IsTrafficLight_Visible)
                {
                    graph.DrawImage(item.TrafficLight.IsRun ?
                        item.TrafficLight.IsGreen ? Resources.greenLight3 : Resources.redLight3
                        : Resources.nonLight3,
                        new Rectangle((item.X + Width).UnScaling(), (item.Y + Width).UnScaling(), (int)Math.Round(Width * 1.2), Width * 2));
                }
            }
            if (Dynamic.Dynamics != null)
            {
                graph.DrawImage(Resources.Car, new Rectangle(Dynamic.Dynamics.Drive.X.UnScaling() - Width,
                           Dynamic.Dynamics.Drive.Y.UnScaling() - Width, (int)(Width * 3.5), (int)(Width * 3.5)));
            }
            if (MakeMap.ViewPort.SelectedVertex != null)
            {
                graph.FillEllipse(PensCase.SelectedVertex, MakeMap.ViewPort.SelectedVertex.X.UnScaling(), MakeMap.ViewPort.SelectedVertex.Y.UnScaling(), Width, Width);
            }
        }

        public void DrawStartPoint(Graphics graph)
        {
            Pen pen = new Pen(Color.Red);
            DrawPointFlag(graph, pen, Route.Start.X - Width / 2, Route.Start.Y - Width / 2);
        }
        private void DrawPointFlag(Graphics graph, Pen pen, int x, int y)
        {
            pen.Width = 8;
            graph.DrawPolygon(pen, new Point[]{
                new Point((x  + Width  / 2).UnScaling(), (y).UnScaling()),
                new Point((x - Width).UnScaling(), (y - (Width)).UnScaling()),
                new Point((x - Width).UnScaling(), (y - (Width * 2)).UnScaling()),
                new Point((x  + Width  / 2).UnScaling(), (y - (Width * 2)).UnScaling())
            });
        }
        public void DrawEndPoint(Graphics graph)
        {
            Pen pen = new Pen(Color.Blue);
            DrawPointFlag(graph, pen, Route.End.X - Width / 2, Route.End.Y - Width / 2);
        }
        /// <summary>
        /// Пересчитывает величину смещения реальных координат точки, 
        /// относительно положения курсора
        /// </summary>
        public void Resize()
        {
            Viewer.dX = Width / 2;
            Viewer.dY = Width / 2;
        }

    }
}
