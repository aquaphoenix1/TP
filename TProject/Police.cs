namespace TProject
{
    class Police : Coordinate
    {
        public PoliceType Type { get; set; }
        public double Coefficient { get; set; }
        public Fine FineValue { get; set; }

        public class PoliceType
        {
            string type;

            public PoliceType(string type)
            {
                this.type = type;
            }
        }

        public class Fine
        {
            string name;
            int count;

            public Fine(string name, int count)
            {
                this.name = name;
                this.count = count;
            }
        }
    }
}
