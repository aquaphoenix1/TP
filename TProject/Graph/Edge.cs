using System;
using System.Collections.Generic;
using TProject.Way;

namespace TProject.Graph
{
    public class Edge : Entity
    {
        public static List<List<object>> StreetList { get; set; }
        public static long CurrentMaxID { get; set; }

        private int Length;

        private Vertex HeadVertex { get; set; }
        private Vertex EndVertex { get; set; }

        public bool IsBilateral { get; set; }

        public Sign Signs { get; set; }
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

        public Edge InitThisEdge(string nameStreet, int length, Coating coat, bool isBiLate)
        {
            Length = length;
            NameStreet = nameStreet;
            Coat = coat;
            IsBilateral = isBiLate;

            return this;
        }

        public bool IsConnected(Vertex vertex)
        {
            return this.EndVertex == vertex;
        }

        public static Edge CreateArc(string Direction, Vertex A, Vertex B, int length, string nameStreet, Coating coat)
        {
            Edge arc = new Edge
            {
                Length = length,
                HeadVertex = A,
                EndVertex = B,
                NameStreet = nameStreet,
                Coat = coat
            };
            return arc;
        }
    }
}
