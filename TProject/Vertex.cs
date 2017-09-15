namespace TProject
{
    class Vertex : Coordinate
    {
        public TrafficLight TrafficLight { get; set; }

        public Vertex()
        {
            this.TrafficLight = null;
        }
    }
}
