using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TProject
{
    public partial class MainForm : Form
    {
        //Управление интерфейсом
        private int dX, dY;
        private bool isClickedOnVertex = false,
                     isCreatingEdge = false;
        private MouseEventArgs lastEvent;

        //Используемые коллекции
        private VertexCollection vertexes;
        private EdgeCollection edges;

        public MainForm()
        {
            InitializeComponent();
            vertexes = new VertexCollection();
            edges = new EdgeCollection();
        }

      
        //События pictureBoxMap
        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            if (lastEvent != null)
                edges.DrawAllOnPicture(e, dX, dY, lastEvent.X, lastEvent.Y, vertexes, isCreatingEdge);
            vertexes.DrawAllOnPicture(e);
        }
        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            isClickedOnVertex = false;
            isCreatingEdge = false; 
        }
        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClickedOnVertex)
            {
                vertexes.MoveSelVertex(e.X, e.Y, dX, dY);
            }
            if (isCreatingEdge)
            {
                lastEvent = e;
            }
            pictureBoxMap.Invalidate();
        }
        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            Vertex v1 = vertexes.SelVertex;
            isClickedOnVertex = vertexes.SelectVertex(e.X, e.Y, ref dX, ref dY);

            bool isSelectedVertex = isClickedOnVertex;

            if (e.Button == MouseButtons.Right)
            {
                lastEvent = e;
                isClickedOnVertex = false;

                addVertexToolStripMenuItem.Enabled = !isSelectedVertex && vertexes.IsAllowedRadius(lastEvent.X, lastEvent.Y);
                editVertexToolStripMenuItem.Visible = isSelectedVertex;
                addEdgeToolStripMenuItem.Enabled = isSelectedVertex & vertexes.GetCountElements() > 0; ////???????

                #region это работает(на всякий случай)
                //if (!isSelectedVertex && vertexList.GetCountElements() > 1)
                //{
                //    addVertexToolStripMenuItem.Enabled = true;
                //    addEdgeToolStripMenuItem.Enabled = false;
                //    editVertexToolStripMenuItem.Visible = false;
                //}
                //if (isSelectedVertex)
                //{
                //    addVertexToolStripMenuItem.Enabled = false;
                //    addEdgeToolStripMenuItem.Enabled = true;
                //    editVertexToolStripMenuItem.Visible = true;
                //}
                #endregion
            }
            else
            {
                if (isCreatingEdge && isSelectedVertex)
                {
                    edges.AddElement(new Edge(v1, vertexes.SelVertex));
                    pictureBoxMap.Invalidate();
                }
            }
        }


        //События Вершины и ребра
        private void addVertexToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            vertexes.AddElement(new Vertex(lastEvent.X, lastEvent.Y));
        }
        private void addEdgeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            isCreatingEdge = true;
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
}
