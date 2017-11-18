using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.Graph;

namespace TProject
{
    public partial class Main : Form
    {

        /// <summary>
        /// Показывает, перемещается ли в данный момент карта
        /// </summary>
        bool isMapMoved = false;
        bool isVertexMoved = false;

        bool isCreatedEdge = false;


        private int lastClickCoordX = 0;
        private int lastClickCoordY = 0;

        public Main()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }


        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isVertexMoved && !isMapMoved)
            {
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        lastClickCoordX = e.X;
                        lastClickCoordY = e.Y;
                        if (Map.vertexes.GetSelected(e.X, e.Y))
                        {
                            addVertexToolStripMenuItem.Visible = false;
                            addEdgeToolStripMenuItem.Visible = true;
                            editVertexToolStripMenuItem.Visible = true;
                            editEdgeToolStripMenuItem.Visible = false;
                            wayFromToolStripMenuItem.Visible = true;
                            wayToВToolStripMenuItem.Visible = true;
                        }
                        else
                        {
                            addVertexToolStripMenuItem.Visible = true;
                            editEdgeToolStripMenuItem.Visible = false;
                            editVertexToolStripMenuItem.Visible = false;
                            addEdgeToolStripMenuItem.Visible = false;
                            wayFromToolStripMenuItem.Visible = false;
                            wayToВToolStripMenuItem.Visible = false;
                        }
                        break;
                    case MouseButtons.Left:
                        if (isCreatedEdge)
                        {
                            if ((isVertexMoved = Map.vertexes.GetSelected(e.X, e.Y)))
                            {
                                isVertexMoved = false;
                                Viewer.ViewPort.SaveCreatedEdge();
                            }
                            Cursor = Cursors.Arrow;
                        }
                        else if (!(isVertexMoved = Map.vertexes.GetSelected(e.X, e.Y)))
                        {
                            Map.edges.GetSelected(e.X, e.Y);
                            Viewer.ViewPort.UnSelectVertex();
                        }
                        else
                            Viewer.ViewPort.UnSelectEdge();
                        break;
                    case MouseButtons.Middle:
                        Viewer.ViewPort.MapLocationX = e.X;
                        Viewer.ViewPort.MapLocationY = e.Y;
                        isMapMoved = true;
                        break;
                }
            }
            if (isCreatedEdge)
            {
                isCreatedEdge = false;
            }
            Viewer.ViewPort.Invalidate();
        }

        private void subMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.InitMap();
            Viewer.CreateViewer(pictureBoxMap, panelMapSubstrate);

            Map.vertexes.RePaint += Viewer.ViewPort.Invalidate;
            Map.edges.RePaint += Viewer.ViewPort.Invalidate;

            if (openSubMapFileDialog.ShowDialog() == DialogResult.OK)
                Viewer.ViewPort.OpenPicture(openSubMapFileDialog.FileName);
            Viewer.ViewPort.Invalidate();
        }

        private void addVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.CreateVertex(lastClickCoordX, lastClickCoordY);
        }

        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMapMoved)
            {
                Viewer.ViewPort.MoveViewPort(e.X, e.Y);
            }
            if (isVertexMoved)
            {
                Viewer.ViewPort.MoveVertex(e.X, e.Y);
                Viewer.ViewPort.Invalidate();
            }
            if (isCreatedEdge)
            {
                Viewer.ViewPort.ModifyCreatedEdge(e.X, e.Y);
                Viewer.ViewPort.Invalidate();
            }
        }

        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Middle:
                    isMapMoved = false;
                    break;
                case MouseButtons.Left:
                    if (isVertexMoved)
                        isVertexMoved = false;
                    break;
            }
            Viewer.ViewPort.Invalidate();
        }

        private void addEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isCreatedEdge = true;
            Viewer.ViewPort.CreateEdge(lastClickCoordX, lastClickCoordY);
            Cursor = Cursors.Cross;
        }
    }
}
