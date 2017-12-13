using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TProject.Coll;
using TProject.Driver;
using TProject.Forms;
using TProject.Graph;
using TProject.Properties;
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
            Coating.ListSurface = DAO.GetAll("Surface");
         //   Fine.ListFine = DAO.GetAll("Fine");
            Car.ListAuto = DAO.GetAll("Auto");
            Fuel.ListFuel = DAO.GetAll("Fuel");
            Police.ListTypePolicemen = DAO.GetAll("Policeman");
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
                buttonAdd.Enabled = true;
                buttonEdit.Enabled = true;
                buttonRemove.Enabled = true;

                ClearDataGrid();
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
                    case "Дорожные покрытия":
                        {
                            dataGridViewDataBase.Columns.Add("name", "Название покрытия");
                            dataGridViewDataBase.Columns.Add("koefficient", "Коэффициент торможения");

                            FillGrid(Coating.ListSurface);

                            break;
                        }
                    case "Типы полицейских":
                        {
                            dataGridViewDataBase.Columns.Add("type", "Тип полицейского");
                            dataGridViewDataBase.Columns.Add("koefficient", "Коэффициент жадности полицейского");

                            FillGrid(Police.ListTypePolicemen);

                            buttonAdd.Enabled = false;
                            buttonEdit.Enabled = false;
                            buttonRemove.Enabled = false;

                            break;
                        }
                    case "Топливо":
                        {
                            dataGridViewDataBase.Columns.Add("name", "Название топлива");
                            dataGridViewDataBase.Columns.Add("cost", "Цена");

                            FillGrid(Fuel.ListFuel);
                            break;
                        }
                    case "Автомобили":
                        {
                            dataGridViewDataBase.Columns.Add("model", "Модель");
                            dataGridViewDataBase.Columns.Add("fuel", "Топливо");
                            dataGridViewDataBase.Columns.Add("consumption", "Потребление");
                            dataGridViewDataBase.Columns.Add("speed", "Скорость");

                            FillGrid(Car.ListAuto);

                            break;
                        }
                    case "Штрафы":
                        {
                            dataGridViewDataBase.Columns.Add("name", "Название штрафа");
                            dataGridViewDataBase.Columns.Add("cost", "Цена");

                            FillGrid(Fine.ListFine);
                            break;
                        }
                    case "Водители":
                        {
                            dataGridViewDataBase.Columns.Add("name", "ФИО");
                            dataGridViewDataBase.Columns.Add("type", "Нарушитель?");
                            dataGridViewDataBase.Columns.Add("model", "Автомобиль");

                            FillGrid(Driver.Driver.ListDriver);

                            break;
                        }
                    case "Улицы":
                        {
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

                toolStripMenuItem_Main.Enabled = true;
                ToolStripMenuItem_Route.Enabled = true;
                
                comboBoxSelectTable.SelectedItem = null;
            }
            else
            {
                toolStripMenuItem_Main.Enabled = false;
                ToolStripMenuItem_Route.Enabled = false;
            }
        }

        public static bool IsChanged { private get; set; }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTable.SelectedItem != null)
            {
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
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

                                    FillGrid(Car.ListAuto);
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

                                    FillGrid(Driver.Driver.ListDriver);
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
                    case "Дорожные покрытия":
                        {
                            if (Coating.ListSurface.Count == 1)
                            {
                                MessageBox.Show(string.Format("Минимальное количество дорожных покрытий - {0}", 1));
                            }
                            else
                            {
                                if (new CoatingDAO().Delete(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString()))
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
                            //if (new FineDAO().Delete(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString()))
                            //{
                            //    dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Невозможно удалить");
                            //}
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
                                if (new FuelDAO().Delete(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString()))
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
                    case "Автомобили":
                        {
                            if (Car.ListAuto.Count == 1)
                            {
                                MessageBox.Show(string.Format("Минимальное количество автомобилей - {0}", 1));
                            }
                            else
                            {
                                if (new CarDAO().Delete(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString()))
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
                                if (new DriverDAO().Delete(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString()))
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
                                if (new StreetDAO().Delete(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString()))
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
            {
                pictureBoxMap.Size = this.Size;
            }
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
                                if (Viewer.ViewPort.SelectedVertex == Route.Start)
                                {
                                    wayFromToolStripMenuItem.Text = "Удалить флаг начала маршрута.";
                                } else if (Viewer.ViewPort.SelectedVertex == Route.End)
                                {
                                    wayToВToolStripMenuItem.Text = "Удалить флаг конца маршрута.";
                                }
                                else
                                {
                                    wayFromToolStripMenuItem.Text = "Маршрут из...";
                                    wayToВToolStripMenuItem.Text = "Маршрут в...";
                                }
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
            try
            {
                if (openSubMapFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Init(path: openSubMapFileDialog.FileName);
                }

                Viewer.ViewPort.Invalidate();
            }
            catch (Exception) { }
        }

        public void OpenPicture()
        {
            if (openSubMapFileDialog.ShowDialog() == DialogResult.OK)
            {
                Init(path: openSubMapFileDialog.FileName);
            }
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
            if (Route.Start == null)
            {
                Viewer.ViewPort.SelectStartVertex(lastClickCoordX, lastClickCoordY);
            }
            else
            {
                if (Viewer.ViewPort.SelectedVertex == Route.Start)
                    Route.Start = null;
                else if (Viewer.ViewPort.SelectedVertex == Route.End)
                {
                    Route.End = null;
                    Viewer.ViewPort.SelectStartVertex(lastClickCoordX, lastClickCoordY);
                }
                else
                {
                    Viewer.ViewPort.SelectStartVertex(lastClickCoordX, lastClickCoordY);
                }
            }


            //{
            //    if (Route.Start != null)
            //    {
            //        if (Route.Start == Viewer.ViewPort.SelectedVertex)
            //            Route.Start = null;
            //        else if (Route.End == Viewer.ViewPort.SelectedVertex)
            //        {
            //            Route.End = null;
            //            Viewer.ViewPort.SelectStartVertex(lastClickCoordX, lastClickCoordY);
            //        }
            //    }
            //    else
            //        Viewer.ViewPort.SelectStartVertex(lastClickCoordX, lastClickCoordY);
                Viewer.ViewPort.Invalidate();
        }

        private void ToolStripMenu_WayToВ_Click(object sender, EventArgs e)
        {
            if (Route.End == null)
            {
                Viewer.ViewPort.SelectEndVertex(lastClickCoordX, lastClickCoordY);
            }
            else
            {
                if (Viewer.ViewPort.SelectedVertex == Route.End)
                    Route.End = null;
                else if (Viewer.ViewPort.SelectedVertex == Route.Start)
                {
                    Route.Start = null;
                    Viewer.ViewPort.SelectEndVertex(lastClickCoordX, lastClickCoordY);
                }
                else { 
                    Viewer.ViewPort.SelectEndVertex(lastClickCoordX, lastClickCoordY);
                }
            }




            //if (Route.End != null) {
            //    if(Route.End == Viewer.ViewPort.SelectedVertex)
            //        Route.End = null;
            //    else if (Route.Start == Viewer.ViewPort.SelectedVertex)
            //    {
            //        Route.Start = null;
            //        Viewer.ViewPort.SelectEndVertex(lastClickCoordX, lastClickCoordY);
            //    }
            //}
            //else
            //    Viewer.ViewPort.SelectEndVertex(lastClickCoordX, lastClickCoordY);
            Viewer.ViewPort.Invalidate();
        }

        private void PanelSlide_Click(object sender, EventArgs e)
        {
            panelSlideContainer.Size = (slide = !slide) ? new Size(205, panelSlideContainer.Size.Width) :
                new Size(23, panelSlideContainer.Size.Width);
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
            Calibration(callibrationEdge.GetLength(1));

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
        private void Calibration(double value)
        {
            Viewer.ViewPort.ScaleCoefficient = 100 / (value);

            textBox_CurrentCoefficient.Text = Viewer.ViewPort.ScaleCoefficient.ToString();
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
                            break;
                        }
                    case "Дорожные покрытия":
                        {
                            string name = dataGridViewDataBase.SelectedRows[0].Cells["name"].Value.ToString();
                            List<object> coat = Coating.ListSurface.First(coating => coating[0].ToString().Equals(name));
                            new CoatingForm(coat[0].ToString(), double.Parse(coat[1].ToString())).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Coating.ListSurface);
                            }

                            break;
                        }
                    case "Штрафы":
                        {
                            string name = dataGridViewDataBase.SelectedRows[0].Cells["name"].Value.ToString();
                            List<object> fine = Fine.ListFine.First(fin => fin[0].ToString().Equals(name));
                            new FineForm(fine[0].ToString(), double.Parse(fine[1].ToString())).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Fine.ListFine);
                            }

                            break;
                        }
                    case "Топливо":
                        {
                            string name = dataGridViewDataBase.SelectedRows[0].Cells["name"].Value.ToString();
                            List<object> fuel = Fuel.ListFuel.First(fl => fl[0].ToString().Equals(name));
                            new FuelForm(fuel[0].ToString(), double.Parse(fuel[1].ToString())).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Fuel.ListFuel);
                            }

                            break;
                        }
                    case "Автомобили":
                        {
                            string name = dataGridViewDataBase.SelectedRows[0].Cells["model"].Value.ToString();
                            List<object> auto = Car.ListAuto.First(car => car[0].ToString().Equals(name));
                            List<object> fl = Fuel.ListFuel.First(f => f[0].ToString().Equals(auto[1].ToString()));
                            Fuel currentFuel = Fuel.CreateFuel(fl[0].ToString(), double.Parse(fl[1].ToString()));

                            new CarForm(auto[0].ToString(), currentFuel, double.Parse(auto[2].ToString()), double.Parse(auto[3].ToString())).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();

                                FillGrid(Car.ListAuto);
                            }
                            break;
                        }
                    case "Водители":
                        {
                            string name = dataGridViewDataBase.SelectedRows[0].Cells["name"].Value.ToString();
                            List<object> driver = Driver.Driver.ListDriver.First(dv => dv[0].ToString().Equals(name));
                            List<object> auto = Car.ListAuto.First(cr => cr[0].ToString().Equals(driver[2].ToString()));
                            List<object> fl = Fuel.ListFuel.First(f => f[0].ToString().Equals(auto[1].ToString()));
                            Fuel currentFuel = Fuel.CreateFuel(fl[0].ToString(), double.Parse(fl[1].ToString()));
                            Car car = Car.CreateCar(auto[0].ToString(), currentFuel, double.Parse(auto[2].ToString()), double.Parse(auto[3].ToString()));
                            new DriverForm(driver[0].ToString(), driver[1].ToString(), car).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();

                                FillGrid(Driver.Driver.ListDriver);
                            }

                            break;
                        }

                    case "Улицы":
                        {
                            IsChanged = false;
                            new FormStreet(dataGridViewDataBase.SelectedRows[0].Cells["name"].Value.ToString()).ShowDialog();

                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();

                                FillGrid(Edge.StreetList);
                            }
                            break;
                        }
                }
            }
        }

        private void ToolStripMenuItem_DeleteEdge_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.DeleteEdge(lastClickCoordX, lastClickCoordY);
        }

        private void ToolStripMenuItem_DeleteVertex_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.DelteVertex(lastClickCoordX, lastClickCoordY);
        }

        private void ToolStripMenuItem_MakeStaticRoute_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.MakeStaticRoute();
        }

        public enum Criterial { Time, Length, Price }
        Driver.Driver driver;
        private void ПараметрыМаршрутаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsRouteForm optionsRouteForm = new OptionsRouteForm();

            optionsRouteForm.ShowDialog();

            if (optionsRouteForm.DialogResult == DialogResult.OK)
            {
                Criterial criterial = optionsRouteForm.Criterial;
                driver = optionsRouteForm.Drive;
                optionsRouteForm.Close();

                new Route().FindMinLengthWay(Map.vertexes, Map.edges, criterial, driver);
            }
        }

        private void ToolStripMenuItem_Route_Click(object sender, EventArgs e)
        {
            if (Route.Start == null || Route.End == null)
            {
                ToolStripMenuItem_DynamicView.Enabled = false;
                ToolStripMenuItem_StaticView.Enabled = false;
                ToolStripMenuItem_RouteParameters.Enabled = false;
            }
            else
            {
                ToolStripMenuItem_DynamicView.Enabled = true;
                ToolStripMenuItem_StaticView.Enabled = true;
                ToolStripMenuItem_RouteParameters.Enabled = true;
            }
        }

        public void Init(Image img = null, string path = null)
        {
            int w = 0;
            int h = 0;

            if (Viewer.ViewPort != null)
            {
                w = Viewer.ViewPort.View.Width;
                h = Viewer.ViewPort.View.Height;
                Map.vertexes.RePaint -= Viewer.ViewPort.Invalidate;
                Map.edges.RePaint -= Viewer.ViewPort.Invalidate;
                Viewer.ViewPort.View.MouseDown -= PictureBoxMap_MouseDown;
                Viewer.ViewPort.View.MouseMove -= PictureBoxMap_MouseMove;
                Viewer.ViewPort.View.MouseUp -= PictureBoxMap_MouseUp;
            }
            else
            {
                Map.InitMap();
            }
            Viewer.CreateViewer(pictureBoxMap, panelMapSubstrate, Font);

            Map.vertexes.RePaint += Viewer.ViewPort.Invalidate;
            Map.edges.RePaint += Viewer.ViewPort.Invalidate;

            if (path == null)
            {
                Viewer.ViewPort.OpenPicture(h, w, img);
            }
            else
            {
                Viewer.ViewPort.OpenPicture(h, w, path);
            }

            Viewer.ViewPort.IsStreetLength_Visible = checkBox_StreetLength.Checked;
            Viewer.ViewPort.IsPolice_Visible = checkBox_Police.Checked;
            Viewer.ViewPort.IsSign_Visible = checkBox_Sign.Checked;
            Viewer.ViewPort.IsStreetName_Visible = checkBox_StreetName.Checked;
            Viewer.ViewPort.IsTrafficLight_Visible = checkBox__TrafficLight.Checked;

            Viewer.ViewPort.View.MouseDown += PictureBoxMap_MouseDown;
            Viewer.ViewPort.View.MouseMove += PictureBoxMap_MouseMove;
            Viewer.ViewPort.View.MouseUp += PictureBoxMap_MouseUp;

            Viewer.ViewPort.View.ContextMenuStrip = contextMenuVertex;
            Calibration(100);

            ToolStripMenuItem_Save.Enabled = true;
            ToolStripMenuItem_SaveAs.Enabled = true;
            ToolStripMenuItem_ChooseSubstrate.Enabled = true;
        }
        private void ToolStripMenuItem_Save_Click(object sender, EventArgs e)
        {
            DAO.InsertMap(Map.vertexes, Map.edges, Viewer.ViewPort.View.Image, Map.Name);
        }

        private void ToolStripMenuItem_SaveAS_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        public string SaveAs()
        {
            new ConductingForm(Act.Add).ShowDialog();
            return Map.Name;
        }

        public DialogResult Open(Act act)
        {
            ConductingForm sa = new ConductingForm(act);
            sa.ShowDialog();

            if (sa.DialogResult == DialogResult.OK)
            {
                Vertexes vert = new Vertexes();
                Edges edg = new Edges();
                Image image = DAO.LoadMap(sa.nameMap, out vert, out edg) as Image;

                Init(img: image);
                Map.vertexes = vert;
                Map.edges = edg;

                Map.vertexes.RePaint += Viewer.ViewPort.Invalidate;
                Map.edges.RePaint += Viewer.ViewPort.Invalidate;

                ToolStripMenuItem_Save.Enabled = true;
                ToolStripMenuItem_SaveAs.Enabled = true;
                ToolStripMenuItem_ChooseSubstrate.Enabled = true;
            }
            return sa.DialogResult;
        }
        public void Open(string name)
        {
            Vertexes vert = new Vertexes();
            Edges edg = new Edges();

            Image image = DAO.LoadMap(name, out vert, out edg) as Image;
            if (image == null)
            {
                return;
            }

            Init(img: image);
            Map.vertexes = vert;
            Map.edges = edg;

            Map.vertexes.RePaint += Viewer.ViewPort.Invalidate;
            Map.edges.RePaint += Viewer.ViewPort.Invalidate;

            ToolStripMenuItem_Save.Enabled = true;
            ToolStripMenuItem_SaveAs.Enabled = true;
            ToolStripMenuItem_ChooseSubstrate.Enabled = true;
        }
        private void ToolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            Open(Act.Load);
        }

        private void ToolStripMenuItem_AboutSystem_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path.Replace(@"bin\Debug", "");
            Process.Start("chrome.exe", path + "Resources\\index.html");
        }

        private void ToolStripMenuItem_AboutDeveloper_Click(object sender, EventArgs e)
        {
            AboutDeveloperForm aboutDeveloperForm = new AboutDeveloperForm();
            aboutDeveloperForm.ShowDialog();
        }

        private void ToolStripMenuItem_DynamicView_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.MakeStaticRoute();
            Viewer.ViewPort.ViewInDynamic();
        }
    }
}
