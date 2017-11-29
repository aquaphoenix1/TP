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

        private void clearDataGrid()
        {
            dataGridViewDataBase.Rows.Clear();
            dataGridViewDataBase.Columns.Clear();
        }

        private void FillGrid(List<List<object>> listWithData)
        {
            /*ToArr del = listToArray => {
                object[] arr = listToArray.ToArray(), result = new object[arr.Length - 1];
                for (int i = 1; i < arr.Length; i++)
                {
                    result[i - 1] = arr[i];
                }

                return result;
            };*/

            listWithData.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
        }

        //delegate object[] ToArr(List<object> list);

        private void comboBoxSelectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 1)
            {
                clearDataGrid();
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

                            Car.ListAuto.ForEach(val => {
                                object[] array = val.ToArray();
                                array[2] = Fuel.ListFuel.Select(fuel => fuel).Where(fuel => long.Parse(fuel[0].ToString()) == long.Parse(val[2].ToString())).ToArray()[0][1];
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
                            dataGridViewDataBase.Columns.Add("name", "Тип водителя");
                            dataGridViewDataBase.Columns.Add("IDauto", "ID автомобиля");
                            dataGridViewDataBase.Columns.Add("model", "Модель автомобиля");

                            Driver.Driver.ListDriver.ForEach(val => {
                                System.Collections.ArrayList list = new System.Collections.ArrayList(val.ToArray());
                                list.Add(Car.ListAuto.Select(car => car).Where(car => long.Parse(car[0].ToString()) == long.Parse(val[2].ToString())).ToArray()[0][1]);
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

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
            {
                clearDataGrid();
                comboBoxSelectTable.SelectedItem = null;
            }
        }

        public static bool IsChanged { private get; set; }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTable.SelectedItem != null)
            {
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
                    case "Типы полицейских":
                        {
                            IsChanged = false;
                            new PoliceForm(true).ShowDialog();
                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Police.ListTypePolicemen);
                            }
                            break;
                        }
                    case "Дорожные покрытия":
                        {
                            IsChanged = false;
                            new CoatingForm(true).ShowDialog();
                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Coating.ListSurface);
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
                            IsChanged = false;
                            new FuelForm(true).ShowDialog();
                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                FillGrid(Fuel.ListFuel);
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
                    case "Автомобили":///////////
                        {
                            IsChanged = false;
                            new CarForm(true).ShowDialog();
                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                Car.ListAuto.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            }
                            break;
                        }
                    case "Водители"://///////////
                        {
                            IsChanged = false;
                            new DriverForm(true).ShowDialog();
                            if (IsChanged)
                            {
                                dataGridViewDataBase.Rows.Clear();
                                Driver.Driver.ListDriver.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            }
                            break;
                        }
                    case "Улицы"://///
                        {
                            IsChanged = false;
                            string[] arr = new string[2];
                            //arr[0] = (++Edge.curMaxIdStreet).ToString();
                            arr[1] = "Московское шоссе";

                            object x = arr;
                            String s = "Московское шоссе";
                            if (new StreetDAO().Insert(x))
                            {
                                List<object> list = new List<object>();
                                //list.Add(++Edge.curMaxIdStreet);
                                list.Add(s);
                                Edge.StreetList.Add(list);
                                dataGridViewDataBase.Rows.Add(list.ToArray());
                            }
                            else
                            {
                                //Edge.curMaxIdStreet--;
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
                            if (new FuelDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                            {
                                dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("Невозможно удалить");
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
                            if (new CarDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
                            {
                                dataGridViewDataBase.Rows.RemoveAt(dataGridViewDataBase.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("Невозможно удалить");
                            }
                            break;
                        }
                    case "Водители":
                        {
                            if (new DriverDAO().Delete(long.Parse(dataGridViewDataBase.CurrentRow.Cells[0].Value.ToString())))
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
            Viewer.ViewPort.SelectStartVertex(lastClickCoordX, lastClickCoordY);
        }

        private void ToolStripMenu_WayToВ_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.SelectEndVertex(lastClickCoordX, lastClickCoordX);
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


        //Работа с бд.Нажата кнопка изменить.Даниил
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTable.SelectedItem != null && dataGridViewDataBase.SelectedRows.Count > 0)
            {
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
                    //Работает правильно.Даниил
                    case "Типы полицейских":
                        {
                            int id = int.Parse(dataGridViewDataBase.SelectedRows[0].Cells["id"].Value.ToString());
                            string typePolice = dataGridViewDataBase.SelectedRows[0].Cells["type"].Value.ToString();
                            double coef = double.Parse(dataGridViewDataBase.SelectedRows[0].Cells["koefficient"].Value.ToString());
                            PoliceForm f = new PoliceForm(id, typePolice, coef);
                            f.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Police.ListTypePolicemen.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    //Работает правильно.Даниил
                    case "Дорожные покрытия":
                        {
                            int id = int.Parse(dataGridViewDataBase.SelectedRows[0].Cells["ID"].Value.ToString());
                            string typeCoating = dataGridViewDataBase.SelectedRows[0].Cells["name"].Value.ToString();
                            double coef = double.Parse(dataGridViewDataBase.SelectedRows[0].Cells["koefficient"].Value.ToString());
                            CoatingForm f = new CoatingForm(id, typeCoating, coef);
                            f.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Coating.ListSurface.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    //Работает правально.Даниил
                    case "Штрафы":
                        {
                            int id = int.Parse(dataGridViewDataBase.SelectedRows[0].Cells["ID"].Value.ToString());
                            string NameFine = dataGridViewDataBase.SelectedRows[0].Cells["name"].Value.ToString();
                            double cost = double.Parse(dataGridViewDataBase.SelectedRows[0].Cells["cost"].Value.ToString());
                            FineForm f = new FineForm(id, NameFine, cost);
                            f.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Fine.ListFine.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    //Работает правально.Даниил
                    case "Топливо":
                        {
                            int id = int.Parse(dataGridViewDataBase.SelectedRows[0].Cells["id"].Value.ToString());
                            string NameFuel = dataGridViewDataBase.SelectedRows[0].Cells["nameFuel"].Value.ToString();
                            double price = double.Parse(dataGridViewDataBase.SelectedRows[0].Cells["cost"].Value.ToString());
                            FuelForm f = new FuelForm(id, NameFuel, price);
                            f.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Fuel.ListFuel.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    //Работает правально.Даниил
                    case "Дорожные знаки":
                        {
                            int id = int.Parse(dataGridViewDataBase.SelectedRows[0].Cells["ID"].Value.ToString());
                            string TypeSign = dataGridViewDataBase.SelectedRows[0].Cells["type"].Value.ToString();
                            double value = double.Parse(dataGridViewDataBase.SelectedRows[0].Cells["value"].Value.ToString());
                            SignForm f = new SignForm(id, TypeSign, value);
                            f.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Sign.ListSigns.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    //Работает правально.Даниил
                    case "Автомобили":
                        {
                            int id = int.Parse(dataGridViewDataBase.SelectedRows[0].Cells["id"].Value.ToString());
                            string model = dataGridViewDataBase.SelectedRows[0].Cells["model"].Value.ToString();
                            //Здесь почему то записывает такое же значение как и в id
                            int idCarFuel = int.Parse(dataGridViewDataBase.SelectedRows[0].Cells["IDfuel"].Value.ToString());
                            double consumption = double.Parse(dataGridViewDataBase.SelectedRows[0].Cells["consumption"].Value.ToString());
                            //Поиск топлива
                            var findfuel = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).ToString() == idCarFuel.ToString());



                            Fuel fuel = new Fuel(int.Parse(findfuel[0].ToString()), findfuel[1].ToString(), double.Parse(findfuel[2].ToString()));
                            CarForm f = new CarForm(id, model, fuel, consumption);
                            f.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Car.ListAuto.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    //Работает правильно.Даниил
                    case "Водители":
                        {
                            bool typedriver;

                            int id = int.Parse(dataGridViewDataBase.SelectedRows[0].Cells["ID"].Value.ToString());
                            string Name = dataGridViewDataBase.SelectedRows[0].Cells["name"].Value.ToString();
                            if (Name == "Нет") { typedriver = false; } else { typedriver = true; }
                            double idauto = double.Parse(dataGridViewDataBase.SelectedRows[0].Cells["IDauto"].Value.ToString());

                            var fcar = Car.ListAuto.FirstOrDefault(l => l.ElementAt(0).ToString() == idauto.ToString());
                            var ffuel = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).ToString() == fcar[2].ToString());

                            Fuel fuel = new Fuel(int.Parse(ffuel[0].ToString()), ffuel[1].ToString(), double.Parse(ffuel[2].ToString()));

                            Car car = new Car(int.Parse(fcar[0].ToString()), fcar[1].ToString(), fuel, double.Parse(fcar[3].ToString()));

                            if (Name == "Нет") { typedriver = false; } else { typedriver = true; }


                            DriverForm f = new DriverForm(id, typedriver, car);
                            f.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Driver.Driver.ListDriver.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                }
            }

        }

        private void удалитьПерегонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.DeleteEdge(lastClickCoordX, lastClickCoordY);
        }

        private void удалитьПерекрестокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.DelteVertex(lastClickCoordX, lastClickCoordY);
        }

        private void отобразитьСтатическиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewer.ViewPort.DrawRoute();
        }
    }
}
