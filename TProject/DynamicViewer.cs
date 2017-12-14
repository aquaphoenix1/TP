using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TProject.Graph;

namespace TProject.Way
{
    class Dynamic
    {
        /// <summary>
        /// Таймер, считающий модельное время
        /// Каждое его переполнение выполняет изменение положения иконки автомобиля,
        /// фаз светофоров (по необходимости) и выполняется перерисовка
        /// </summary>
        public Timer timerTL;

        /// <summary>
        /// Находится ли водитель в ожидании переключения светофора
        /// </summary>
        public bool isWait = false;

        /// <summary>
        /// Глобальное время
        /// </summary>
        public int GlobalTime;
        /// <summary>
        /// Текущий шаг прохождения маршрута (индекс дуги в пути)
        /// </summary>
        public int step;
        /// <summary>
        /// Длина пути
        /// </summary>
        private double path;

        /// <summary>
        /// Водитель, двигающийся по маршруту
        /// </summary>
        public Driver.Driver driver;
        /// <summary>
        /// точка расположения иконки водителя на карте
        /// </summary>
        public Point Drive;
        /// <summary>
        /// Вершина, являющаяся началом текущего шага
        /// </summary>
        private Edge currEdge;
        /// <summary>
        /// скорость перемещения иконки по карте на текущем шаге
        /// </summary>
        private double currSpeed;

        /// <summary>
        /// Длина пути на текущем шаге
        /// </summary>
        double wayLengh = 0;
        /// <summary>
        /// Вершина начала текущего шага
        /// </summary>
        Vertex start;
        /// <summary>
        /// Вершина конца текущего шага
        /// </summary>
        Vertex end;

        /// <summary>
        /// Контроллер динамического отображения движения водителя и переключения фаз светофоров
        /// </summary>
        public static Dynamic Dynamics { get; set; }

        /// <summary>
        /// создает контроллер динамического отображения движения водителя и переключения фаз светофоров
        /// </summary>
        /// <param name="dr"></param>
        public Dynamic(Driver.Driver dr)
        {
            timerTL = new Timer();
            Drive = new Point(Map.Way.First().X, Map.Way.First().Y);
            isWait = false;
            driver = dr;
            GlobalTime = 0;
            step = 0;
            timerTL.Interval = 30;
            timerTL.Tick += (o, e) => IncGlobalTime(o);
        }
        /// <summary>
        /// Запускает таймер модельного времени
        /// </summary>
        public void Start()
        {
            timerTL.Start();
        }
        /// <summary>
        /// Запустить динамическое отображение прохождения маршрута
        /// </summary>
        public static void ViewInDynamic()
        {
            Dynamics = new Dynamic(Route.CurrentDriver);

            foreach (var item in Map.vertexes.List)
            {
                if (item.TrafficLight != null)
                {
                    item.TrafficLight.IsRun = true;
                    Dynamics.timerTL.Tick += (o, e) => item.TrafficLight.Inc();
                }
            }
            Dynamics.Start();
        }

        /// <summary>
        /// Пересчет глобального времени, переключение фаз светофоров, определение положения водителя и
        /// определение его скорости на данном этапе
        /// </summary>
        /// <param name="sender"></param>
        private void IncGlobalTime(object sender)
        {
            if (!isWait)
            {
                if (GlobalTime == 0)
                {
                    start = Map.Way.ElementAt(step);
                    end = Map.Way.ElementAt(step + 1);

                    currEdge = Route.GetEdge(start, end, Map.edges);

                    wayLengh = currEdge.GetLength(MakeMap.ViewPort.ScaleCoefficient);

                    currSpeed = 60;
                    if (driver.IsViolateTL)
                    {
                        currSpeed = driver.Car.Speed;
                    }
                    else if (currEdge.SignMaxSpeed != null)
                    {
                        currSpeed = Math.Min(currEdge.SignMaxSpeed.Count, driver.Car.Speed);
                    }

                    currSpeed *= currEdge.Coat.Coeff;
                    currSpeed = (currSpeed/*Скорость*/ * 1000 / MakeMap.ViewPort.ScaleCoefficient) / 60 / 60 / 10 /*Interval 100ms*/;
                }

                double cos = (start.X - end.X) / wayLengh;
                double sin = (start.Y - end.Y) / wayLengh;

                path = GlobalTime * currSpeed;

                Drive.X = start.X - (int)(cos * path);
                Drive.Y = start.Y - (int)(sin * path);

                GlobalTime++;
            }
            if (path >= wayLengh)
            {
                if (end.TrafficLight != null && !end.TrafficLight.IsGreen)
                {
                    isWait = true;
                }
                else
                {
                    isWait = false;
                    step += 2;
                    GlobalTime = 0;
                }
            }

            if (step >= Map.Way.Count - 1)
            {
                ((Timer)(sender)).Stop();
            }

            MakeMap.ViewPort.Invalidate();
        }
    }
}
