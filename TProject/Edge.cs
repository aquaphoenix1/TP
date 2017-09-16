namespace TProject
{
    class Edge
    {
        public string Direction { get; set; }

        public Vertex VertexOne { get; set; }
        public Vertex VertexTwo { get; set; } 

        public Police Policemen { get; set; }

        public string NameStreet { get; set; }

        private int Length;



        public Coating Coat { get; set; }

        public void SetVertexA(Vertex A)
        {
            VertexOne = A;
        }
        public void SetVertexB(Vertex B)
        {
             VertexTwo = B;
        }

        public Vertex GetVertexA()
        {
            return this.VertexOne;
        }

        public Vertex GetVertexB()
        {
            return this.VertexTwo;
        }

        public int GetLength()
        {
            return this.Length;
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
        }

        private void SetVertex(Vertex A, Vertex B)
        {
            this.VertexOne = A;
            this.VertexTwo = B;
        }

        public Edge() { }

        public Edge(Vertex v1, Vertex v2)
        {
            VertexOne = v1;
            VertexTwo = v2;
        }

        public static Edge CreateArc(string Direction, Vertex A, Vertex B, int length, string nameStreet, Coating coat)
        {
            Edge arc = new Edge();
            arc.Direction = Direction;
            arc.Length = length;
            arc.SetVertex(A, B);
            arc.NameStreet = nameStreet;
            arc.Coat = coat;
            return arc;
        } 
    }
}
