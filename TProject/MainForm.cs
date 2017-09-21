using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.Graph;
using TProject.Properties;
using TProject.Way;

namespace TProject
{
    public partial class MainForm : Form
    {
        //Управление интерфейсом
        private int dX, dY, startWidthPB, startHeightPB;
        private bool isClickedOnVertex = false,
                     isClickedOnEdge = false,
                     isCreatingEdge = false,
                     isMoved = false,
                     tlNotInit = true;

        private double zoomCurValue;
        private MouseEventArgs lastMouseEvent;

        Route way = new Route();
        //Используемые коллекции
        private SortedList<double, Image> cache;
        private VertexCollection vertexes;
        private EdgeCollection edges;
        private Image sourceImage;
        private int lastPBLocationX;
        private int lastPBLocationtY;

        public MainForm()
        {
            InitializeComponent();

            pictureBoxMap.Hide();
            pictureBoxMap.Enabled = false;
            vertexes = new VertexCollection();
            edges = new EdgeCollection();

            Sign.Init();
            Coating.Init();
            PensCase.Initialize();

            DoubleBuffered = true;

            zoomCurValue = 1;
            Vertex.Scale = 1;
            startWidthPB = pictureBoxMap.Width;
            startHeightPB = pictureBoxMap.Height;

            TrafficLight.tLightTurn += pictureBoxMap.Invalidate;
            timerTrafficLight.Tick += vertexes.tickTL;
            vertexes.eventUpdateList += pictureBoxMap.Invalidate;
            edges.eventUpdateList += pictureBoxMap.Invalidate;

            pictureBoxMap.Invalidate();
        }



        private void DrawFlag(Graphics e, int x, int y, Color color, int width)
        {
            x = x + Vertex.Radius_2 - 2;
            Point[] p = new Point[]
            {
                new Point(x, y),
                new Point(x - 5, y - 7),
                new Point(x - 5, y - 14),
                new Point(x + 5, y - 14),
                new Point(x + 5, y - 7),
            };
            e.DrawPolygon(new Pen(color, width), p);
        }

        public void RePaint()
        {
            pictureBoxMap.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tlNotInit = false;
            timerTrafficLight.Enabled = true;
            pictureBoxMap.Invalidate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int start = vertexes.ElementsList.FindIndex(o => o.ID == way.Start.ID);
            int end = vertexes.ElementsList.FindIndex(o => o.ID == way.End.ID);
            way.FindMinLengthWay(start, end, vertexes, edges);
        }

        //События pictureBoxMap
        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (lastMouseEvent != null)
                edges.DrawAllOnPicture(g, dX, dY, lastMouseEvent.X, lastMouseEvent.Y, vertexes, isCreatingEdge);
            vertexes.DrawAllOnPicture(g, tlNotInit);

            if (way.Start != null)
            {
                DrawFlag(g, way.Start.X.UnScaling(), way.Start.Y.UnScaling(), Color.Black, 12);
                DrawFlag(g, way.Start.X.UnScaling(), way.Start.Y.UnScaling(), Color.Sienna, 10);
            }
            if (way.End != null)
            {
                DrawFlag(g, way.End.X.UnScaling(), way.End.Y.UnScaling(), Color.Black, 12);
                DrawFlag(g, way.End.X.UnScaling(), way.End.Y.UnScaling(), Color.Red, 10);
            }
        }
        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            isClickedOnVertex = false;
            isCreatingEdge = false;
            isMoved = false;
        }
        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoved && e.Button == MouseButtons.Middle)
            {
                pictureBoxMap.Location = new Point(pictureBoxMap.Location.X + e.X - lastPBLocationX, pictureBoxMap.Location.Y + e.Y - lastPBLocationtY);
            }
            else
            {
                if (isCreatingEdge)
                {
                    lastMouseEvent = e;
                    pictureBoxMap.Invalidate();
                }
                else if (isClickedOnVertex)
                {
                    vertexes.MoveSelVertex(e.X.Scaling(), e.Y.Scaling(), dX, dY);
                    pictureBoxMap.Invalidate();
                }
            }

        }
        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isMoved)
            {
                if (e.Button != MouseButtons.Middle)
                {
                    Vertex v1 = vertexes.SelVertex;
                    isClickedOnVertex = vertexes.SelectVertex(e.X.Scaling(), e.Y.Scaling(), out dX, out dY);
                    if (!isClickedOnVertex)
                    {
                        edges.SelEdge = edges.SearhElementWithCoord(e.X.Scaling(), e.Y.Scaling());
                        isClickedOnEdge = edges.SelEdge != null;
                    }

                    bool isSelectedVertex = isClickedOnVertex;

                    if (e.Button == MouseButtons.Right)
                    {

                        lastMouseEvent = e;

                        editEdgeToolStripMenuItem.Enabled = isClickedOnEdge;
                        editVertexToolStripMenuItem.Enabled = isClickedOnVertex;
                        addVertexToolStripMenuItem.Enabled = !isSelectedVertex && vertexes.IsAllowedRadius(lastMouseEvent.X.Scaling(), lastMouseEvent.Y.Scaling());
                        editVertexToolStripMenuItem.Visible = isSelectedVertex;
                        addEdgeToolStripMenuItem.Enabled = isSelectedVertex & vertexes.GetCountElements() > 0;
                        isClickedOnVertex = false;
                    }
                    else
                    {
                        if (isCreatingEdge && isSelectedVertex)
                        {
                            isSelectedVertex = false;
                            isClickedOnVertex = false;
                            isCreatingEdge = false;

                            if (v1.ID != vertexes.SelVertex.ID)
                                edges.AddElement(new Edge(v1, vertexes.SelVertex));
                        }
                        else
                        {
                            isCreatingEdge = false;
                            pictureBoxMap.Invalidate();
                        }
                    }
                }
                else
                {
                    isMoved = true;
                    lastPBLocationX = e.X;
                    lastPBLocationtY = e.Y;
                }
            }
            pictureBoxMap.Invalidate();
        }





        private void toList()
        {
                for (double i = 0.6; i < 1.5; i = i + 0.2)
                    cache.Add(Math.Round(i,1), (new Bitmap(sourceImage, new Size((int)(startWidthPB * i), (int)(startHeightPB * i)))));
        }

        private void pictureBoxMap_Zoom(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && zoomCurValue <= 2 || e.Delta < 0 && zoomCurValue >= 0.6)
            {
                panelMapSubstrate.AutoScroll = false;
                zoomCurValue += e.Delta > 0 ? 0.2 : -0.2;
                Vertex.Scale = zoomCurValue = Math.Round(zoomCurValue, 1);

                if (cache.ContainsKey(zoomCurValue))
                    pictureBoxMap.Image = cache[zoomCurValue];
                else
                {
                    Image a = new Bitmap(sourceImage, new Size(startWidthPB.UnScaling(), startHeightPB.UnScaling()));
                    pictureBoxMap.Image = a;
                    cache.Add(zoomCurValue, a);
                }
                pictureBoxMap.Size = pictureBoxMap.Image.Size; 

                panelMapSubstrate.AutoScroll = true;
            }
          
        }


        //События Вершины и ребра
        private void addVertexToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            vertexes.AddElement(new Vertex(lastMouseEvent.X.Scaling(), lastMouseEvent.Y.Scaling()));
        }
        private void addEdgeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            isCreatingEdge = true;
        }
        private void subMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openSubMapFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs = new System.IO.FileStream(openSubMapFileDialog.FileName, System.IO.FileMode.Open);
                Image img = Image.FromStream(fs);
                fs.Close();

                sourceImage = img;

                pictureBoxMap.Width = startWidthPB = img.Width;
                pictureBoxMap.Height = startHeightPB = img.Height;

                pictureBoxMap.Image = img;
                Vertex.Scale = 1;

                cache = new SortedList<double, Image>();
                toList();

                panelMapSubstrate.MouseWheel += new MouseEventHandler(pictureBoxMap_Zoom);
                pictureBoxMap.Paint += new PaintEventHandler(pictureBoxMap_Paint);
                pictureBoxMap.MouseDown += new MouseEventHandler(pictureBoxMap_MouseDown);
                pictureBoxMap.MouseMove += new MouseEventHandler(pictureBoxMap_MouseMove);
                pictureBoxMap.MouseUp += new MouseEventHandler(pictureBoxMap_MouseUp);
                pictureBoxMap.Enabled = true;
                pictureBoxMap.Show();
            }
        }   

       

       


        /// <summary>
        /// Маршрут из
        /// </summary>
        private void wayFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            way.Start = vertexes.SelVertex;
            pictureBoxMap.Invalidate();
        }
        /// <summary>
        /// Маршрут в
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wayToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            way.End = vertexes.SelVertex;
            pictureBoxMap.Invalidate();
        }

        /// <summary>
        /// Редактирование параметров перегона
        /// </summary>
        private void editEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isClickedOnEdge)
            {
                using (EditEdge form = new EditEdge(edges.SelEdge))
                {
                    form.Owner = this;
                    form.ShowDialog();
                    edges.SelEdge = form.Edge;
                    pictureBoxMap.Invalidate();
                }
            }
        }
        /// <summary>
        /// Редактирование параметров перекрестка
        /// </summary>
        private void editVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditVertex form = new EditVertex(vertexes.SelVertex))
            {
                form.Owner = this;
                form.ShowDialog();
                vertexes.SelVertex = form.Vertex;
                if (vertexes.SelVertex.TrafficLight != null)
                    vertexes.tlList.Add(vertexes.SelVertex.TrafficLight);
                pictureBoxMap.Invalidate();
            }
        }
    }

    public static class Extendets
    {
        public static int Scaling(this int value)
        {
            return (int)(value / Vertex.Scale);
        }
        public static int UnScaling(this int value)
        {
            return (int)(value * Vertex.Scale);
        }
    }
}
