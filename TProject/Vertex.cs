using System.Drawing;

namespace TProject
{
    class Vertex : Coordinate
    {
        private static long curMaxId = 0;

        public long Id { get; }
        public TrafficLight TrafficLight { get; set; }

        public static double Scale { get; set; }

        static private Pen activVertex;
        static private Pen generalVertex;
        static public Pen ActivVertex
        {
            get { return activVertex; }
            set { activVertex = value; }
        }
        static public Pen GeneralVertex
        {
            get { return generalVertex; }
            set { generalVertex = value; }
        }


        public static int Radius { get; set; }
        public static int Radius_2 { get; set; }
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
            Radius = 20;
            Radius_2 = Radius / 2;
            generalVertex = new Pen(Brushes.DarkBlue, Vertex.Radius / 2);
            activVertex = new Pen(Color.Aqua, Vertex.Radius / 2);
        }
        public Vertex(int x, int y)
        {
            Id = ++curMaxId;
            pointOnMap = new Rectangle(x, y, Radius, Radius);
            this.TrafficLight = null;
        }

        public Vertex(int x, int y, TrafficLight trafficLight)
        {
            x = (int)(x / Scale);
            x = (int)(y / Scale);

            Id = ++curMaxId;
            pointOnMap = new Rectangle(x, y, Radius, Radius);
            this.TrafficLight = trafficLight;
        }
    }
}