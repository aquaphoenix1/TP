using System.Drawing;
using TProject.Way;

namespace TProject.Graph
{
    public class Vertex : Entity
    {
        public TrafficLight TrafficLight { get; set; }

        public static double Scale { get; set; }

        public static int Radius { get; set; }
        public static int Radius_2 { get; set; }
        
        public bool IsRegular { get { return TrafficLight != null; } }

        private Vertex() { }

        internal static Vertex CreateVertex(long ID, int X, int Y)
        {
            return new Vertex
            {
                ID = ID,
                X = X,
                Y = Y
            };
        }

        public void SetRectXY(int x, int y)
        {
            pointOnMap.X = x;
            pointOnMap.Y = y;
        }

        public Rectangle GetRect()
        {
            return pointOnMap;
        }
        private Rectangle pointOnMap;


        public int X
        {
            get { return pointOnMap.X; }
            set { pointOnMap.X = value; }
        }
        public int Y
        {
            get { return pointOnMap.Y; }
            set { pointOnMap.Y = value; }
        }

        static Vertex()
        {
            Radius = 20;
            Radius_2 = Radius / 2;
        }
        public Vertex(int x, int y) : base()
        {
            pointOnMap = new Rectangle(x, y, Radius, Radius);
            TrafficLight = null;
        }
    }
}