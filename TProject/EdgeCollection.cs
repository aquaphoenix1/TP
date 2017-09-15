using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TProject
{
    class EdgeCollection:AbstractCollection<Edge>
    {
        public Edge SearhVertexPoint(int x, int y) //A, C(x,y), B
        {    //((x_3 - x_1) / (x_2 - x_1) == (y_3 - y_1) / (y_2 - y_1))
            return ElementsList.Find(o => (
            (int)(o.GetVertexB().X - o.GetVertexA().X) / (x - o.GetVertexA().X) == (int)(o.GetVertexB().Y - o.GetVertexA().Y) / (y - o.GetVertexA().Y))
            );
        }
    }
}
