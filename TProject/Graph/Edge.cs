﻿using System;
using System.Collections.Generic;
using TProject.Way;

namespace TProject.Graph
{
    public class Edge : Entity
    {
        public static List<List<object>> StreetList { get; set; }

        public bool IsInWay = false;

        private Vertex HeadVertex { get; set; }
        private Vertex EndVertex { get; set; }

        public bool IsBilateral { get; set; }

        //public bool SignOneWay { get; set; }
        public Sign SignMaxSpeed { get; set; }

        public Police Policemen { get; set; }
        public string NameStreet { get; set; }

        public Coating Coat { get; set; }

        public double GetLength(double coefficient)
        {
            return coefficient * Math.Sqrt(Math.Pow(HeadVertex.X - EndVertex.X, 2) + Math.Pow(HeadVertex.Y - EndVertex.Y, 2));
        }

        public void Revers()
        {
            var c = HeadVertex;
            HeadVertex = EndVertex;
            EndVertex = c;
        }

        public void SetHead(Vertex A)
        {
            HeadVertex = A;
        }

        public void SetEnd(Vertex B)
        {
            EndVertex = B;
        }

        internal double GetCriterialValue(Main.Criterial criterial, Driver.Driver driver)
        {
            switch (criterial)
            {
                case Main.Criterial.Length:
                    {
                        return GetLength(MakeMap.ViewPort.ScaleCoefficient);
                    }
                case Main.Criterial.Price:
                    {
                        return GetPrice(GetLength(MakeMap.ViewPort.ScaleCoefficient), driver);
                    }
                case Main.Criterial.Time:
                    {
                        return GetTime(driver);
                    }
            }

            return 0;
        }
        
        private double GetPrice(double length, Driver.Driver driver)
        {
            double price = 0.0;

            price += (driver.Car.FuelConsumption / 100) * (length / 1000) * driver.Car.CarFuel.Price;

            if(driver.IsViolateTL && this.Policemen != null && SignMaxSpeed != null)
            {
                double different = driver.Car.Speed - SignMaxSpeed.Count;

                if (different > 19)
                {
                    if(different < 40)
                    {
                        price += this.Policemen.Coeff * 500;
                    }
                    else if (different < 60)
                    {
                        price += this.Policemen.Coeff * 1000;
                    }
                    else if (different < 80)
                    {
                        price += this.Policemen.Coeff * 2000;
                    }
                    else
                    {
                        price += this.Policemen.Coeff * 5000;
                    }
                }
            }

            return price;
        }

        public double GetTime(Driver.Driver driver)
        {
            Vertex end = this.EndVertex;
            int currentTime;
            bool isGreen;

            double price = 0;
            double speed = SignMaxSpeed != null ? SignMaxSpeed.Count : 60;
            speed = driver.IsViolateTL ? driver.Car.Speed : speed;

            speed = speed * 1000 / 3600;

            double time = GetLength(MakeMap.ViewPort.ScaleCoefficient) / speed * Coat.Coeff;

            if (end.TrafficLight != null)
            {
                end.TrafficLight.CurrentTime = new Random().Next(0, end.TrafficLight.GreenSeconds + 1);
                end.TrafficLight.IsGreen = true;
                
                currentTime = end.TrafficLight.CurrentTime;
                isGreen = end.TrafficLight.IsGreen;

                end.TrafficLight.Inc((int)(time * 60 * 60));

                if (!end.TrafficLight.IsGreen)
                {
                    price += end.TrafficLight.RedSeconds - end.TrafficLight.CurrentTime;
                }
                end.TrafficLight.CurrentTime = currentTime;
                end.TrafficLight.IsGreen = isGreen;
            }
            price += time;

            return price;
        }

        private void SetVertex(Vertex A, Vertex B)
        {
            HeadVertex = A;
            EndVertex = B;
        }

        public Vertex GetHead()
        {
            return HeadVertex;
        }
        public Vertex GetEnd()
        {
            return EndVertex;
        }

        public Edge() : base() {
            IsBilateral = true;
        }

        public Edge(Vertex v1, Vertex v2) : base()
        {
            IsBilateral = true;
            HeadVertex = v1;
            EndVertex = v2;
        }

        public bool IsConnected(Vertex vertex)
        {
            return this.EndVertex == vertex;
        }
        
        internal static Edge CreateEdge(long ID, Vertex head, Vertex end, Coating coat, string name, bool isBelaterial, bool signOneWay, Sign signMaxSpeed, Police polieceman)
        {
            return new Edge
            {
                ID = ID,
                HeadVertex = head,
                EndVertex = end,
                NameStreet = name,
                Coat = coat,
                IsBilateral = isBelaterial,
                //SignOneWay = signOneWay,
                SignMaxSpeed = signMaxSpeed,
                Policemen = polieceman
            };
        }
    }
}
