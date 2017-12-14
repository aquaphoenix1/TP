﻿using System;
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
    public class MakeMap
    {
        /// <summary>
        /// основной на котором отрисовывается подложка и графPictureBox
        /// </summary>
        private PictureBox view;

        public PictureBox View => view;

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

        /// <summary>
        /// Исходный размер pictureBox
        /// </summary>
        private int startWidthPB, startHeightPB;
        /// <summary>
        /// Текущий масштаб
        /// </summary>
        public double ZoomCurValue { private set; get; }
        public bool IsPolice_Visible { get; set; }
        public bool IsTrafficLight_Visible { get; set; }
        public bool IsSign_Visible { get; set; }
        public bool IsStreetName_Visible { get; set; }
        public bool IsStreetLength_Visible { get; set; }

        public static MakeMap ViewPort = null;

        private Vertex selectedVertex = null;
        public Vertex SelectedVertex => selectedVertex;
        private Edge selectedEdge = null;
        public Edge SelectedEdge => selectedEdge;

        private MakeMap(PictureBox pb, Panel panel, Font font)
        {
            {
                StaticViewer.CreateViewer(font);

                MapLocationX = 0;
                MapLocationY = 0;

                StaticViewer.Width = 10;

                ZoomCurValue = 1;
                view = pb;
                substrate = panel;
                view.Hide();
                view.Enabled = false;

                StaticViewer.Viewer.Resize();
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
            Vertex newVertex = new Vertex(x.Scaling() + StaticViewer.Viewer.dX, y.Scaling() + StaticViewer.Viewer.dY);
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


        #endregion

        #region Методы работы с контроллером (инициализация pictureBox для карты и тд.)

        /// <summary>
        /// Создает объект контроллера отображения
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="panel"></param>
        public static void CreateViewer(PictureBox pb, Panel panel, Font font)
        {
            ViewPort = new MakeMap(pb, panel, font);
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
                view.Paint -= StaticViewer.Viewer.Paint;
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
            view.Paint += StaticViewer.Viewer.Paint;
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
            selectedEdge = new Edge(selectedVertex, new Vertex(x.Scaling() + StaticViewer.Viewer.dX, y.Scaling() + StaticViewer.Viewer.dY));
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


        public void MakeStaticRoute()
        {
          

            if (Route.Way != null)
            {
                Map.Way = new List<Vertex>();

                int k = 0;

                while (k != Route.Way.Count - 1)
                {
                    Vertex first = null,
                        second = null;

                    for (int i = 0; i < Map.vertexes.GetCountElements(); i++)
                    {
                        if (Map.vertexes.GetElement(i).ID == Route.Way[k])
                        {
                            first = Map.vertexes.GetElement(i);
                            break;
                        }
                    }

                    k++;

                    for (int i = 0; i < Map.vertexes.GetCountElements(); i++)
                    {
                        if (Map.vertexes.GetElement(i).ID == Route.Way[k])
                        {
                            second = Map.vertexes.GetElement(i);
                            break;
                        }
                    }

                    Edge edge = Route.GetEdge(first, second, Map.edges);

                    if (edge.GetHead().ID == Route.Way.ElementAt(k - 1))
                    {
                        Map.Way.Add(edge.GetHead());
                        Map.Way.Add(edge.GetEnd());

                        edge.IsInWay = true;
                    }
                    else
                    {
                        Map.Way.Add(edge.GetEnd());
                        Map.Way.Add(edge.GetHead());

                        edge.IsInWay = true;
                    }
                }

                string criterial = (Route.Criterial == Main.Criterial.Length) ? "Длина" : (Route.Criterial == Main.Criterial.Price) ? "Цена" : "Время";

                MessageBox.Show(string.Format("{0} пути {1}", criterial, Math.Round(Route.Value, 2).ToString()), "Цена маршрута");
            }

            /*if (Route.Way != null)
            {
                for (var  i = 0; i < Map.edges.GetCountElements(); i++)
                {
                    bool fl = false;
                    int k = 0;
                    while (!fl && k < Route.Way.Count - 1)
                    {
                        if (fl = Map.edges.GetElement(i).GetHead().ID == Route.Way.ElementAt(k) &&
                              Map.edges.GetElement(i).GetEnd().ID == Route.Way.ElementAt(k + 1) ||
                              Map.edges.GetElement(i).GetHead().ID == Route.Way.ElementAt(k + 1) &&
                              Map.edges.GetElement(i).GetEnd().ID == Route.Way.ElementAt(k))
                        {
                            if (Map.edges.GetElement(i).GetHead().ID == Route.Way.ElementAt(k))
                            {
                                Map.Way.Add(Map.edges.GetElement(i).GetHead());
                                Map.Way.Add(Map.edges.GetElement(i).GetEnd());
                            }
                            else
                            {
                                Map.Way.Add(Map.edges.GetElement(i).GetEnd());
                                Map.Way.Add(Map.edges.GetElement(i).GetHead());
                            }
                        }
                        k++;
                    }
                    Map.edges.GetElement(i).IsInWay = fl;
                }
                string criterial = (Route.Criterial == Main.Criterial.Length) ? "Длина" : (Route.Criterial == Main.Criterial.Price) ? "Цена" : "Время";

                MessageBox.Show(string.Format("{0} пути {1}", criterial, Math.Round(Route.Value, 2).ToString()), "Цена маршрута");
            }*/


            else
            {
                MessageBox.Show("Невозможно построить маршрут");
            }

            ViewPort.Invalidate();
        }


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
            selectedVertex.X = (x - StaticViewer.Viewer.dX).Scaling();
            selectedVertex.Y = (y - StaticViewer.Viewer.dY).Scaling();
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
            return x1.UnScaling() + StaticViewer.Width >= x2 && y1.UnScaling() + StaticViewer.Width >= y2 && x2 >= x1.UnScaling() && y2 >= y1.UnScaling();
        }
        public static bool IsPointOnEdge(int x, int y, int x1, int y1, int x2, int y2)
        {
            if (x.Scaling() - StaticViewer.Width <= Math.Max(x1, x2) && x.Scaling() + StaticViewer.Width >= Math.Min(x1, x2) && y.Scaling() - StaticViewer.Width <= Math.Max(y1, y2) && y.Scaling() + StaticViewer.Width >= Math.Min(y1, y2))
            {
                if (x2 == x1)
                {
                    return x.Scaling() >= x1 - StaticViewer.Width && x.Scaling() <= x1 + StaticViewer.Width;
                }
                else if (y2 == y1)
                {
                    return y.Scaling() >= y1 - StaticViewer.Width && y.Scaling() <= y1 + StaticViewer.Width;
                }
                else
                {
                    double k = (double)(y2 - y1) / (double)(x2 - x1);
                    double pointY = k * x.Scaling() + y1 - k * x1;
                    return pointY - StaticViewer.Width <= y.Scaling() && pointY + StaticViewer.Width >= y.Scaling();
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
            return (int)(value / MakeMap.ViewPort.ZoomCurValue);
        }
        public static int UnScaling(this int value)
        {
            return (int)(value * MakeMap.ViewPort.ZoomCurValue);
        }
    }
}
