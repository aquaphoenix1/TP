namespace TProject
{
    class Vertex : Coordinate
    {
        public TrafficLight TrafficLight { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Vertex(int x, int y)
        {
            this.TrafficLight = null;
            this.X = x;
            this.Y = y;
        }

        public Vertex(int x, int y, TrafficLight trafficLight)
        {
            this.TrafficLight = trafficLight;
            this.X = x;
            this.Y = y;
        }
    }
}
