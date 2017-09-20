using System;

namespace TProject
{
    public class Edge: Entity
    {
        private int Length;

        private static long curMaxId = 0;
        private Vertex HeadVertex { get; set; }
        private Vertex EndVertex { get; set; }
        public bool IsBilateral { get; set; }
        public Sign Signs { get; set; }

        public Police Policemen { get; set; }

        public string NameStreet { get; set; }

        public Coating Coat { get; set; }


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

        public int GetLength()
        {
            return Length;
        }
        public void SetLength(int _len)
        {
            Length = _len;
        }

        public class Sign
        {
            public Sign() { }
        }
        public class Coating : Type, Coefficient
        {
            public string Type { get; set; }
            public double Coeff { get; set; }

            public Coating(string type, double coefficient)
            {
                this.Type = type;
                this.Coeff = coefficient;
            }
            public Coating() { }
        }

        public Edge() { }

        public Edge(Vertex v1, Vertex v2)
        {
            ID = ++curMaxId;
            HeadVertex = v1;
            EndVertex = v2;
        }

        public Edge InitThisEdge(int length, string nameStreet, Coating coat, bool isBiLate)
        {

            Length = length;
            NameStreet = nameStreet;
            Coat = coat;
            IsBilateral = isBiLate; 
            return this;
        }

        public bool isConnected(Vertex vertex)
        {
            return this.EndVertex == vertex;
        }

        public static Edge CreateArc(string Direction, Vertex A, Vertex B, int length, string nameStreet, Coating coat)
        {
            Edge arc = new Edge();
            arc.Length = length;
            arc.HeadVertex = A;
            arc.EndVertex = B;
            arc.NameStreet = nameStreet;
            arc.Coat = coat;
            arc.ID = ++curMaxId;
            return arc;
        }
    }
}
