using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TProject.Graph;

namespace TProject.Way
{
    public class Route
    {
        public Vertex Start { get; set; }
        public Vertex End { get; set; }

        public int[,] GetMatrixWay(out int[,] parents, out long[] arrayOfID, VertexCollection vertexes, EdgeCollection edges)
        {
            int count = vertexes.GetCountElements();

            int[,] array = new int[count, count];

            parents = new int[count, count];

            arrayOfID = new long[count];

            List<Vertex> vertexList = vertexes.GetElementsList();

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i == j) array[i, j] = 0;
                    else
                    {
                        Edge edge = GetEdge(vertexList[i], vertexList[j], edges);
                        array[i, j] = (edge != null) ? edge.GetLength() : Int32.MaxValue;
                    }
                    parents[i, j] = i;
                }
                arrayOfID[i] = vertexList[i].ID;
            }
            return array;
        }
        public List<int> GetWay(int from, int to, int[,] arrayOfParents)
        {
            List<int> list = new List<int>();
            list.Add(to);

            int vert = arrayOfParents[from, to];

            while (vert != 0)
            {
                list.Add(vert);

                vert = arrayOfParents[from, vert];
            }

            list.Add(from);

            list.Reverse();

            return list;
        }

        public int FindMinLengthWay(int fromVertex, int toVertex, VertexCollection vertColl, EdgeCollection edgColl)
        {
            int[,] parents;
            long[] IDs;
            int[,] matrix = GetMatrixWay(out parents, out IDs, vertColl, edgColl);
            int size = (int)Math.Sqrt(matrix.Length);

            int length = 0;

            List<int> vertexes = new List<int>();
            List<int> edges = new List<int>();

            for (int k = 0; k < size; ++k)
                for (int i = 0; i < size; ++i)
                    for (int j = 0; j < size; ++j)
                        if (matrix[i, k] < Int32.MaxValue && matrix[k, j] < Int32.MaxValue && matrix[i, k] + matrix[k, j] < matrix[i, j])
                        {
                            matrix[i, j] = matrix[i, k] + matrix[k, j];
                            parents[i, j] = k;
                        }

            List<int> way = GetWay(fromVertex, toVertex, parents);
            string s = String.Empty;

            for (int i = 0; i < way.Count; i++)
                s += IDs[way[i]].ToString() + "\n";

            MessageBox.Show(s);

            return length;
        }

        public Edge GetEdge(Vertex one, Vertex two, EdgeCollection edges)
        {
            List<Edge> list = edges.GetElementsList();
            Vertex first = null, second = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].IsBilateral)
                {
                    if (list[i].GetHead() == one && (second = list[i].GetEnd()) == two && list[i].isConnected(second))
                        return list[i];
                }
                else
                {
                    first = list[i].GetHead();
                    second = list[i].GetEnd();
                    if (((first == one && second == two) || (second == one && first == two)))
                        return list[i];
                }
            }
            return null;
        }


    }
}
