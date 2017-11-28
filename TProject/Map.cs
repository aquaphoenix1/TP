using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TProject.Coll;
using TProject.Graph;

namespace TProject
{
    static class Map
    {
        public static Vertexes vertexes;
        public static Edges edges;

        public static void InitMap()
        {
            vertexes = new Vertexes();
            edges = new Edges();
        }
    }
}
