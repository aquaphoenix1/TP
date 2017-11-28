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

        private Vertex selectedLabel = null;
        private Edge callibrationEdge = null;

        bool slide = false;
        private int lastClickCoordX = 0;
        private int lastClickCoordY = 0;

        public Main()
        {
            InitializeComponent();

            button_Ok_Сalibration.Enabled = false;

            textBox_CurrentCoefficient.Text = 1.ToString();
            label_Layers.Text = "";
            label_Layers.AutoSize = false;
            label_Layers.NewText = "С л о и";
            label_Layers.RotateAngle = -92;
            label_Layers.Size = new Size(38, 70);
            label_Layers.Location = new Point(-16, panelSlideContainer.Height / 2 - 40);
            label_Layers.Click += PanelSlide_Click;

            panelSlide.Controls.Add(label_Layers);

            DoubleBuffered = true;
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            label_Layers.Location = new Point(-17, panelSlideContainer.Height / 2 - 40);
        }

        private void PictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isVertexMoved && !isMapMoved)
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        {
                            lastClickCoordX = e.X;
                            lastClickCoordY = e.Y;
                            if (Map.vertexes.GetSelected(e.X, e.Y))
                            {
                                Viewer.ViewPort.View.ContextMenuStrip = contextMenuVertex;
                            }
                            else if (Map.edges.GetSelected(e.X, e.Y))
                            {
                                Viewer.ViewPort.View.ContextMenuStrip = contextMenuEdge;
                            }
                            else
                            {
                                Viewer.ViewPort.View.ContextMenuStrip = contextMenuMap;
                            }
                        }
                        break;
                    case MouseButtons.Left:
                        {
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
                        }
                        break;
                    case MouseButtons.Middle:
                        {
                            Viewer.ViewPort.MapLocationX = e.X;
                            Viewer.ViewPort.MapLocationY = e.Y;
                            isMapMoved = true;
                        }
                        break;
                }
            if (isCreatedEdge)
            {
                isCreatedEdge = false;
            }
            Viewer.ViewPort.Invalidate();
        }

        private void PictureBoxMap_MouseMove(object sender, MouseEventArgs e)
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

        private void PictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Middle:
                    {
                        isMapMoved = false;
                    }
                    break;
                case MouseButtons.Left:
                    {
                        if (isVertexMoved)
                            isVertexMoved = false;
                    }
                    break;
            }
            Viewer.ViewPort.Invalidate();
        }

        private void ToolStripMenu_SubMap_Click(object sender, EventArgs e)
        {
            Map.InitMap();
            Viewer.CreateViewer(pictureBoxMap, panelMapSubstrate, Font);

            Map.vertexes.RePaint += Viewer.ViewPort.Invalidate;
            Map.edges.RePaint += Viewer.ViewPort.Invalidate;

            if (openSubMapFileDialog.ShowDialog() == DialogResult.OK)
                Viewer.ViewPort.OpenPicture(openSubMapFileDialog.FileName);
            Viewer.ViewPort.Invalidate();
        }

        private void ToolStripMenu_AddVertex_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.CreateVertex(lastClickCoordX, lastClickCoordY);
        }

        private void ToolStripMenu_AddEdge_Click(object sender, EventArgs e)
        {
            isCreatedEdge = true;
            Viewer.ViewPort.CreateEdge(lastClickCoordX, lastClickCoordY);
            Cursor = Cursors.Cross;
        }

        private void ToolStripMenu_EditVertex_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.EditVertexOptions();
        }

        private void ToolStripMenu_EditEdge_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.EditEdgeOptions();
        }

        private void ToolStripMenu_WayFrom_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenu_WayToВ_Click(object sender, EventArgs e)
        {

        }

        private void PanelSlide_Click(object sender, EventArgs e)
        {
            if ((slide = !slide))
                panelSlideContainer.Size = new Size(205, panelSlideContainer.Size.Width);
            else
                panelSlideContainer.Size = new Size(23, panelSlideContainer.Size.Width);
            panelSlide.SendToBack();
        }

        private void Button_Calibration_Click(object sender, EventArgs e)
        {
            button_Ok_Сalibration.Enabled = true;
            button_Calibration.Enabled = false;
            callibrationEdge = new Edge(new Vertex(20.UnScaling(), 50.UnScaling()),new Vertex(60.UnScaling(), 50.UnScaling()));
            Viewer.ViewPort.Invalidate();

            Viewer.ViewPort.View.MouseDown -= PictureBoxMap_MouseDown;
            Viewer.ViewPort.View.MouseMove -= PictureBoxMap_MouseMove;
            Viewer.ViewPort.View.MouseUp -= PictureBoxMap_MouseUp;

            Viewer.ViewPort.View.MouseDown += Сalibration_MouseDown;
            Viewer.ViewPort.View.MouseMove += Сalibration_MouseMove;
            Viewer.ViewPort.View.MouseUp += Сalibration_MouseUp;

            Viewer.ViewPort.View.Paint += View_Paint;
        }

        private void button_Ok_Сalibration_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.ScaleCoefficient = 100 / (callibrationEdge.GetLength(1));

            textBox_CurrentCoefficient.Text = Viewer.ViewPort.ScaleCoefficient.ToString();

            Viewer.ViewPort.View.MouseDown += PictureBoxMap_MouseDown;
            Viewer.ViewPort.View.MouseMove += PictureBoxMap_MouseMove;
            Viewer.ViewPort.View.MouseUp += PictureBoxMap_MouseUp;

            Viewer.ViewPort.View.MouseDown -= Сalibration_MouseDown;
            Viewer.ViewPort.View.MouseMove -= Сalibration_MouseMove;
            Viewer.ViewPort.View.MouseUp -= Сalibration_MouseUp;
            Viewer.ViewPort.View.Paint -= View_Paint;

            callibrationEdge = null;
            Viewer.ViewPort.Invalidate();

            button_Ok_Сalibration.Enabled = false;
            button_Calibration.Enabled = true;
        }


#region Калибровка
        private void View_Paint(object sender, PaintEventArgs e)
        {
            int dX = Viewer.Width;
            if (selectedLabel != null)
                e.Graphics.FillEllipse(PensCase.SelectedVertex, selectedLabel.X.UnScaling(), selectedLabel.Y.UnScaling(), dX, dX);
            e.Graphics.FillEllipse(PensCase.Point, callibrationEdge.GetHead().X.UnScaling(), callibrationEdge.GetHead().Y.UnScaling(), dX, dX);

            e.Graphics.FillEllipse(PensCase.Point, callibrationEdge.GetEnd().X.UnScaling(), callibrationEdge.GetEnd().Y.UnScaling(), dX, dX);
            if (callibrationEdge != null)
            {
                int x1 = callibrationEdge.GetHead().X.UnScaling() + dX / 2;
                int x2 = callibrationEdge.GetEnd().X.UnScaling() + dX / 2;
                int y1 = callibrationEdge.GetHead().Y.UnScaling() + dX / 2;
                e.Graphics.DrawLine(PensCase.SelectedEdgeBilater, x1, y1, x2, y1);
                Brush b = new SolidBrush(Color.Black);
                e.Graphics.DrawString(100.ToString(), new Font(Font.FontFamily, 10f, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Point, Font.GdiCharSet), b, (x1 + (x2 - x1) / 2 - 25), (y1 - 16));
            }
        }
        private void Сalibration_MouseDown(object sender, MouseEventArgs e)
        {
            int X = e.X;
            int Y = e.Y;
            if (!isVertexMoved && e.Button == MouseButtons.Left)
            {
                if (Viewer.IsPointInRectangle(callibrationEdge.GetHead().X, callibrationEdge.GetHead().Y, e.X, e.Y))
                {
                    selectedLabel = callibrationEdge.GetHead();
                    isVertexMoved = true;
                }
                else if (Viewer.IsPointInRectangle(callibrationEdge.GetEnd().X, callibrationEdge.GetEnd().Y, e.X, e.Y))
                {
                    isVertexMoved = true;
                    selectedLabel = callibrationEdge.GetEnd();
                } else if (Viewer.IsPointOnEdge(e.X, e.Y, callibrationEdge.GetHead().X, callibrationEdge.GetHead().Y,
                    callibrationEdge.GetEnd().X, callibrationEdge.GetEnd().Y + Viewer.Height))
                {
                    isCreatedEdge = true;
                }
            }
            else
            {
                lastClickCoordX = e.X;
                lastClickCoordY = e.Y;
            }
        }
        private void Сalibration_MouseMove(object sender, MouseEventArgs e)
        {
            if (isVertexMoved)
            {
                selectedLabel.X = e.X.Scaling();
                callibrationEdge.GetHead().Y = callibrationEdge.GetEnd().Y = e.Y.Scaling();
                Viewer.ViewPort.Invalidate();
                textBox_CurrentCoefficient.Text = (100 / (callibrationEdge.GetLength(1))).ToString();
            }
            else if (isCreatedEdge)
            {
                int dx = Math.Abs(callibrationEdge.GetHead().X - callibrationEdge.GetEnd().X);
                callibrationEdge.GetHead().X = (e.X.Scaling() - dx / 2);
                callibrationEdge.GetEnd().X = (e.X.Scaling() + dx / 2);
                callibrationEdge.GetHead().Y = callibrationEdge.GetEnd().Y = e.Y.Scaling();
                Viewer.ViewPort.Invalidate();
            }
        }
        private void Сalibration_MouseUp(object sender, MouseEventArgs e)
        {
            isVertexMoved = false;
            isCreatedEdge = false;
            selectedLabel = null;
        }
        #endregion

#region Управление слоями
        private void checkBox_TrafficLight_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.ViewPort.IsTrafficLight_Visible = ((CheckBox)sender).Checked;
            Viewer.ViewPort.Invalidate();
        }

        private void checkBox_Police_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.ViewPort.IsPolice_Visible = ((CheckBox)sender).Checked;
            Viewer.ViewPort.Invalidate();
        }

        private void checkBox_Sign_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.ViewPort.IsSign_Visible = ((CheckBox)sender).Checked;
            Viewer.ViewPort.Invalidate();
        }

        private void checkBox_StreetLength_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.ViewPort.IsStreetLength_Visible = ((CheckBox)sender).Checked;
            Viewer.ViewPort.Invalidate();
        }

        private void checkBox_StreetName_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.ViewPort.IsStreetName_Visible = ((CheckBox)sender).Checked;
            Viewer.ViewPort.Invalidate();
        }
        #endregion
        private void удалитьПерегонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.DeleteEdge(lastClickCoordX, lastClickCoordY);
        }

        private void удалитьПерекрестокToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
