using System.Collections.Generic;
using TProject.Coll;
using TProject.Graph;

namespace TProject
{
    static class Map
    {
        public static string Name;
        public static Vertexes vertexes;
        public static Edges edges;
        public static List<Vertex> Way;

        public static void InitMap()
        {
            vertexes = new Vertexes();
            edges = new Edges();
        }

        

        public static void SetWay(List<long> list)
        {
            Way = new List<Vertex>();
            Vertex vert = null;
            foreach (var o in list)
            {
                if ((vert = vertexes.GetForId(o)) != null)
                {
                    Way.Add(vert);
                }
            }
        }
    }
}
