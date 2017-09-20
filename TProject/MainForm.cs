using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TProject
{
    public partial class MainForm : Form
    {
        //Управление интерфейсом
        private int dX, dY;
        private int startWidthPB, startHeightPB;
        private bool isClickedOnVertex = false,
                     isClickedOnEdge = false,
                     isCreatingEdge = false,
                     isMoved = false;

        private double zoomCurValue;
        private MouseEventArgs lastMouseEvent;

        //Используемые коллекции
        private VertexCollection vertexes;
        private EdgeCollection edges;
        private Image sourceImage;
        private int lastX;
        private int lastY;

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            vertexes = new VertexCollection();
            vertexes.eventUpdateList += pictureBoxMap.Invalidate;
            edges = new EdgeCollection();
            edges.eventUpdateList += pictureBoxMap.Invalidate;
            zoomCurValue = 1;
            startWidthPB = pictureBoxMap.Width;
            startHeightPB = pictureBoxMap.Height;

            Vertex.Scale = 1;
            PensCase.Initialize();
            pictureBoxMap.Invalidate();

        }

        //События pictureBoxMap
        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (lastMouseEvent != null)
                edges.DrawAllOnPicture(g, dX, dY, lastMouseEvent.X, lastMouseEvent.Y, vertexes, isCreatingEdge);
            vertexes.DrawAllOnPicture(g);
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
                pictureBoxMap.Location = new Point(pictureBoxMap.Location.X + e.X - lastX, pictureBoxMap.Location.Y + e.Y - lastY);
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
                    lastX = e.X;
                    lastY = e.Y;
                }
            }

        }



        private void pictureBoxMap_Zoom(object sender, MouseEventArgs e)
        {
            panelMapSubstrate.AutoScroll = false;

            zoomCurValue += e.Delta > 0 ? 0.1 : -0.1;
            Vertex.Scale = zoomCurValue;

            pictureBoxMap.Image = new Bitmap(sourceImage, new Size(startWidthPB.UnScaling(), startHeightPB.UnScaling()));

            pictureBoxMap.Size = new Size(startWidthPB.UnScaling(), startHeightPB.UnScaling());
            panelMapSubstrate.AutoScroll = true;
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
            }
        }

        public void RePaint()
        {
            pictureBoxMap.Invalidate();
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            FindMinLengthWay(0, 3);
        }

        private void editVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isClickedOnVertex)
            {
                using (EditVertex form = new EditVertex(vertexes.SelVertex))
                {
                    form.Owner = this;
                    form.ShowDialog();
                    vertexes.SelVertex = form.Vertex;
                    pictureBoxMap.Invalidate();
                }
            }
        }

        private Edge GetEdge(Vertex one, Vertex two)
        {
            List<Edge> list = edges.GetElementsList();
            Vertex first = null, second = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].IsBilateral)
                {
                    if (list[i].GetHead() == one && (second = list[i].GetEnd()) == two && list[i].isConnected(second))
                        return list[i];
                }
                else
                {
                    first = list[i].GetHead();
                    second = list[i].GetEnd();
                    if (((first == one && second == two) || (second == one && first == two)))
                        return list[i];
                }
            }
            return null;
        }

        private int[,] GetMatrixWay(out int[,] parents, out long[] arrayOfID)
        {
            int count = vertexes.GetCountElements();

            int[,] array = new int[count, count];

            parents = new int[count, count];

            arrayOfID = new long[count];

            List<Vertex> vertexList = vertexes.GetElementsList();

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i == j) array[i, j] = 0;
                    else
                    {
                        Edge edge = GetEdge(vertexList[i], vertexList[j]);
                        array[i, j] = (edge != null) ? edge.GetLength() : Int32.MaxValue;
                    }
                    parents[i, j] = i;
                }
                arrayOfID[i] = vertexList[i].ID;
            }
            return array;
        }

        private int FindMinLengthWay(int fromVertex, int toVertex)
        {
            int[,] parents;
            long[] IDs;
            int[,] matrix = GetMatrixWay(out parents, out IDs);
            int size = (int)Math.Sqrt(matrix.Length);

            int length = 0;

            List<int> vertexes = new List<int>();
            List<int> edges = new List<int>();

            for (int k = 0; k < size; ++k)
                for (int i = 0; i < size; ++i)
                    for (int j = 0; j < size; ++j)
                        if (matrix[i, k] < Int32.MaxValue && matrix[k, j] < Int32.MaxValue && matrix[i, k] + matrix[k, j] < matrix[i, j])
                        {
                            matrix[i, j] = matrix[i, k] + matrix[k, j];
                            parents[i, j] = k;
                        }

            List<int> way = GetWay(0, 3, parents);
            string s = String.Empty;

            for (int i = 0; i < way.Count; i++)
                s += IDs[way[i]].ToString() + "\n";

            MessageBox.Show(s);

            return length;
        }

        public List<int> GetWay(int from, int to, int[,] arrayOfParents)
        {
            List<int> list = new List<int>();
            list.Add(to);

            int vert = arrayOfParents[from, to];

            while (vert != 0)
            {
                list.Add(vert);

                vert = arrayOfParents[from, vert];
            }

            list.Add(from);

            list.Reverse();

            return list;
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
