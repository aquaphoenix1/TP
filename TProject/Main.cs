using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TProject.Driver;
using TProject.Graph;
using TProject.TypeDAO;
using TProject.Way;

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

            Initialize();
        }

        private void Initialize()
        {
            Police.CurrentMaxID = DAO.GetMaxID("Policemen");
            Coating.curMaxId = DAO.GetMaxID("Surface");
            Fine.curMaxId = DAO.GetMaxID("Fine");
            Car.curMaxId = DAO.GetMaxID("Auto");
            Fuel.curMaxId = DAO.GetMaxID("Fuel");
            Driver.Driver.curMaxId = DAO.GetMaxID("Driver");
            Sign.curMaxId = DAO.GetMaxID("Sign");
            Edge.curMaxIdStreet = DAO.GetMaxID("Street");

            Coating.ListSurface = DAO.GetAll("Surface");
            Fine.ListFine = DAO.GetAll("Fine");
            Car.ListAuto = DAO.GetAll("Auto");
            Fuel.ListFuel = DAO.GetAll("Fuel");
            Police.ListTypePolicemen = DAO.GetAll("Policemen");
            Driver.Driver.ListDriver = DAO.GetAll("Driver");
            Sign.ListSigns = DAO.GetAll("Sign");
            Edge.StreetList = DAO.GetAll("Street");
        }

        private void clearDataGrid()
        {
            dataGridViewDataBase.Rows.Clear();
            dataGridViewDataBase.Columns.Clear();
        }

        private void comboBoxSelectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 1)
            {
                clearDataGrid();
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
                    case "Дорожные покрытия":
                        {
                            dataGridViewDataBase.Columns.Add("ID", "ID покрытия");
                            dataGridViewDataBase.Columns.Add("name", "Название покрытия");
                            dataGridViewDataBase.Columns.Add("koefficient", "Коэффициент торможения");

                            Coating.ListSurface.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));

                            break;
                        }
                    case "Типы полицейских":
                        {
                            dataGridViewDataBase.Columns.Add("id", "ID полицейского");
                            dataGridViewDataBase.Columns.Add("type", "Тип полицейского");
                            dataGridViewDataBase.Columns.Add("koefficient", "Коэффициент жадности полицейского");

                            Police.ListTypePolicemen.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));

                            break;
                        }
                    case "Топливо":
                        {
                            dataGridViewDataBase.Columns.Add("id", "ID топлива");
                            dataGridViewDataBase.Columns.Add("nameFuel", "Название топлива");
                            dataGridViewDataBase.Columns.Add("cost", "Цена");

                            Fuel.ListFuel.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));

                            break;
                        }
                    case "Автомобили":
                        {
                            dataGridViewDataBase.Columns.Add("id", "Номер автомобиля");
                            dataGridViewDataBase.Columns.Add("model", "Модель");
                            dataGridViewDataBase.Columns.Add("id", "ID топлива");
                            dataGridViewDataBase.Columns.Add("consumption", "Потребление");

                            Car.ListAuto.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));

                            break;
                        }
                    case "Штрафы":
                        {
                            dataGridViewDataBase.Columns.Add("ID", "ID штрафа");
                            dataGridViewDataBase.Columns.Add("name", "Название штрафа");
                            dataGridViewDataBase.Columns.Add("cost", "Цена");

                            Fine.ListFine.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));

                            break;
                        }
                    case "Водители":
                        {
                            dataGridViewDataBase.Columns.Add("ID", "ID водителя");
                            dataGridViewDataBase.Columns.Add("name", "Тип водителя");
                            dataGridViewDataBase.Columns.Add("IDauto", "ID автомобиля");

                            Driver.Driver.ListDriver.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));

                            break;
                        }
                    case "Дорожные знаки":
                        {
                            dataGridViewDataBase.Columns.Add("ID", "ID знака");
                            dataGridViewDataBase.Columns.Add("type", "Тип знака");
                            dataGridViewDataBase.Columns.Add("value", "Значение");

                            Sign.ListSigns.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));

                            break;
                        }
                    case "Улицы":
                        {
                            dataGridViewDataBase.Columns.Add("ID", "ID знака");
                            dataGridViewDataBase.Columns.Add("name", "Название улицы");

                            Edge.StreetList.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));

                            break;
                        }
                }
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
            {
                clearDataGrid();
                comboBoxSelectTable.SelectedItem = null;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTable.SelectedItem != null)
            {
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
                    case "Типы полицейских":
                        {

                            Police p = new Police("qwe", 5);
                            if (new PoliceDAO().Insert(p))
                            {
                                List<object> list = new List<object>();
                                list.Add(p.ID);
                                list.Add(p.TypeName);
                                list.Add(p.Coeff);
                                Police.ListTypePolicemen.Add(list);
                                dataGridViewDataBase.Rows.Add(list.ToArray());
                            }
                            else
                            {
                                Police.CurrentMaxID--;
                            }
                            break;
                        }
                    case "Дорожные покрытия":
                        {

                            Coating c = new Coating("Топливо1", 3);
                            if (new CoatingDAO().Insert(c))
                            {
                                List<object> list = new List<object>();
                                list.Add(c.ID);
                                list.Add(c.TypeName);
                                list.Add(c.Coeff);
                                Coating.ListSurface.Add(list);
                                dataGridViewDataBase.Rows.Add(list.ToArray());
                            }
                            else
                            {
                                Coating.curMaxId--;
                            }
                            break;
                        }
                    case "Улицы":
                        {
                            string[] arr = new string[2];
                            arr[0] = (++Edge.curMaxIdStreet).ToString();
                            arr[1] = "Московское шоссе";

                            object x = arr;
                            String s = "Московское шоссе";
                            if (new StreetDAO().Insert(x))
                            {
                                List<object> list = new List<object>();
                                list.Add(++Edge.curMaxIdStreet);
                                list.Add(s);
                                Edge.StreetList.Add(list);
                                dataGridViewDataBase.Rows.Add(list.ToArray());
                            }
                            else
                            {
                                Edge.curMaxIdStreet--;
                            }
                            break;
                        }
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTable.SelectedItem != null)
            {
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
                    case "Типы полицейских":
                        {
                            if (new PoliceDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                            {
                                dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("Невозможно удалить");
                            }
                            break;
                        }
                    case "Дорожные покрытия":
                        {
                            if (new CoatingDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                            {
                                dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("Невозможно удалить");
                            }
                            break;
                        }
                }
            }
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
        private void checkBox__TrafficLight_CheckedChanged(object sender, EventArgs e)
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
    }
}
