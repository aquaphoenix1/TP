using System.Drawing;

namespace TProject
{
    class Vertex : Entity
    {
        private static long curMaxId = 0;

        public TrafficLight TrafficLight { get; set; }

        public static double Scale { get; set; }

        public static int Radius { get; set; }
        public static int Radius_2 { get; set; }
        public static Pen Brush { get; set; }

        public void SetRectX(int x)
        {
            pointOnMap.X = x;
        }
        public void SetRectY(int y)
        {
            pointOnMap.Y = y;
        }

        public  Rectangle GetRect()
        {
            return pointOnMap;
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
            Radius = 20;
            Radius_2 = Radius / 2;
        }
        public Vertex(int x, int y)
        {
            ID = ++curMaxId;
            pointOnMap = new Rectangle(x, y, Radius, Radius);
            this.TrafficLight = null;
        }
    }
}