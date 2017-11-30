using System;
using System.Collections.Generic;
using TProject.Coll;
using TProject.Graph;

namespace TProject.Way
{
    public class Route
    {
        public static List<long> Way { private set; get; }
        public double Value { private set; get; }

        public static Vertex Start;
        public static Vertex End;

        private double[,] GetMatrixWay(out int[,] parents, out long[] arrayOfID, Vertexes vertexes, Edges edges, Main.Criterial criterial, Driver.Driver driver)
        {
            int count = vertexes.GetCountElements();

            double[,] array = new double[count, count];

            parents = new int[count, count];

            arrayOfID = new long[count];

            List<Vertex> vertexList = vertexes.List;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i == j)
                    {
                        array[i, j] = 0;
                    }
                    else
                    {
                        Edge edge = GetEdge(vertexList[i], vertexList[j], edges);
                        array[i, j] = (edge != null) ? edge.GetCriterialValue(criterial, driver) : Double.MaxValue;
                        //edge.GetLength(Viewer.ViewPort.ScaleCoefficient) : Double.MaxValue;//edge.GetCriterialValue() : Double.MaxValue;// edge.GetLength() : Double.MaxValue;
                    }
                    parents[i, j] = i;
                }
                arrayOfID[i] = vertexList[i].ID;
            }
            return array;
        }
        private List<long> GetWay(long from, long to, int[,] arrayOfParents)
        {
            List<long> list = new List<long>();

            int vert = arrayOfParents[from, to];

            list.Add(from);
            while (vert != from)
            {
                list.Add(vert);
                vert = arrayOfParents[from, vert];
            }
            list.Add(to);

            return list;
        }

        public void FindMinLengthWay(Vertexes vertColl, Edges edgColl, Main.Criterial criterial, Driver.Driver driver)
        {
            long fromVertex = 0, toVertex = 0;
            for (int i = 0; i < Map.vertexes.GetCountElements(); i++)
            {
                if (Map.vertexes.GetElement(i).ID == Start.ID)
                {
                    fromVertex = i;
                }

                if (Map.vertexes.GetElement(i).ID == End.ID)
                {
                    toVertex = i;
                }
            }
            double[,] matrix = GetMatrixWay(out int[,] parents, out long[] IDs, vertColl, edgColl, criterial, driver);
            int size = (int)Math.Sqrt(matrix.Length);

            for (int k = 0; k < size; ++k)
            {
                for (int i = 0; i < size; ++i)
                {
                    for (int j = 0; j < size; ++j)
                    {
                        if (matrix[i, k] < Double.MaxValue && matrix[k, j] < Double.MaxValue && matrix[i, k] + matrix[k, j] < matrix[i, j])
                        {
                            matrix[i, j] = matrix[i, k] + matrix[k, j];
                            parents[i, j] = k;
                        }
                    }
                }
            }

            if (matrix[fromVertex, toVertex] == Double.MaxValue)
            {
                Way = null;
            }
            else
            {
                List<long> wayList = GetWay(fromVertex, toVertex, parents);

                Way = new List<long>(wayList.Count);

                for (int i = 0; i < wayList.Count; i++)
                {
                    Way.Add(IDs[wayList[i]]);
                }
                
                Value = matrix[fromVertex, toVertex];
            }
        }

        private Edge GetEdge(Vertex one, Vertex two, Edges edges)
        {
            List<Edge> list = edges.List;
            Vertex first = null, second = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].IsBilateral)
                {
                    if (list[i].GetHead() == one && (second = list[i].GetEnd()) == two && list[i].IsConnected(second))
                    {
                        return list[i];
                    }
                }
                else
                {
                    first = list[i].GetHead();
                    second = list[i].GetEnd();
                    if (((first == one && second == two) || (second == one && first == two)))
                    {
                        return list[i];
                    }
                }
            }
            return null;
        }
    }
}
