using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TProject
{
    public partial class MainForm : Form
    {
        //Управление интерфейсом
        private int dX, dY;
        private int startWidthPB, startHeightPB;
        private bool isClickedOnVertex = false,
                     isCreatingEdge = false;

        private double zoomCurValue;
        private MouseEventArgs lastMouseEvent;
        PaintEventArgs lastPaintEvents;

       
        //Используемые коллекции
        private VertexCollection vertexes;
        private EdgeCollection edges;

        public MainForm()
        {
            InitializeComponent();
            vertexes = new VertexCollection();
            edges = new EdgeCollection();
            zoomCurValue = 1;
            startWidthPB = pictureBoxMap.Width;
            startHeightPB = pictureBoxMap.Height;

            Vertex.Scale = 1;


            pictureBoxMap.Invalidate();
        }

      
        //События pictureBoxMap
        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            lastPaintEvents = e;
            if (lastMouseEvent != null)
                edges.DrawAllOnPicture(e, dX, dY, lastMouseEvent.X, lastMouseEvent.Y, vertexes, isCreatingEdge);
            vertexes.DrawAllOnPicture(e.Graphics);
        }
        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            isClickedOnVertex = false;
            isCreatingEdge = false;
        }
        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClickedOnVertex && !isCreatingEdge)
            {
                vertexes.MoveSelVertex(e.X.Scaling(), e.Y.Scaling(), dX, dY);
            }
            if (isCreatingEdge)
            {
                lastMouseEvent = e;
            }
            pictureBoxMap.Invalidate();
        }
        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {

            Vertex v1 = vertexes.SelVertex;
            isClickedOnVertex = vertexes.SelectVertex(e.X.Scaling(), e.Y.Scaling(), ref dX, ref dY);

            bool isSelectedVertex = isClickedOnVertex;

            if (e.Button == MouseButtons.Right)
            {
                lastMouseEvent = e;
                isClickedOnVertex = false;

                addVertexToolStripMenuItem.Enabled = !isSelectedVertex && vertexes.IsAllowedRadius(lastMouseEvent.X.Scaling(), lastMouseEvent.Y.Scaling());
                editVertexToolStripMenuItem.Visible = isSelectedVertex;
                addEdgeToolStripMenuItem.Enabled = isSelectedVertex & vertexes.GetCountElements() > 0; 
            }
            else
            {
                if (isCreatingEdge && isSelectedVertex)
                {
                    isClickedOnVertex = false;
                    isCreatingEdge = false;

                    if (v1.Id != vertexes.SelVertex.Id)
                        edges.AddElement(new Edge(v1, vertexes.SelVertex));
                    pictureBoxMap.Invalidate();
                }
            }
        }
        
        private void pictureBoxMap_Zoom(object sender, MouseEventArgs e)
        {
            //if (zoomCurValue >= 1 || e.Delta > 0)
            {
                zoomCurValue += e.Delta > 0 ? 0.1 : -0.1;
                Vertex.Scale = zoomCurValue;

                pictureBoxMap.Size = new Size((int)(startWidthPB * zoomCurValue), (int)(startHeightPB * zoomCurValue));
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
                this.DoubleBuffered = true;

                System.IO.FileStream fs = new System.IO.FileStream(openSubMapFileDialog.FileName, System.IO.FileMode.Open);
                System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
                fs.Close();
                startHeightPB = img.Height;
                startWidthPB = img.Width;
                pictureBoxMap.Width = startWidthPB;
                pictureBoxMap.Height = startHeightPB;

                pictureBoxMap.Image = img;
                Vertex.Scale = 1;
            }
        }

        //события светофоры
        private void добавитьСветофорToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (vertexes.SelVertex != null && vertexes.SelVertex.TrafficLight == null)
            {
                AddTrafficLightForm form = new AddTrafficLightForm();
                form.ShowDialog();
                if(form.AcceptButton.DialogResult == DialogResult.OK)
                    vertexes.SelVertex.TrafficLight = new TrafficLight(form.GetGreenSeconds(), form.GetRedSeconds());
            }
        }
        private void удалитьСветофорToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (vertexes.SelVertex != null && vertexes.SelVertex.TrafficLight != null)
                vertexes.SelVertex.TrafficLight = null;
        }
        private void редактироватьСветофорToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (vertexes.SelVertex != null && vertexes.SelVertex.TrafficLight != null)
            {
                AddTrafficLightForm form = new AddTrafficLightForm(vertexes.SelVertex.TrafficLight.GreenSeconds, vertexes.SelVertex.TrafficLight.RedSeconds);
                form.ShowDialog();
                if (form.AcceptButton.DialogResult == DialogResult.OK)
                {
                    vertexes.SelVertex.TrafficLight.GreenSeconds = form.GetGreenSeconds();
                    vertexes.SelVertex.TrafficLight.RedSeconds = form.GetRedSeconds();
                }
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
