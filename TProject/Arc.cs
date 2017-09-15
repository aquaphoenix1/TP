namespace TProject
{
    class Arc
    {
        public string Direction { get; set; }

        private Vertex VertexOne;
        private Vertex VertexTwo;

        public Police Policemen { get; set; }

        public string NameStreet { get; set; }

        private int Length;

        public Coating Coat { get; set; }

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

        private Arc() { }

        public static Arc CreateArc(string Direction, Vertex A, Vertex B, int length, string nameStreet, Coating coat)
        {
            Arc arc = new Arc();
            arc.Direction = Direction;
            arc.Length = length;
            arc.SetVertex(A, B);
            arc.NameStreet = nameStreet;
            arc.Coat = coat;
            return arc;
        } 
    }
}
