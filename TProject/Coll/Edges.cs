using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TProject.Graph;

namespace TProject.Coll
{
    public class Edges : AbstractCollection<Edge>
    {
        public bool GetSelected(int x, int y)
        {
            for (int i = 0; i < List.Count; i++)
                if (Viewer.IsPointOnEdge(x, y, List.ElementAt(i).GetHead().X, List.ElementAt(i).GetHead().Y,
                    List.ElementAt(i).GetEnd().X, List.ElementAt(i).GetEnd().Y))
                {
                    Viewer.ViewPort.SelectEdge(List.ElementAt(i));
                    return true;
                }
            Viewer.ViewPort.UnSelectAll();
            return false;
        }
    }
}
