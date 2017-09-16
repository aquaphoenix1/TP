﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TProject
{
    class EdgeCollection:AbstractCollection<Edge>
    {
        public Edge SearhEdgeWithPoint(int x, int y) //A, C(x,y), B
        {    //((x_3 - x_1) / (x_2 - x_1) == (y_3 - y_1) / (y_2 - y_1))
            return ElementsList.Find(o => (
                (int)(o.GetVertexB().X - o.GetVertexA().X) / (x - o.GetVertexA().X) == (int)(o.GetVertexB().Y - o.GetVertexA().Y) / (y - o.GetVertexA().Y))
            );
        }
        public Edge SearhAllEdge(Vertex vertex)
        {
            //////////
            return ElementsList.Find(o => o.VertexOne.Id == vertex.Id || o.VertexTwo.Id == vertex.Id);
        }

        public override void DrawAllOnPicture(PaintEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
