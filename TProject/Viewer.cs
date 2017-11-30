using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TProject.Graph;
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
        /// <summary>
        /// Расположение pb в контейнере до перемещения
        /// </summary>
        public int MapLocationX { get; set; }
        public int MapLocationY { get; set; }

        Brush blackFontBrush = new SolidBrush(Color.Black);

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
        public bool IsPolice_Visible { get; set; } = true;
        public bool IsTrafficLight_Visible { get; set; } = true;
        public bool IsSign_Visible { get; set; } = true;
        public bool IsStreetName_Visible { get; set; } = true;
        public bool IsStreetLength_Visible { get; set; } = true;

        public static Viewer ViewPort = null;

        private Vertex selectedVertex = null;
        private Edge selectedEdge = null;

        private Viewer(PictureBox pb, Panel panel, Font font)
        {
            if (ViewPort == null)
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

                view.Paint += Paint;
                view.MouseWheel += Zoom;

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
            Map.vertexes.Add(new Vertex(x.Scaling() + dX, y.Scaling() + dY));
        }

        public void EditVertexOptions()
        {
            if (selectedVertex != null)
            {
                new EditVertex(selectedVertex).Show();
            }
        }

        public void EditEdgeOptions()
        {
            if (selectedEdge != null)
            {
                new EditEdge(selectedEdge).Show();
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

        /// <summary>
        /// Открывает Указанный в fname графический файл
        /// </summary>
        /// <param name="fname"></param>
        public void OpenPicture(string fname)
        {
            using (FileStream fs = new FileStream(fname, FileMode.Open))
            {
                Image img = Image.FromStream(fs);
                view.Image = img;
                sourceImage = img;

                view.Width = startWidthPB = img.Width;
                view.Height = startHeightPB = img.Height;


                cache = new SortedList<double, Image>();
                ToList();

                view.Enabled = true;
                view.Visible = true;
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
            if (selectedVertex.ID != selectedEdge.GetHead().ID)
            {
                selectedEdge.SetEnd(selectedVertex);
                Map.edges.Add(selectedEdge);
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
            if (Map.Way != null)
            {
                DrawRoute(graph);
            }
        }

        /// <summary>
        /// отрисовывает все перегоны, содержащиеся на карте
        /// </summary>
        /// <param name="graph"></param>
        private void DrawEdges(Graphics graph)
        {
            foreach (var item in Map.edges.List)
            {
                if (!item.Equals(selectedEdge))
                {
                    graph.DrawLine(PensCase.GetCustomPen(false, Width.UnScaling() + 3), item.GetHead().X.UnScaling() + dX, item.GetHead().Y.UnScaling() + dY,
                        item.GetEnd().X.UnScaling() + dX, item.GetEnd().Y.UnScaling() + dY);
                    graph.DrawLine(PensCase.GetPenForEdge(false, false, Width.UnScaling()), item.GetHead().X.UnScaling() + dX, item.GetHead().Y.UnScaling() + dY,
                        item.GetEnd().X.UnScaling() + dX, item.GetEnd().Y.UnScaling() + dY);
                    if (IsStreetLength_Visible)
                    {
                        graph.DrawString(Math.Round(item.GetLength(ScaleCoefficient), 2).ToString(), new Font(mainFormFont.FontFamily, 10f, FontStyle.Italic | FontStyle.Bold,
                            GraphicsUnit.Point, mainFormFont.GdiCharSet), blackFontBrush,
                            (item.GetHead().X.UnScaling() + (item.GetEnd().X.UnScaling() - item.GetHead().X.UnScaling()) / 2 - 25),
                            (item.GetHead().Y.UnScaling() + (item.GetEnd().Y.UnScaling() - item.GetHead().Y.UnScaling()) / 2 - 10));
                    }
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
            }

            if (selectedVertex != null)
            {
                graph.FillEllipse(PensCase.SelectedVertex, selectedVertex.X.UnScaling(), selectedVertex.Y.UnScaling(), Width, Height);
            }
        }

        private void DrawRoute(Graphics graph)
        {
            Pen pen = new Pen(Color.Green, Width.UnScaling() + 4)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.ArrowAnchor
            };

            for (int i = 0; i < Map.Way.Count - 1; i++)
            {
                graph.DrawLine(pen,
                  Map.Way.ElementAt(i).X, Map.Way.ElementAt(i).Y,
                  Map.Way.ElementAt(i + 1).X, Map.Way.ElementAt(i + 1).Y);
            }
        }

        public void MakeStaticRoute()
        {
            /*List<long> way = new List<long>();
            Route route = new Route();
            route.FindMinLengthWay(Map.vertexes, Map.edges, out way);*/
            if (Route.Way != null)
            {
                Map.SetWay(Route.Way);
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
