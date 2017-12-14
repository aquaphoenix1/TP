using System;
using System.Collections.Generic;
using TProject.Coll;
using TProject.Graph;

namespace TProject.Way
{
    public class Route
    {
        /// <summary>
        /// Маршрут из ID
        /// </summary>
        public static List<long> Way { private set; get; }

        /// <summary>
        /// Цена маршрута
        /// </summary>
        public static double Value { private set; get; }

        /// <summary>
        /// Стартовая вершина
        /// </summary>
        public static Vertex Start;

        /// <summary>
        /// КОнечная вершина
        /// </summary>
        public static Vertex End;

        /// <summary>
        /// Критерий поиска
        /// </summary>
        public static Main.Criterial Criterial { get; set; }

        /// <summary>
        /// Текущий водитель
        /// </summary>
        public static Driver.Driver CurrentDriver;

        /// <summary>
        /// Получение матрицы стоимости
        /// </summary>
        /// <param name="parents">Матрица предков</param>
        /// <param name="arrayOfID">Массив ID вершин (для восстановления не по порядку из коллекции)</param>
        /// <param name="vertexes">Коллекция вершин</param>
        /// <param name="edges">Коллекция дуг</param>
        /// <param name="criterial">Критерий поиска</param>
        /// <param name="driver">Водитель</param>
        /// <returns></returns>
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
                        array[i, j] = (edge != null) ? edge.GetCriterialValue(criterial, driver) : Double.MaxValue; //Текущее значение матрицы = критерий текущей дуги

                        parents[i, j] = i;
                    }
                }
                arrayOfID[i] = vertexList[i].ID;
            }
            return array;
        }

        /// <summary>
        /// Восстановление маршрута
        /// 
        /// Итерационное восстановление маршрута из конца в начало
        /// </summary>
        /// <param name="from">ID точки отправления</param>
        /// <param name="to">ID точки прибытия</param>
        /// <param name="arrayOfParents">Матрица предков</param>
        /// <returns></returns>
        private List<long> GetWay(long from, long to, long[,] arrayOfParents)
        {

            List<long> list = new List<long>();

            long vert = arrayOfParents[from, to];
            list.Add(to);

            while (vert != from)
            {
                list.Add(vert);
                vert = arrayOfParents[from, vert];
            }

            list.Add(from);

            list.Reverse();
            return list;
        }

        /// <summary>
        /// Поиск оптимального маршрута
        /// 
        /// Route.Way содержит путь, null, если пути нет
        /// Route.Value - цена маршрута
        /// </summary>
        /// <param name="vertColl">Коллекция вершин</param>
        /// <param name="edgColl">Коллекция дуг</param>
        /// <param name="criterial">Критерий поиска</param>
        /// <param name="driver">Водитель</param>
        public void FindMinLengthWay(Vertexes vertColl, Edges edgColl, Main.Criterial criterial, Driver.Driver driver)
        {
            CurrentDriver = new Driver.Driver(driver.FIO, driver.IsViolateTL, driver.Car);

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
                            parents[i, j] = parents[k, j];
                        }
                    }
                }
            }
            
            if (matrix[fromVertex, toVertex] == Double.MaxValue) //Путь не найден
            {
                Way = null;
            }
            else
            {
                Criterial = criterial;

                List<long> wayList = GetWay(fromVertex, toVertex, parents);

                Way = new List<long>(wayList.Count);

                for (int i = 0; i < wayList.Count; i++)
                {
                    Way.Add(IDs[wayList[i]]);
                }

                Value = matrix[fromVertex, toVertex];
            }
        }

        /// <summary>
        /// ПОлучение дуги между вершинами
        /// </summary>
        /// <param name="one">Первая вершина</param>
        /// <param name="two">Вторая вершина</param>
        /// <param name="edges">Коллекция дуг</param>
        /// <returns></returns>
        public static Edge GetEdge(Vertex one, Vertex two, Edges edges)
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
