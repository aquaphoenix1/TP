using System.Drawing;

namespace TProject
{
    class Vertex : Coordinate
    {
        private static long curMaxId = 0;

        public long Id { get; }
        public TrafficLight TrafficLight { get; set; }

        public static int Radius { get; set; }
        public static Pen Brush { get; set; }

        public ref Rectangle GetRect()
        {
            return ref pointOnMap;
        }
        private Rectangle pointOnMap;

        public int X {
            get { return pointOnMap.X; }
            set { pointOnMap.X = value; }
        }
        public int Y {
            get { return pointOnMap.Y; }
            set { pointOnMap.Y = value; }
        }

        static Vertex()
        {
            Brush = new Pen(Color.Black);
            Radius = 10;
        }
        public Vertex(int x, int y)
        {
            Id = ++curMaxId;
            pointOnMap = new Rectangle(x, y, Radius, Radius);
            this.TrafficLight = null;
        }

        public Vertex(int x, int y, TrafficLight trafficLight)
        {
            Id = ++curMaxId;
            pointOnMap = new Rectangle(x, y, Radius, Radius);
            this.TrafficLight = trafficLight;
        }
    }
}