using System;
using System.Collections.Generic;
using TProject.Way;

namespace TProject.Graph
{
    public class Edge : Entity
    {
        public static List<List<object>> StreetList { get; set; }

        private Vertex HeadVertex { get; set; }
        private Vertex EndVertex { get; set; }

        public bool IsBilateral { get; set; }

        public bool SignTwoWay { get; set; }
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
                        return GetLength(Viewer.ViewPort.ScaleCoefficient);
                    }
                case Main.Criterial.Price:
                    {
                        return GetPrice(GetLength(Viewer.ViewPort.ScaleCoefficient), driver);
                    }
                case Main.Criterial.Time:
                    {
                        return GetLength(Viewer.ViewPort.ScaleCoefficient);
                    }
            }

            return 0;
        }
        
        private double GetPrice(double length, Driver.Driver driver)
        {
            double price = 0.0;

            price += driver.Car.FuelConsumption * length * driver.Car.CarFuel.Price;

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

        public Edge() : base() { }

        public Edge(Vertex v1, Vertex v2) : base()
        {
            HeadVertex = v1;
            EndVertex = v2;
        }

        public bool IsConnected(Vertex vertex)
        {
            return this.EndVertex == vertex;
        }
        
        internal static Edge CreateEdge(long ID, Vertex head, Vertex end, Coating coat, string name, bool isBelaterial, bool signTwoWay, Sign signMaxSpeed, Police polieceman)
        {
            return new Edge
            {
                ID = ID,
                HeadVertex = head,
                EndVertex = end,
                NameStreet = name,
                Coat = coat,
                IsBilateral = isBelaterial,
                SignTwoWay = signTwoWay,
                SignMaxSpeed = signMaxSpeed,
                Policemen = polieceman
            };
        }
    }
}
