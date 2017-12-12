using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TProject.Graph;
using TProject.Properties;
using TProject.Way;

namespace TProject
{
    public class Viewer
    {
        /// <summary>
        /// основной на котором отрисовывается подложка и графPictureBox
        /// </summary>
        private PictureBox view;
        private Font mainFormFont;
        public PictureBox View => view;
        private int globalTime = 0;
        Dynamic dynamic;

        /// <summary>
        /// Расположение pb в контейнере до перемещения
        /// </summary>
        public int MapLocationX { get; set; }
        public int MapLocationY { get; set; }

        Brush blackFontBrush = new SolidBrush(Color.Black);
        Brush redFontBrush = new SolidBrush(Color.Red);

        public int VertexLocationX { get; set; }
        public int VertexLocationY { get; set; }

        public delegate void ReDraw();

        /// <summary>
        /// Задает отношение метры -> условные единицы
        /// </summary>
        public double ScaleCoefficient { get; set; }

        private SortedList<double, Image> cache;
        private Image sourceImage;

        /// <summary>
        /// Контейнер основного PictureBox
        /// </summary>
        private Panel substrate;
        /// <summary>
        /// Смещение курсора от центра точки
        /// </summary>
        private int dX, dY;
        /// <summary>
        /// Исходный размер pictureBox
        /// </summary>
        private int startWidthPB, startHeightPB;
        /// <summary>
        /// Высота точки
        /// </summary>
        public static int Width { get; private set; }
        /// <summary>
        /// Ширина точки
        /// </summary>
        public static int Height { get; private set; }
        /// <summary>
        /// Текущий масштаб
        /// </summary>
        public double ZoomCurValue { private set; get; }
        public bool IsPolice_Visible { get; set; }
        public bool IsTrafficLight_Visible { get; set; }
        public bool IsSign_Visible { get; set; }
        public bool IsStreetName_Visible { get; set; }
        public bool IsStreetLength_Visible { get; set; }

        public static Viewer ViewPort = null;

        private Vertex selectedVertex = null;
        private Edge selectedEdge = null;

        private Viewer(PictureBox pb, Panel panel, Font font)
        {
            // if (ViewPort == null)
            {
                mainFormFont = font;
                MapLocationX = 0;
                MapLocationY = 0;

                Width = 10;
                Height = 10;

                ZoomCurValue = 1;
                view = pb;
                substrate = panel;
                view.Hide();
                view.Enabled = false;

                Resize();




                ViewPort = this;
            }
        }

        /// <summary>
        /// Создает перекресток в указанной позиции
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void CreateVertex(int x, int y)
        {
            Vertex newVertex = new Vertex(x.Scaling() + dX, y.Scaling() + dY);
            EditVertex ev = new EditVertex(newVertex);
            ev.ShowDialog();
            if (ev.DialogResult == DialogResult.OK)
            {
                Map.vertexes.Add(newVertex);
            }
        }

        public void EditVertexOptions()
        {
            if (selectedVertex != null)
            {
                new EditVertex(selectedVertex).ShowDialog();
            }
        }

        public void EditEdgeOptions()
        {
            if (selectedEdge != null)
            {
                new EditEdge(selectedEdge).ShowDialog();
            }
        }

        #region Масштабирование

        /// <summary>
        /// Происходит при прокрутке колесика мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zoom(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && ZoomCurValue <= 2 || e.Delta < 0 && ZoomCurValue >= 0.6)
            {
                substrate.AutoScroll = false;

                ZoomCurValue += e.Delta > 0 ? 0.2 : -0.2;
                Vertex.Scale = ZoomCurValue = Math.Round(ZoomCurValue, 1);

                if (cache.ContainsKey(ZoomCurValue))
                {
                    view.Image = cache[ZoomCurValue];
                }
                else
                {
                    Image a = new Bitmap(sourceImage, new Size(startWidthPB.UnScaling(), startHeightPB.UnScaling()));
                    view.Image = a;
                    cache.Add(ZoomCurValue, a);
                }
                view.Size = view.Image.Size;

                substrate.AutoScroll = true;
            }
        }

        /// <summary>
        /// Создание кэша отмасштабированных карт
        /// (для повышения быстродействия масштабирования)
        /// </summary>
        private void ToList()
        {
            for (double i = 0.6; i < 1.5; i = i + 0.2)
            {
                Size size = new Size((int)(startWidthPB * i), (int)(startHeightPB * i));
                cache.Add(Math.Round(i, 1), (new Bitmap(sourceImage, size)));
            }
        }

        /// <summary>
        /// Пересчитывает величину смещения реальных координат точки, 
        /// относительно положения курсора
        /// </summary>
        public void Resize()
        {
            dX = Width / 2;
            dY = Height / 2;
        }
        #endregion

        #region Методы работы с контроллером (инициализация pictureBox для карты и тд.)

        /// <summary>
        /// Создает объект контроллера отображения
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="panel"></param>
        public static void CreateViewer(PictureBox pb, Panel panel, Font font)
        {
            ViewPort = new Viewer(pb, panel, font);
        }

        /// <summary>
        /// Вызывает перерисовку pictureBox, содержащего карту
        /// </summary>
        public void Invalidate()
        {
            view.Invalidate();
        }

        /// <summary>
        /// Сдвигает pictureBox с картой при перетаскивании
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveViewPort(int x, int y)
        {
            view.Location = new Point(view.Location.X + x - MapLocationX, view.Location.Y + y - MapLocationY);
        }

        public void OpenPicture(int h, int w, Image img)
        {
            view.Image = img;
            sourceImage = img;

            if (h != 0 && w != 0)
            {
                view.Paint -= Paint;
                view.MouseWheel -= Zoom;

                this.View.Height = startHeightPB = h;
                this.View.Width = startWidthPB = w;
                this.View.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            else
            {


                view.Width = startWidthPB = img.Width;
                view.Height = startHeightPB = img.Height;
            }


            cache = new SortedList<double, Image>();
            ToList();

            view.Enabled = true;
            view.Visible = true;
            view.Paint += Paint;
            view.MouseWheel += Zoom;
        }

        /// <summary>
        /// Открывает Указанный в fname графический файл
        /// </summary>
        /// <param name="fname"></param>
        public void OpenPicture(int h, int w, string fname)
        {
            using (FileStream fs = new FileStream(fname, FileMode.Open))
            {
                Image img = Image.FromStream(fs);
                OpenPicture(h, w, img);
            }

        }

        #endregion

        #region Создание ребра

        ///
        /// <summary>
        /// Создает новое ребро (стрелку с началом в указанной 
        /// точке и концом в позиции указателя мыши)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void CreateEdge(int x, int y)
        {
            selectedEdge = new Edge(selectedVertex, new Vertex(x.Scaling() + dX, y.Scaling() + dY));
        }

        public void DeleteEdge(int x, int y)
        {
            if (Map.edges.GetSelected(x, y))
            {
                Map.edges.Delete(selectedEdge);
                selectedEdge = null;
            }
        }

        public void DelteVertex(int x, int y)
        {
            if (Map.vertexes.GetSelected(x, y))
            {
                Map.edges.DeleteAllConnection(selectedVertex);
                Map.vertexes.Delete(selectedVertex);
                selectedVertex = null;
            }
        }

        /// <summary>
        /// Выполняется при визуальном отображении создания нового ребра
        /// Пересоздает стрелку с концом в точке, в которой находится курсор
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ModifyCreatedEdge(int x, int y)
        {
            selectedEdge.SetEnd(new Vertex(x.Scaling(), y.Scaling()));
        }

        /// <summary>
        /// Сохраняет редактируемое ребро 
        /// и сбрасывает все выделения
        /// </summary>
        public void SaveCreatedEdge()
        {
            if (selectedVertex.ID != selectedEdge.GetHead().ID
                && Map.edges.TryCopy(selectedVertex.ID, selectedEdge.GetHead().ID))
            {
                selectedEdge.SetEnd(selectedVertex);
                EditEdge fe = new EditEdge(selectedEdge);
                fe.ShowDialog();

                if (fe.DialogResult == DialogResult.OK)
                {
                    Map.edges.Add(selectedEdge);
                }
            }
            selectedVertex = null;
            selectedEdge = null;
        }

        #endregion

        #region Отрисовка элементов, содержащихся на карте
        /// <summary>
        /// Происходит при перерисовке pictureBox, содержащего карту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            DrawEdges(graph);
            DrawVertexes(graph);
            if (Route.Start != null)
            {
                DrawStartPoint(graph);
            }
            if (Route.End != null)
            {
                DrawEndPoint(graph);
            }
        }


        private void DrawStartPoint(Graphics graph)
        {
            Pen pen = new Pen(Color.Red);
            DrawPointFlag(graph, pen, Route.Start.X - Width / 2, Route.Start.Y - Width / 2);
        }

        private void DrawPointFlag(Graphics graph, Pen pen, int x, int y)
        {
            pen.Width = 8;
            graph.DrawPolygon(pen, new Point[]{
                new Point((x  + Width  / 2).UnScaling(), (y).UnScaling()),
                new Point((x - Width).UnScaling(), (y - (Width)).UnScaling()),
                new Point((x - Width).UnScaling(), (y - (Width * 2)).UnScaling()),
                new Point((x  + Width  / 2).UnScaling(), (y - (Width * 2)).UnScaling())
            });
        }
        private void DrawEndPoint(Graphics graph)
        {
            Pen pen = new Pen(Color.Blue);
            DrawPointFlag(graph, pen, Route.End.X - Width / 2, Route.End.Y - Width / 2);
        }

        /// <summary>
        /// отрисовывает все перегоны, содержащиеся на карте
        /// </summary>
        /// <param name="graph"></param>
        /// 
        private void DrawEdges(Graphics graph)
        {
            Pen pen = new Pen(Color.Green, Width.UnScaling() - 2)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.ArrowAnchor
            };

            foreach (var item in Map.edges.List)
            {
                if (!item.Equals(selectedEdge))
                {
                    graph.DrawLine(PensCase.GetCustomPen(false, Width.UnScaling() + 3), item.GetHead().X.UnScaling() + dX, item.GetHead().Y.UnScaling() + dY,
                        item.GetEnd().X.UnScaling() + dX, item.GetEnd().Y.UnScaling() + dY);
                    graph.DrawLine(PensCase.GetPenForEdge(false, false, Width.UnScaling()), item.GetHead().X.UnScaling() + dX, item.GetHead().Y.UnScaling() + dY,
                        item.GetEnd().X.UnScaling() + dX, item.GetEnd().Y.UnScaling() + dY);
                    if (item.IsInWay)
                    {
                        graph.DrawLine(pen,
                          (item.GetHead().X).UnScaling() + Width / 2, (item.GetHead().Y).UnScaling() + Width / 2,
                          (item.GetEnd().X).UnScaling() + Width / 2, (item.GetEnd().Y).UnScaling() + Width / 2);
                    }
                    if (IsStreetLength_Visible)
                    {
                        graph.DrawString(Math.Round(item.GetLength(ScaleCoefficient), 2).ToString(), new Font(mainFormFont.FontFamily, 10f, FontStyle.Italic | FontStyle.Bold,
                            GraphicsUnit.Point, mainFormFont.GdiCharSet), blackFontBrush,
                            (item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 - 25),
                            (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2 - 10));
                    }
                }
                if (item.Policemen != null && IsPolice_Visible)
                {
                    graph.DrawImage(Resources.star, new Rectangle(item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 + 25,
                            (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2 + 10), Width * 2, Height * 2));
                }
            }
            if (IsSign_Visible)
            {
                foreach (var item in Map.edges.List.Where(o => o.SignMaxSpeed != null))
                {
                    graph.FillEllipse(new SolidBrush(Color.White),
                        (item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 + 24)
                        , (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2 - 11), Width * 2 + 3, Width * 2 + 3);
                    graph.DrawEllipse(new Pen(Color.Red, (float)(Width / 2 - 2)),
                        (item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 + 24)
                        , (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2 - 11), Width * 2 + 3, Width * 2 + 3);


                    graph.DrawString(item.SignMaxSpeed.Count.ToString(), new Font(mainFormFont.FontFamily, 10f, FontStyle.Bold,
                       GraphicsUnit.Point, mainFormFont.GdiCharSet), blackFontBrush,
                       (item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 + 26),
                       (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2 - 7));
                }
            }

            if (selectedEdge != null)
            {
                graph.DrawLine(PensCase.GetPenForEdge(true, false, Width.UnScaling()), selectedEdge.GetHead().X.UnScaling() + dX, selectedEdge.GetHead().Y.UnScaling() + dY,
                    selectedEdge.GetEnd().X.UnScaling() + dX, selectedEdge.GetEnd().Y.UnScaling() + dY);
                if (IsStreetLength_Visible)
                {
                    graph.DrawString(Math.Round(selectedEdge.GetLength(ScaleCoefficient), 2).ToString(), new Font(mainFormFont.FontFamily, 10f, FontStyle.Italic | FontStyle.Bold,
                        GraphicsUnit.Point, mainFormFont.GdiCharSet), blackFontBrush,
                        (selectedEdge.GetHead().X.UnScaling() + (selectedEdge.GetEnd().X.UnScaling() - selectedEdge.GetHead().X.UnScaling()) / 2 - 25),
                        (selectedEdge.GetHead().Y.UnScaling() + (selectedEdge.GetEnd().Y.UnScaling() - selectedEdge.GetHead().Y.UnScaling()) / 2 - 10));
                }
            }
        }


        /// <summary>
        /// Отрисовывает все перекрестки, содержащиеся на карте
        /// </summary>
        /// <param name="graph"></param>
        private void DrawVertexes(Graphics graph)
        {
            foreach (var item in Map.vertexes.List)
            {
                //    if (selectedVertex != item)
                graph.FillEllipse(PensCase.Point, item.X.UnScaling(), item.Y.UnScaling(), Width, Height);
                if (item.TrafficLight != null && IsTrafficLight_Visible)
                {
                    graph.DrawImage(item.TrafficLight.IsRun ?
                        item.TrafficLight.IsGreen ? Resources.greenLight3 : Resources.redLight3
                        : Resources.nonLight3,
                        new Rectangle((item.X + Width).UnScaling(), (item.Y + Height).UnScaling(), (int)Math.Round(Width * 1.2), Height * 2));
                }
            }
            if (dynamic != null)
            {
                graph.FillEllipse(PensCase.SelectedVertex, dynamic.Drive.X.UnScaling() - Width, dynamic.Drive.Y.UnScaling() - Width, Width * 2, Height * 2);
            }
            if (selectedVertex != null)
            {
                graph.FillEllipse(PensCase.SelectedVertex, selectedVertex.X.UnScaling(), selectedVertex.Y.UnScaling(), Width, Height);
            }
        }
        public void ViewInDynamic()
        {
            dynamic = new Dynamic(Route.CurrentDriver);

                foreach (var item in Map.vertexes.List)
                {
                    if (item.TrafficLight != null)
                    {
                        item.TrafficLight.IsRun = true;
                        dynamic.timerTL.Tick += (o, e) => item.TrafficLight.Inc();
                    }
                }
                dynamic.Start();
        }

        public void MakeStaticRoute()
        {
            Map.Way = new List<Vertex>();
            if (Route.Way != null)
            {
                foreach (var item in Map.edges.List)
                {
                    bool fl = false;
                    int k = 0;
                    while (!fl && k < Route.Way.Count - 1)
                    {
                        if (fl = item.GetHead().ID == Route.Way.ElementAt(k) &&
                            item.GetEnd().ID == Route.Way.ElementAt(k + 1) ||
                             item.GetHead().ID == Route.Way.ElementAt(k + 1) &&
                            item.GetEnd().ID == Route.Way.ElementAt(k))
                        {
                            if (item.GetHead().ID == Route.Way.ElementAt(k))
                            {
                                Map.Way.Add(item.GetHead());
                                Map.Way.Add(item.GetEnd());
                            }
                            else
                            {
                                Map.Way.Add(item.GetEnd());
                                Map.Way.Add(item.GetHead());
                            }
                        }
                        k++;
                    }
                    item.IsInWay = fl;
                }

                MessageBox.Show(Math.Round(Route.Value, 2).ToString());
            }
            else
            {
                MessageBox.Show("Невозможно построить маршрут");
            }

            ViewPort.Invalidate();
        }

        #endregion

        #region Работа с выделением объектов

        /// <summary>
        /// Помечает указанную вершину как выбранную
        /// </summary>
        /// <param name="vertex"></param>
        public void SelectVertex(Vertex vertex)
        {
            selectedVertex = vertex;
        }
        public void SelectEdge(Edge edge)
        {
            selectedEdge = edge;
        }

        /// <summary>
        /// Сбрасывает выделенные ребра и вершины
        /// </summary>
        public void UnSelectAll()
        {
            selectedVertex = null;
            selectedEdge = null;
        }
        public void UnSelectVertex()
        {
            selectedVertex = null;
        }
        public void UnSelectEdge()
        {
            selectedEdge = null;
        }

        /// <summary>
        /// Вызывается при перетаскивании перекрестков на карте
        /// с помощью указателя мыши
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveVertex(int x, int y)
        {
            selectedVertex.X = (x - dX).Scaling();
            selectedVertex.Y = (y - dY).Scaling();
        }
        /// <summary>
        /// Определяет, есть ли вершина в заданной точке
        /// </summary>
        /// <param name="x1">Координата точки на карте</param>
        /// <param name="y1">Координата точки на карте</param>
        /// <param name="x2">Координата вершины</param>
        /// <param name="y2">Координата вершины</param>
        /// <returns></returns>
        public static bool IsPointInRectangle(int x1, int y1, int x2, int y2)
        {
            return x1.UnScaling() + Width >= x2 && y1.UnScaling() + Height >= y2 && x2 >= x1.UnScaling() && y2 >= y1.UnScaling();
        }
        public static bool IsPointOnEdge(int x, int y, int x1, int y1, int x2, int y2)
        {
            if (x.Scaling() - Width <= Math.Max(x1, x2) && x.Scaling() + Width >= Math.Min(x1, x2) && y.Scaling() - Height <= Math.Max(y1, y2) && y.Scaling() + Height >= Math.Min(y1, y2))
            {
                if (x2 == x1)
                {
                    return x.Scaling() >= x1 - Width && x.Scaling() <= x1 + Width;
                }
                else if (y2 == y1)
                {
                    return y.Scaling() >= y1 - Width && y.Scaling() <= y1 + Width;
                }
                else
                {
                    double k = (double)(y2 - y1) / (double)(x2 - x1);
                    double pointY = k * x.Scaling() + y1 - k * x1;
                    return pointY - Width <= y.Scaling() && pointY + Width >= y.Scaling();
                }
            }
            return false;
        }

        #endregion
        public void SelectStartVertex(int x, int y)
        {
            Map.vertexes.GetSelected(x, y, out Route.Start);
        }
        public void SelectEndVertex(int x, int y)
        {
            Map.vertexes.GetSelected(x, y, out Route.End);
        }
    }

    public static class ReScaling
    {
        public static int Scaling(this int value)
        {
            return (int)(value / Viewer.ViewPort.ZoomCurValue);
        }
        public static int UnScaling(this int value)
        {
            return (int)(value * Viewer.ViewPort.ZoomCurValue);
        }
    }
}
