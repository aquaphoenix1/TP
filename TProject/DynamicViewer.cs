using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.Graph;

namespace TProject.Way
{
    class Dynamic
    {
        public Timer timerTL;

        public bool isWait = false;

        public int GlobalTime;
        public int step;
        private double path;


        public Driver.Driver driver;
        public Point Drive;
        private Edge currEdge;
        private double currSpeed;

        double wayLengh = 0;
        Vertex start;
        Vertex end;

        public static Dynamic Dynamics { get; set; }

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
        public void Start()
        {
            timerTL.Start();
        }

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
                        currSpeed = driver.Car.Speed;
                    else if (currEdge.SignMaxSpeed != null)
                        currSpeed = Math.Min(currEdge.SignMaxSpeed.Count, driver.Car.Speed);
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
                    isWait = true;
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
