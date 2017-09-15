namespace TProject
{
    class Police : Coordinate, Type, Coefficient
    {
        public string Type { get; set; }
        public double Coeff { get; set; }
        public Fine FineValue { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public class Fine
        {
            public string Name { get; set; }
            public int Count { get; set; }

            public Fine(string name, int count)
            {
                this.Name = name;
                this.Count = count;
            }
        }

        public Police(string type, double coefficient, Fine fine, int x, int y)
        {
            this.Type = Type;
            this.Coeff = coefficient;
            this.FineValue = fine;
            this.X = x;
            this.Y = y;
        }
    }
}
