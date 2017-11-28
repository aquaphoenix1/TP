using System.Linq;
using TProject.Graph;

namespace TProject.Coll
{
    public class Vertexes : AbstractCollection<Vertex>
    {
        public bool GetSelected(int x, int y)
        {
            for (int i = 0; i < List.Count; i++)
                if (Viewer.IsPointInRectangle(List.ElementAt(i).X, List.ElementAt(i).Y, x, y))
                {
                    Viewer.ViewPort.SelectVertex(List.ElementAt(i));
                    return true;
                }
            Viewer.ViewPort.UnSelectAll();
            return false;
        }
    }
}
