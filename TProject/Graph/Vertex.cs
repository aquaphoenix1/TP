using System.Drawing;
using TProject.Way;

namespace TProject.Graph
{
    public class Vertex : Entity
    {
        /// <summary>
        /// Светофор
        /// </summary>
        public TrafficLight TrafficLight { get; set; }

        /// <summary>
        /// Масштаб
        /// </summary>
        public static double Scale { get; set; }

        public static int Radius { get; set; }
        public static int Radius_2 { get; set; }
        
        /// <summary>
        /// Регулируемый перекресток
        /// </summary>
        public bool IsRegular { get { return TrafficLight != null; } }

        private Vertex() { }

        /// <summary>
        /// СОздание вершины
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="X">Координата X</param>
        /// <param name="Y">Координата Y</param>
        /// <param name="trafficLight">Светофор</param>
        /// <returns></returns>
        internal static Vertex CreateVertex(long ID, int X, int Y, TrafficLight trafficLight)
        {
            return new Vertex
            {
                ID = ID,
                X = X,
                Y = Y,
                TrafficLight = trafficLight
            };
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

        public Vertex(int x, int y) : base()
        {
            pointOnMap = new Rectangle(x, y, Radius, Radius);
            TrafficLight = null;
        }

    }
}