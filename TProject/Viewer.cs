using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.Graph;

namespace TProject
{
    class Viewer
    {
        /// <summary>
        /// основной на котором отрисовывается подложка и графPictureBox
        /// </summary>
        private PictureBox view;
        /// <summary>
        /// Расположение pb в контейнере до перемещения
        /// </summary>
        public int MapLocationX { get; set; }
        public int MapLocationY { get; set; }

        public int VertexLocationX { get; set; }
        public int VertexLocationY { get; set; }

        public delegate void ReDraw();

        /// <summary>
        /// Контейнер основного PictureBox
        /// </summary>
        private Panel substrate;
        /// <summary>
        /// Смещение курсора от центра точки
        /// </summary>
        private int dX, dY;
        /// <summary>
        /// Исходный размер pictureBox
        /// </summary>
        private int startWidthPB, startHeightPB;
        /// <summary>
        /// Высота точки
        /// </summary>
        public static int Width{ get; private set;}
        /// <summary>
        /// Ширина точки
        /// </summary>
        public static int Height { get; private set; }
        /// <summary>
        /// Текущий масштаб
        /// </summary>
        private double zoomCurValue;

        public static Viewer ViewPort = null;

        private Vertex selectedVertex = null;
        private Edge selectedEdge = null;

        public void SaveCreatedEdge()
        {
            selectedEdge.SetEnd(selectedVertex);
            Map.edges.Add(selectedEdge);

            selectedVertex = null;
            selectedEdge = null;
        }

        public void CreateEdge(int x, int y)
        {
            selectedEdge = new Edge(new Vertex(x, y), new Vertex(x, y));
        }

        public static void CreateViewer(PictureBox pb, Panel panel)
        {
            ViewPort = new Viewer(pb, panel);
        }

        public void Tooo()
        {

        }
        public void Invalidate()
        {
            view.Invalidate();
        }

        private Viewer(PictureBox pb, Panel panel)
        {
            if (ViewPort == null)
            {
                MapLocationX = 0;
                MapLocationY = 0;

                Width = 6;
                Height = 6;

                zoomCurValue = 1;
                view = pb;
                substrate = panel;
                view.Hide();
                view.Enabled = false;

                view.Paint += Paint;

                ViewPort = this;
            }
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Brush pen;

            pen = PensCase.Point;
            foreach (var item in Map.vertexes.List)
                if(selectedVertex != item)
                    graph.FillEllipse(pen, item.X, item.Y, Width, Height);

            if (selectedVertex != null)
            {
                pen = PensCase.SelectedVertex;
                graph.FillEllipse(pen, selectedVertex.X, selectedVertex.Y, Width, Height);
            }


            Pen p = PensCase.GeneralEdgeAtoB;
            if (selectedEdge != null)
                graph.DrawLine(p, selectedEdge.GetHead().X, selectedEdge.GetHead().Y,
                    selectedEdge.GetEnd().X, selectedEdge.GetEnd().Y);

            foreach (var item in Map.edges.List)
            {
                graph.DrawLine(p, item.GetHead().X, item.GetHead().Y,
                   item.GetEnd().X, item.GetEnd().Y);
            }

        }

        public void Select(Vertex vertex)
        {
            selectedVertex = vertex;
        }
        public void UnSelect()
        {
            selectedVertex = null;
            selectedEdge = null;
        }

        public void MoveVertex(int x, int y)
        {
            selectedVertex.X = x - Width / 2;
            selectedVertex.Y = y - Height / 2;
        }

        public void MoveViewPort(int x, int y)
        {
            view.Location = new Point(view.Location.X + x - MapLocationX, view.Location.Y + y - MapLocationY);
        }

        public void OpenPicture(string fname)
        {
            using (FileStream fs = new FileStream(fname, FileMode.Open))
            {
                Image img = Image.FromStream(fs);
                view.Image = img;

                view.Enabled = true;
                view.Visible = true;
            }
        }

        public void ModifyCreatedEdge(int x, int y)
        {
            selectedEdge.SetEnd(new Vertex(x, y));
        }

        /// <summary>
        /// Определяет, есть ли вершина в заданной точке
        /// </summary>
        /// <param name="x1">Координата точки на карте</param>
        /// <param name="y1">Координата точки на карте</param>
        /// <param name="x2">Координата вершины</param>
        /// <param name="y2">Координата вершины</param>
        /// <returns></returns>
        public static bool IsPointInRectangle(int x1, int y1, int x2, int y2)
        {
            return x1 + Width >= x2 && y1 + Height >= y2 && x2 >= x1 && y2 >= y1;
        }

    }
}
