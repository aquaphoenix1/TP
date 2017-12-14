using System.Linq;
using TProject.Graph;

namespace TProject.Coll
{
    public class Edges : AbstractCollection<Edge>
    {
        public bool GetSelected(int x, int y)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (MakeMap.IsPointOnEdge(x, y, List.ElementAt(i).GetHead().X, List.ElementAt(i).GetHead().Y,
                    List.ElementAt(i).GetEnd().X, List.ElementAt(i).GetEnd().Y))
                {
                    MakeMap.ViewPort.SelectEdge(List.ElementAt(i));
                    return true;
                }
            }

            MakeMap.ViewPort.UnSelectAll();
            return false;
        }

        public bool TryCopy(long id1, double id2)
        {
            foreach (var o in List)
            {
                if ((o.GetHead().ID == id1 && o.GetEnd().ID == id2) ||
                    (o.GetEnd().ID == id1 && o.GetHead().ID == id2))
                {
                    return false;
                }
            }

            return true;
        }

        public void DeleteAllConnection(Vertex vertex)
        {
            List.RemoveAll(o => o.GetHead().Equals(vertex) || o.GetEnd().Equals(vertex));
        }
    }
}
