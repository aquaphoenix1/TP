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
    }
}
