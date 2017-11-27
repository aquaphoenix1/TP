using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.Driver;
using TProject.Graph;
using TProject.Properties;
using TProject.TypeDAO;
using TProject.Way;

namespace TProject
{
    public partial class MainForm : Form
    {
        //Управление интерфейсом
        private int dX, dY, startWidthPB, startHeightPB;
        private bool isClickedOnVertex = false,
                     isClickedOnEdge = false,
                     isCreatingEdge = false,
                     isMoved = false,
                     tlNotInit = true;

        private double zoomCurValue;
        private MouseEventArgs lastMouseEvent;

        Route way = new Route();
        //Используемые коллекции
        private SortedList<double, Image> cache;
        private VertexCollection vertexes;
        private EdgeCollection edges;
        private Image sourceImage;
        private int lastPBLocationX;
        private int lastPBLocationtY;

        public MainForm()
        {
            InitializeComponent();

            pictureBoxMap.Hide();
            pictureBoxMap.Enabled = false;
            vertexes = new VertexCollection();
            edges = new EdgeCollection();

            //Sign.Init();
            //Coating.Init();
            PensCase.Initialize();

            DoubleBuffered = true;

            zoomCurValue = 1;
            Vertex.Scale = 1;
            startWidthPB = pictureBoxMap.Width;
            startHeightPB = pictureBoxMap.Height;

            TrafficLight.tLightTurn += pictureBoxMap.Invalidate;
            timerTrafficLight.Tick += vertexes.tickTL;
            vertexes.eventUpdateList += pictureBoxMap.Invalidate;
            edges.eventUpdateList += pictureBoxMap.Invalidate;

            pictureBoxMap.Invalidate();

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

            Coating.ListSurface = DAO.GetAll("Surface");
            Fine.ListFine = DAO.GetAll("Fine");
            Car.ListAuto = DAO.GetAll("Auto");
            Fuel.ListFuel = DAO.GetAll("Fuel");
            Police.ListTypePolicemen = DAO.GetAll("Policemen");
            Driver.Driver.ListDriver = DAO.GetAll("Driver");
            Sign.ListSigns = DAO.GetAll("Sign");
        }

        private void DrawFlag(Graphics e, int x, int y, Color color, int width)
        {
            x = x + Vertex.Radius_2 - 2;
            Point[] p = new Point[]
            {
                new Point(x, y),
                new Point(x - 5, y - 7),
                new Point(x - 5, y - 14),
                new Point(x + 5, y - 14),
                new Point(x + 5, y - 7),
            };
            e.DrawPolygon(new Pen(color, width), p);
        }

        public void RePaint()
        {
            pictureBoxMap.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tlNotInit = false;
            timerTrafficLight.Enabled = true;
            pictureBoxMap.Invalidate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int start = vertexes.ElementsList.FindIndex(o => o.ID == way.Start.ID);
            int end = vertexes.ElementsList.FindIndex(o => o.ID == way.End.ID);
            List<long> idS;
            way.FindMinLengthWay(start, end, vertexes, edges, out idS);
        }

        //События pictureBoxMap
        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (lastMouseEvent != null)
            {
                edges.DrawAllOnPicture(g, dX, dY, lastMouseEvent.X, lastMouseEvent.Y, vertexes, isCreatingEdge);
            }

            vertexes.DrawAllOnPicture(g, tlNotInit);

            if (way.Start != null)
            {
                DrawFlag(g, way.Start.X.UnScaling(), way.Start.Y.UnScaling(), Color.Black, 12);
                DrawFlag(g, way.Start.X.UnScaling(), way.Start.Y.UnScaling(), Color.Sienna, 10);
            }
            if (way.End != null)
            {
                DrawFlag(g, way.End.X.UnScaling(), way.End.Y.UnScaling(), Color.Black, 12);
                DrawFlag(g, way.End.X.UnScaling(), way.End.Y.UnScaling(), Color.Red, 10);
            }
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
                pictureBoxMap.Location = new Point(pictureBoxMap.Location.X + e.X - lastPBLocationX, pictureBoxMap.Location.Y + e.Y - lastPBLocationtY);
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
                            {
                                edges.AddElement(new Edge(v1, vertexes.SelVertex));
                            }
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
                    lastPBLocationX = e.X;
                    lastPBLocationtY = e.Y;
                }
            }
            pictureBoxMap.Invalidate();
        }





        private void toList()
        {
            for (double i = 0.6; i < 1.5; i = i + 0.2)
            {
                cache.Add(Math.Round(i, 1), (new Bitmap(sourceImage, new Size((int)(startWidthPB * i), (int)(startHeightPB * i)))));
            }
        }

        private void pictureBoxMap_Zoom(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && zoomCurValue <= 2 || e.Delta < 0 && zoomCurValue >= 0.6)
            {
                panelMapSubstrate.AutoScroll = false;

                zoomCurValue += e.Delta > 0 ? 0.2 : -0.2;
                Vertex.Scale = zoomCurValue = Math.Round(zoomCurValue, 1);

                if (cache.ContainsKey(zoomCurValue))
                {
                    pictureBoxMap.Image = cache[zoomCurValue];
                }
                else
                {
                    Image a = new Bitmap(sourceImage, new Size(startWidthPB.UnScaling(), startHeightPB.UnScaling()));
                    pictureBoxMap.Image = a;
                    cache.Add(zoomCurValue, a);
                }
                pictureBoxMap.Size = pictureBoxMap.Image.Size;

                panelMapSubstrate.AutoScroll = true;
            }

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
                            dataGridViewDataBase.Columns.Add("IDfuel", "ID топлива");
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
        //Нажата кнопка ДОБАВИТЬ в "Работа с БД"
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTable.SelectedItem != null)
            {
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
                    case "Типы полицейских":
                        {
                            PoliceForm f = new PoliceForm(true);
                            f.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Police.ListTypePolicemen.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    case "Дорожные покрытия":
                        {
                            CoatingForm cf = new CoatingForm(true);
                            cf.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Coating.ListSurface.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    case "Топливо":
                        {
                            FuelForm ff = new FuelForm(true);
                            ff.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Fuel.ListFuel.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    case "Автомобили": //отмет
                        {
                            CarForm cf = new CarForm(true);
                            cf.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Car.ListAuto.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    case "Штрафы":
                        {
                            FineForm fform = new FineForm(true);
                            fform.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Fine.ListFine.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    case "Дорожные знаки":
                        {
                            SignForm f = new SignForm(true);
                            f.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Sign.ListSigns.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
                    case "Водители":
                        {
                            DriverForm df = new DriverForm(true);
                            df.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Driver.Driver.ListDriver.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
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

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTable.SelectedItem != null && dataGridViewDataBase.SelectedRows.Count > 0)
            {
                switch (comboBoxSelectTable.SelectedItem.ToString())
                {
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
                            CarForm f = new CarForm(id, model,fuel, consumption);
                            f.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Car.ListAuto.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }
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
                    case "Водители":
                        {
                            bool typedriver;

                            int id = int.Parse(dataGridViewDataBase.SelectedRows[0].Cells["ID"].Value.ToString());
                            string Name = dataGridViewDataBase.SelectedRows[0].Cells["name"].Value.ToString();
                            if (Name == "Нет") { typedriver = false; } else { typedriver = true; }
                            double idauto = double.Parse(dataGridViewDataBase.SelectedRows[0].Cells["IDauto"].Value.ToString());

                            var fcar = Car.ListAuto.FirstOrDefault(l => l.ElementAt(0).ToString() == idauto.ToString());
                            var ffuel = Fuel.ListFuel.FirstOrDefault(l => l.ElementAt(0).ToString() == fcar[2].ToString());

                            Fuel fuel = new Fuel(int.Parse(ffuel[0].ToString()) , ffuel[1].ToString(), double.Parse(ffuel[2].ToString()));

                            Car car = new Car(int.Parse(fcar[0].ToString()), fcar[1].ToString(), fuel, double.Parse(fcar[3].ToString()));

                            if (Name == "Нет") { typedriver = false;  } else { typedriver = true; }


                            DriverForm f = new DriverForm(id, typedriver, car);
                            f.ShowDialog();
                            dataGridViewDataBase.Rows.Clear();
                            Driver.Driver.ListDriver.ForEach(val => dataGridViewDataBase.Rows.Add(val.ToArray()));
                            break;
                        }

                }
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
                System.IO.FileStream fs = new System.IO.FileStream(openSubMapFileDialog.FileName, System.IO.FileMode.Open);
                Image img = Image.FromStream(fs);
                fs.Close();

                sourceImage = img;

                pictureBoxMap.Width = startWidthPB = img.Width;
                pictureBoxMap.Height = startHeightPB = img.Height;

                pictureBoxMap.Image = img;
                Vertex.Scale = 1;

                cache = new SortedList<double, Image>();
                toList();

                panelMapSubstrate.MouseWheel += new MouseEventHandler(pictureBoxMap_Zoom);
                pictureBoxMap.Paint += new PaintEventHandler(pictureBoxMap_Paint);
                pictureBoxMap.MouseDown += new MouseEventHandler(pictureBoxMap_MouseDown);
                pictureBoxMap.MouseMove += new MouseEventHandler(pictureBoxMap_MouseMove);
                pictureBoxMap.MouseUp += new MouseEventHandler(pictureBoxMap_MouseUp);
                pictureBoxMap.Enabled = true;
                pictureBoxMap.Show();
            }
        }






        /// <summary>
        /// Маршрут из
        /// </summary>
        private void wayFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            way.Start = vertexes.SelVertex;
            pictureBoxMap.Invalidate();
        }
        /// <summary>
        /// Маршрут в
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wayToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            way.End = vertexes.SelVertex;
            pictureBoxMap.Invalidate();
        }

        /// <summary>
        /// Редактирование параметров перегона
        /// </summary>
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
        /// <summary>
        /// Редактирование параметров перекрестка
        /// </summary>
        private void editVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditVertex form = new EditVertex(vertexes.SelVertex))
            {
                form.Owner = this;
                form.ShowDialog();
                vertexes.SelVertex = form.Vertex;
                if (vertexes.SelVertex.TrafficLight != null)
                {
                    vertexes.tlList.Add(vertexes.SelVertex.TrafficLight);
                }

                pictureBoxMap.Invalidate();
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
