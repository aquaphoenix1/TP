using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            vertexList = new VertexCollection();
            edgeList = new EdgeCollection();
        }

        //кисти для расскраски
        private Pen activVertex = new Pen(Color.Aqua, Vertex.Radius / 2);
        private Pen generalVertex = new Pen(Brushes.DarkBlue, Vertex.Radius / 2);

        private int dX, dY;
        private bool isClicked = false;
        private bool isCreatingEdge = false;

        //Работа с вершинами
        private VertexCollection vertexList;
        private EdgeCollection edgeList;

        private Rectangle rectOfselectedVertex;
        private Vertex selectedVertex;
        private MouseEventArgs lastEvent;

        private void AddNewVertex()
        {
            vertexList.AddElement(new Vertex(lastEvent.X, lastEvent.Y));
            pictureBoxMap.Invalidate();
        }
        private void DrawAdllEdge(PaintEventArgs e)
        {
            if (isCreatingEdge)
                e.Graphics.DrawLine(activVertex,
                     rectOfselectedVertex.X + dX + 1, rectOfselectedVertex.Y + dY,
                     lastEvent.X, lastEvent.Y
                     );

            foreach (var r in edgeList.GetElementsList())
                e.Graphics.DrawLine(generalVertex, 
                    r.GetVertexA().X + Vertex.Radius / 2, r.GetVertexA().Y + Vertex.Radius / 2,
                    r.GetVertexB().X + Vertex.Radius / 2, r.GetVertexB().Y + Vertex.Radius / 2
                    );
        }
        private void DrawAllVertex(PaintEventArgs e)
        {
            if (selectedVertex != null)
                e.Graphics.DrawEllipse(activVertex, rectOfselectedVertex);
            foreach (var r in vertexList.GetElementsList())
                e.Graphics.DrawEllipse(generalVertex, r.PointOnMap);
        }
        private void DropeVertex()
        {
            if (selectedVertex != null)
            {
                selectedVertex.PointOnMap = rectOfselectedVertex;
                vertexList.AddElement(selectedVertex);
            }
        }
        private void MoveVertex(MouseEventArgs e)
        {
            rectOfselectedVertex.X = e.X - dX;
            rectOfselectedVertex.Y = e.Y - dY;
        }
        private void MoveCursor(MouseEventArgs e)
        {
            lastEvent = e;
        }
        private bool SelectVertex(MouseEventArgs e)
        {
            bool res = false;
            selectedVertex = vertexList.SearhVertexPoint(e.X, e.Y);
            if (res = selectedVertex != null)
            {
                rectOfselectedVertex = selectedVertex.PointOnMap;
                vertexList.RemoveElement(selectedVertex);

                isClicked = true;
                dX = e.X - rectOfselectedVertex.X;
                dY = e.Y - rectOfselectedVertex.Y;
            }
            return res;
        }

        //События формы
        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            DrawAllVertex(e);
            DrawAdllEdge(e);
        }

        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
            isCreatingEdge &= false; 
            DropeVertex();
        }

        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                MoveVertex(e);
            }
            if (isCreatingEdge)
            {
                MoveCursor(e);
            }
            pictureBoxMap.Invalidate();
        }

        private void addVertexToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AddNewVertex();
        }
        private void editVertexToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void addEdgeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            isCreatingEdge = true;
        }

        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            Vertex v1 = selectedVertex;

            bool isSelectedVertex = SelectVertex(e);

            if (e.Button == MouseButtons.Right)
            {
                lastEvent = e;
                isClicked = false;

                addVertexToolStripMenuItem.Enabled = !isSelectedVertex;
                editVertexToolStripMenuItem.Visible = isSelectedVertex;
                addEdgeToolStripMenuItem.Enabled = isSelectedVertex & vertexList.GetCountElements() > 0; ////???????

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
                    edgeList.AddElement(new Edge(v1, selectedVertex));
                    pictureBoxMap.Invalidate();
                }
            }
        }
    }
}
