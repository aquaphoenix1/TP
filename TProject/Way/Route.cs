﻿using System;
using System.Collections.Generic;
using TProject.Coll;
using TProject.Graph;

namespace TProject.Way
{
    public class Route
    {
        public static List<long> Way { private set; get; }
        public static double Value { private set; get; }

        public static Vertex Start;
        public static Vertex End;

        private double[,] GetMatrixWay(out long[,] parents, out long[] arrayOfID, Vertexes vertexes, Edges edges, Main.Criterial criterial, Driver.Driver driver)
        {
            int count = vertexes.GetCountElements();

            double[,] array = new double[count, count];

            parents = new long[count, count];

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
                        array[i, j] = (edge != null) ? edge.GetCriterialValue(criterial, driver, vertexList[j]) : Double.MaxValue;

                        if (edge != null)
                        {
                            for (int p = 0; p < Map.vertexes.GetCountElements(); p++)
                            {
                                if (Map.vertexes.GetElement(p).ID == Start.ID)
                                {
                                    parents[i, j] = p;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            parents[i, j] = long.MaxValue;
                        }
                    }
                }
                arrayOfID[i] = vertexList[i].ID;
            }
            return array;
        }
        private List<long> GetWay(long from, long to, long[,] arrayOfParents)
        {

            List<long> list = new List<long>();

            long vert = arrayOfParents[from, to];

            list.Add(from);

            while (vert != from)
            {
                list.Add(vert);
                vert = arrayOfParents[vert, to];
            }
            list.Add(to);

            return list;
        }

        public void FindMinLengthWay(Vertexes vertColl, Edges edgColl, Main.Criterial criterial, Driver.Driver driver)
        {
            long[,] parents;
            long[] IDs;
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
            double[,] matrix = GetMatrixWay(out parents, out IDs, vertColl, edgColl, criterial, driver);
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

        private bool[] isWas = new bool[Map.edges.GetCountElements()];

        //private List<Vertex> GetWayOfBestTime(Vertexes vertexes, Edges edges, Driver.Driver driver)
        //{
        //    for(int i = 0; i < Map.edges.GetCountElements(); i++)
        //    {
        //        isWas[i] = false;
        //    }

        //    var list = new List<Edge>();

        //    double[,] timeMatrix = new double[list.Count, list.Count];
        //    double[,] traficLightMatrix = new double[list.Count, list.Count];

        //    // double speed = driver.IsViolateTL ? driver.Car.Speed : 60;
        //    double speed;

        //    foreach (var o in list)
        //    {
        //        speed = o.SignMaxSpeed != null ? o.SignMaxSpeed.Count : 60;
        //        speed = driver.IsViolateTL ? driver.Car.Speed : speed;

        //        timeMatrix[o.GetHead().ID, o.GetEnd().ID] = o.GetLength(Viewer.ViewPort.ScaleCoefficient) / speed;
        //    }

        //    Vertex start = Start;
        //    Vertex end = End;

        //    //List<List<long>> wayList = new List<List<long>>();
        //    //List<Edge> edgeList = new List<Edge>();
        //    //foreach (var obj in list)
        //    //{
        //    //    if (obj.IsConnected(start))
        //    //        edgeList.Add(obj);
        //    //}
        //    List<List<long>> wayList = new List<List<long>>();
        //    return null;
        //}

        //private void GetAllConnectedEdges(Vertex start)
        //{
        //    List<Edge> edgeList = new List<Edge>();
        //    foreach (var obj in Map.edges.List)
        //    {
        //        if (obj.IsConnected(start))
        //        {
        //            edgeList.Add(obj);
        //        }
        //    }
        //}
    }
}
