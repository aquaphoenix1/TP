using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            Coating.CurrentMaxID = DAO.GetMaxID("Surface");
            Fine.CurrentMaxID = DAO.GetMaxID("Fine");
            Car.CurrentMaxID = DAO.GetMaxID("Auto");
            Fuel.CurrentMaxID = DAO.GetMaxID("Fuel");
            Driver.Driver.CurrentMaxID = DAO.GetMaxID("Driver");
            Sign.CurrentMaxID = DAO.GetMaxID("Sign");
            Edge.CurrentMaxID = DAO.GetMaxID("Street");

            Coating.ListSurface = DAO.GetAll("Surface");
            Fine.ListFine = DAO.GetAll("Fine");
            Car.ListAuto = DAO.GetAll("Auto");
            Fuel.ListFuel = DAO.GetAll("Fuel");
            Police.ListTypePolicemen = DAO.GetAll("Policemen");
            Driver.Driver.ListDriver = DAO.GetAll("Driver");
            Sign.ListSigns = DAO.GetAll("Sign");
            Edge.StreetList = DAO.GetAll("Street");
        }

        private void ClearDataGrid()
        {
            dataGridViewDataBase.Rows.Clear();
            dataGridViewDataBase.Columns.Clear();
        }

        private void FillGrid(List<List<object>> listWithData)
        {
            listWithData.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
        }

        private void ComboBoxSelectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 1)
            {
                ClearDataGrid();
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
                    case "Дорожные покрытия":
                        {
                            dataGridViewDataBase.Columns.Add("id", "ID");
                            dataGridViewDataBase.Columns.Add("name", "Название покрытия");
                            dataGridViewDataBase.Columns.Add("koefficient", "Коэффициент торможения");

                            FillGrid(Coating.ListSurface);

                            break;
                        }
                    case "Типы полицейских":
                        {
                            dataGridViewDataBase.Columns.Add("id", "ID");
                            dataGridViewDataBase.Columns.Add("type", "Тип полицейского");
                            dataGridViewDataBase.Columns.Add("koefficient", "Коэффициент жадности полицейского");

                            FillGrid(Police.ListTypePolicemen);
                            break;
                        }
                    case "Топливо":
                        {
                            dataGridViewDataBase.Columns.Add("id", "ID");
                            dataGridViewDataBase.Columns.Add("nameFuel", "Название топлива");
                            dataGridViewDataBase.Columns.Add("cost", "Цена");

                            FillGrid(Fuel.ListFuel);
                            break;
                        }
                    case "Автомобили":
                        {
                            dataGridViewDataBase.Columns.Add("id", "ID");
                            dataGridViewDataBase.Columns.Add("model", "Модель");
                            dataGridViewDataBase.Columns.Add("fuel", "Топливо");
                            dataGridViewDataBase.Columns.Add("consumption", "Потребление");
                            dataGridViewDataBase.Columns.Add("speed", "Скорость");

                            Car.ListAuto.ForEach(val =>
                            {
                                object[] array = val.ToArray();
                                array[2] = Fuel.ListFuel.First(fuel => fuel[0].ToString().Equals(val[2].ToString())).ToArray()[1];
                                dataGridViewDataBase.Rows.Add(array);
                            });

                            break;
                        }
                    case "Штрафы":
                        {
                            dataGridViewDataBase.Columns.Add("id", "ID");
                            dataGridViewDataBase.Columns.Add("name", "Название штрафа");
                            dataGridViewDataBase.Columns.Add("cost", "Цена");

                            FillGrid(Fine.ListFine);
                            break;
                        }
                    case "Водители":
                        {
                            dataGridViewDataBase.Columns.Add("id", "ID");
                            dataGridViewDataBase.Columns.Add("name", "Нарушитель?");
                            dataGridViewDataBase.Columns.Add("IDauto", "ID автомобиля");
                            dataGridViewDataBase.Columns.Add("model", "Модель автомобиля");

                            Driver.Driver.ListDriver.ForEach(val =>
                            {
                                System.Collections.ArrayList list = new System.Collections.ArrayList(val.ToArray())
                                {
                                    Car.ListAuto.First(car => car[0].ToString().Equals(val[2].ToString())).ToArray()[1]
                                };
                                dataGridViewDataBase.Rows.Add(list.ToArray());
                            });

                            break;
                        }
                    case "Дорожные знаки":
                        {
                            dataGridViewDataBase.Columns.Add("id", "ID");
                            dataGridViewDataBase.Columns.Add("type", "Тип знака");
                            dataGridViewDataBase.Columns.Add("value", "Значение");

                            FillGrid(Sign.ListSigns);
                            break;
                        }
                    case "Улицы":
                        {
                            dataGridViewDataBase.Columns.Add("id", "ID");
                            dataGridViewDataBase.Columns.Add("name", "Название улицы");

                            FillGrid(Edge.StreetList);
                            break;
                        }
                }
            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
            {
                ClearDataGrid();
                comboBoxSelectTable.SelectedItem = null;
            }
        }

        public static bool IsChanged { private get; set; }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTable.SelectedItem != null)
            {
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
                    case "Типы полицейских":
                        {
                            /*IsChanged = false;
                            new PoliceForm(true).ShowDialog();
                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Police.ListTypePolicemen);
                            }*/
                            break;
                        }
                    case "Дорожные покрытия":
                        {
                            if (Coating.ListSurface.Count == 10)
                            {
                                MessageBox.Show(string.Format("Максимальное количество дорожных покрытий - {0}", 10));
                            }
                            else
                            {
                                IsChanged = false;
                                new CoatingForm(true).ShowDialog();
                                if (IsChanged)
                                {
                                    dataGridViewDataBase.Rows.Clear();
                                    FillGrid(Coating.ListSurface);
                                }
                            }
                            break;
                        }
                    case "Штрафы":
                        {
                            IsChanged = false;
                            new FineForm(true).ShowDialog();
                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Fine.ListFine);
                            }
                            break;
                        }
                    case "Топливо":
                        {
                            if (Fuel.ListFuel.Count == 7)
                            {
                                MessageBox.Show(string.Format("Максимальное количество видов топлива - {0}", 7));
                            }
                            else
                            {
                                IsChanged = false;
                                new FuelForm(true).ShowDialog();
                                if (IsChanged)
                                {
                                    dataGridViewDataBase.Rows.Clear();
                                    FillGrid(Fuel.ListFuel);
                                }
                            }
                            break;
                        }
                    case "Дорожные знаки":
                        {
                            IsChanged = false;
                            new SignForm(true).ShowDialog();
                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Sign.ListSigns);
                            }
                            break;
                        }
                    case "Автомобили":
                        {
                            if (Car.ListAuto.Count == 10)
                            {
                                MessageBox.Show(string.Format("Максимальное количество автомобилей - {0}", 10));
                            }
                            else
                            {
                                IsChanged = false;
                                new CarForm(true).ShowDialog();
                                if (IsChanged)
                                {
                                    dataGridViewDataBase.Rows.Clear();

                                    Car.ListAuto.ForEach(val =>
                                    {
                                        object[] array = val.ToArray();
                                        array[2] = Fuel.ListFuel.First(fuel => fuel[0].ToString().Equals(val[2].ToString())).ToArray()[1];
                                        dataGridViewDataBase.Rows.Add(array);
                                    });
                                }
                            }
                            break;
                        }
                    case "Водители":
                        {
                            if (Driver.Driver.ListDriver.Count == 10)
                            {
                                MessageBox.Show(string.Format("Максимальное количество водителей - {0}", 10));
                            }
                            else
                            {
                                IsChanged = false;
                                new DriverForm(true).ShowDialog();
                                if (IsChanged)
                                {
                                    dataGridViewDataBase.Rows.Clear();

                                    Driver.Driver.ListDriver.ForEach(val =>
                                    {
                                        System.Collections.ArrayList list = new System.Collections.ArrayList(val.ToArray())
                                    {
                                    Car.ListAuto.First(car => car[0].ToString().Equals(val[2].ToString())).ToArray()[1]
                                    };
                                        dataGridViewDataBase.Rows.Add(list.ToArray());
                                    });
                                }
                            }
                            break;
                        }
                    case "Улицы":
                        {
                            if (Edge.StreetList.Count == 100)
                            {
                                MessageBox.Show(string.Format("Максимальное количество наименований улиц - {0}", 100));
                            }
                            else
                            {
                                IsChanged = false;
                                new FormStreet(true).ShowDialog();
                                if (IsChanged)
                                {
                                    dataGridViewDataBase.Rows.Clear();

                                    FillGrid(Edge.StreetList);
                                }
                            }
                            break;
                        }
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTable.SelectedItem != null)
            {
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
                    case "Типы полицейских":
                        {
                            /*if (new PoliceDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                            {
                                dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("Невозможно удалить");
                            }*/
                            break;
                        }
                    case "Дорожные покрытия":
                        {
                            if (Coating.ListSurface.Count == 1)
                            {
                                MessageBox.Show(string.Format("Минимальное количество дорожных покрытий - {0}", 1));
                            }
                            else
                            {
                                if (new CoatingDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                                {
                                    dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                                }
                                else
                                {
                                    MessageBox.Show("Невозможно удалить");
                                }
                            }
                            break;
                        }
                    case "Штрафы":
                        {
                            if (new FineDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                            {
                                dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("Невозможно удалить");
                            }
                            break;
                        }
                    case "Топливо":
                        {
                            if (Fuel.ListFuel.Count == 1)
                            {
                                MessageBox.Show(string.Format("Минимальное количество видов топлива - {0}", 1));
                            }
                            else
                            {
                                if (new FuelDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                                {
                                    dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                                }
                                else
                                {
                                    MessageBox.Show("Невозможно удалить");
                                }
                            }
                            break;
                        }
                    case "Дорожные знаки":
                        {
                            if (new SignDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                            {
                                dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("Невозможно удалить");
                            }
                            break;
                        }
                    case "Автомобили":
                        {
                            if (Car.ListAuto.Count == 1)
                            {
                                MessageBox.Show(string.Format("Минимальное количество автомобилей - {0}", 1));
                            }
                            else
                            {
                                if (new CarDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                                {
                                    dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                                }
                                else
                                {
                                    MessageBox.Show("Невозможно удалить");
                                }
                            }
                            break;
                        }
                    case "Водители":
                        {
                            if (Driver.Driver.ListDriver.Count == 1)
                            {
                                MessageBox.Show(string.Format("Минимальное количество водителей - {0}", 1));
                            }
                            else
                            {
                                if (new DriverDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                                {
                                    dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                                }
                                else
                                {
                                    MessageBox.Show("Невозможно удалить");
                                }
                            }
                            break;
                        }
                    case "Улицы":
                        {
                            if (Edge.StreetList.Count == 5)
                            {
                                MessageBox.Show(string.Format("Минимальное количество наименований улиц - {0}", 5));
                            }
                            else
                            {
                                if (new StreetDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                                {
                                    dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                                }
                                else
                                {
                                    MessageBox.Show("Невозможно удалить");
                                }
                            }
                            break;
                        }
                }
            }
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            label_Layers.Location = new Point(-17, panelSlideContainer.Height / 2 - 40);
            if (Viewer.ViewPort == null || Viewer.ViewPort.View == null)
                pictureBoxMap.Size = this.Size;
        }

        private void PictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isVertexMoved && !isMapMoved)
            {
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
                            {
                                Viewer.ViewPort.UnSelectEdge();
                            }
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
                        {
                            isVertexMoved = false;
                        }
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
            {
                Viewer.ViewPort.OpenPicture(openSubMapFileDialog.FileName);

                Viewer.ViewPort.View.MouseDown += PictureBoxMap_MouseDown;
                Viewer.ViewPort.View.MouseMove += PictureBoxMap_MouseMove;
                Viewer.ViewPort.View.MouseUp += PictureBoxMap_MouseUp;

                Viewer.ViewPort.View.ContextMenuStrip = contextMenuVertex;

            }

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
            Viewer.ViewPort.SelectStartVertex(lastClickCoordX, lastClickCoordY);
        }

        private void ToolStripMenu_WayToВ_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.SelectEndVertex(lastClickCoordX, lastClickCoordY);
        }

        private void PanelSlide_Click(object sender, EventArgs e)
        {
            if ((slide = !slide))
            {
                panelSlideContainer.Size = new Size(205, panelSlideContainer.Size.Width);
            }
            else
            {
                panelSlideContainer.Size = new Size(23, panelSlideContainer.Size.Width);
            }

            panelSlide.SendToBack();
        }

        private void Button_Calibration_Click(object sender, EventArgs e)
        {
            button_Ok_Сalibration.Enabled = true;
            button_Calibration.Enabled = false;
            callibrationEdge = new Edge(new Vertex(20.UnScaling(), 50.UnScaling()), new Vertex(60.UnScaling(), 50.UnScaling()));
            Viewer.ViewPort.Invalidate();

            Viewer.ViewPort.View.MouseDown -= PictureBoxMap_MouseDown;
            Viewer.ViewPort.View.MouseMove -= PictureBoxMap_MouseMove;
            Viewer.ViewPort.View.MouseUp -= PictureBoxMap_MouseUp;

            Viewer.ViewPort.View.MouseDown += Сalibration_MouseDown;
            Viewer.ViewPort.View.MouseMove += Сalibration_MouseMove;
            Viewer.ViewPort.View.MouseUp += Сalibration_MouseUp;

            Viewer.ViewPort.View.Paint += View_Paint;
        }

        private void Button_Ok_Сalibration_Click(object sender, EventArgs e)
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
            {
                e.Graphics.FillEllipse(PensCase.SelectedVertex, selectedLabel.X.UnScaling(), selectedLabel.Y.UnScaling(), dX, dX);
            }

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

        }
        private void Сalibration_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void Сalibration_MouseUp(object sender, MouseEventArgs e)
        {
            isVertexMoved = false;
            isCreatedEdge = false;
            selectedLabel = null;
        }
        #endregion

        #region Управление слоями
        private void CheckBox__TrafficLight_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.ViewPort.IsTrafficLight_Visible = ((CheckBox)sender).Checked;
            Viewer.ViewPort.Invalidate();
        }

        private void CheckBox_Police_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.ViewPort.IsPolice_Visible = ((CheckBox)sender).Checked;
            Viewer.ViewPort.Invalidate();
        }

        private void CheckBox_Sign_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.ViewPort.IsSign_Visible = ((CheckBox)sender).Checked;
            Viewer.ViewPort.Invalidate();
        }

        private void CheckBox_StreetLength_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.ViewPort.IsStreetLength_Visible = ((CheckBox)sender).Checked;
            Viewer.ViewPort.Invalidate();
        }

        private void CheckBox_StreetName_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.ViewPort.IsStreetName_Visible = ((CheckBox)sender).Checked;
            Viewer.ViewPort.Invalidate();
        }
        #endregion

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTable.SelectedItem != null && dataGridViewDataBase.SelectedRows.Count > 0)
            {
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
                    case "Типы полицейских":
                        {
                            /*long id = long.Parse(dataGridViewDataBase.SelectedRows[0].Cells["id"].Value.ToString());
                            List<object> police = Police.ListTypePolicemen.First(policeman => policeman[0].ToString().Equals(id.ToString()));

                            string typePolice = dataGridViewDataBase.SelectedRows[0].Cells["type"].Value.ToString();
                            double coef = double.Parse(dataGridViewDataBase.SelectedRows[0].Cells["koefficient"].Value.ToString());
                            new PoliceForm(id, police[1].ToString()).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Police.ListTypePolicemen);
                            }*/

                            break;
                        }
                    case "Дорожные покрытия":
                        {
                            long id = long.Parse(dataGridViewDataBase.SelectedRows[0].Cells["ID"].Value.ToString());
                            List<object> coat = Coating.ListSurface.First(coating => coating[0].ToString().Equals(id.ToString()));
                            new CoatingForm(id, coat[1].ToString(), double.Parse(coat[2].ToString())).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Coating.ListSurface);
                            }

                            break;
                        }
                    case "Штрафы":
                        {
                            long id = long.Parse(dataGridViewDataBase.SelectedRows[0].Cells["ID"].Value.ToString());
                            List<object> fine = Fine.ListFine.First(fin => fin[0].ToString().Equals(id.ToString()));
                            new FineForm(id, fine[1].ToString(), double.Parse(fine[2].ToString())).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Fine.ListFine);
                            }

                            break;
                        }
                    case "Топливо":
                        {
                            long id = long.Parse(dataGridViewDataBase.SelectedRows[0].Cells["id"].Value.ToString());
                            List<object> fuel = Fuel.ListFuel.First(fl => fl[0].ToString().Equals(id.ToString()));
                            new FuelForm(id, fuel[1].ToString(), double.Parse(fuel[2].ToString())).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Fuel.ListFuel);
                            }

                            break;
                        }
                    case "Дорожные знаки":
                        {
                            long id = long.Parse(dataGridViewDataBase.SelectedRows[0].Cells["ID"].Value.ToString());
                            List<object> sign = Sign.ListSigns.First(sg => sg[0].ToString().Equals(id.ToString()));
                            new SignForm(id, sign[1].ToString(), int.Parse(sign[2].ToString())).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Sign.ListSigns);
                            }

                            break;
                        }
                    case "Автомобили":
                        {
                            long id = long.Parse(dataGridViewDataBase.SelectedRows[0].Cells["id"].Value.ToString());
                            List<object> auto = Car.ListAuto.First(car => car[0].ToString().Equals(id.ToString()));
                            List<object> fl = Fuel.ListFuel.First(f => f[0].ToString().Equals(auto[2].ToString()));
                            Fuel currentFuel = Fuel.CreateFuel(long.Parse(fl[0].ToString()), fl[1].ToString(), double.Parse(fl[2].ToString()));

                            new CarForm(id, auto[1].ToString(), currentFuel, double.Parse(auto[3].ToString()), double.Parse(auto[4].ToString())).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();

                                Car.ListAuto.ForEach(val =>
                                {
                                    object[] array = val.ToArray();
                                    array[2] = Fuel.ListFuel.First(fuel => fuel[0].ToString().Equals(val[2].ToString())).ToArray()[1];
                                    dataGridViewDataBase.Rows.Add(array);
                                });
                            }
                            break;
                        }
                    case "Водители":
                        {
                            long id = long.Parse(dataGridViewDataBase.SelectedRows[0].Cells["id"].Value.ToString());
                            List<object> driver = Driver.Driver.ListDriver.First(dv => dv[0].ToString().Equals(id.ToString()));
                            List<object> auto = Car.ListAuto.First(cr => cr[0].ToString().Equals(driver[2].ToString()));
                            List<object> fl = Fuel.ListFuel.First(f => f[0].ToString().Equals(auto[2].ToString()));
                            Fuel currentFuel = Fuel.CreateFuel(long.Parse(fl[0].ToString()), fl[1].ToString(), double.Parse(fl[2].ToString()));
                            Car car = Car.CreateCar(long.Parse(auto[0].ToString()), auto[1].ToString(), currentFuel, double.Parse(auto[3].ToString()), double.Parse(auto[4].ToString()));
                            new DriverForm(id, driver[1].ToString(), car).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();

                                Driver.Driver.ListDriver.ForEach(val =>
                                {
                                    System.Collections.ArrayList list = new System.Collections.ArrayList(val.ToArray())
                                {
                                    Car.ListAuto.First(cr => cr[0].ToString().Equals(val[2].ToString())).ToArray()[1]
                                };
                                    dataGridViewDataBase.Rows.Add(list.ToArray());
                                });
                            }

                            break;
                        }
                }
            }
        }

        private void УдалитьПерегонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.DeleteEdge(lastClickCoordX, lastClickCoordY);
        }

        private void УдалитьПерекрестокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.DelteVertex(lastClickCoordX, lastClickCoordY);
        }

        private void ToolStripMenuItem_MakeStaticRoute_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.MakeStaticRoute();
        }

        public enum Criterial { Time, Length, Price }

        private void ПараметрыМаршрутаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsRouteForm optionsRouteForm = new OptionsRouteForm();

            optionsRouteForm.ShowDialog();

            if (optionsRouteForm.DialogResult == DialogResult.OK)
            {
                Criterial criterial = optionsRouteForm.Criterial;
                Driver.Driver driver = optionsRouteForm.Drive;
                optionsRouteForm.Close();

                new Route().FindMinLengthWay(Map.vertexes, Map.edges, criterial, driver);
            }
        }

        private void ToolStripMenuItem_Route_Click(object sender, EventArgs e)
        {
            if(Route.Start == null || Route.End == null)
            {
                ToolStripMenuItem_StaticView.Enabled = false;
                ToolStripMenuItem_RouteParameters.Enabled = false;
            }
            else
            {
                ToolStripMenuItem_StaticView.Enabled = true;
                ToolStripMenuItem_RouteParameters.Enabled = true;
            }
        }
    }
}
