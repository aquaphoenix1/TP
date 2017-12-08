using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using TProject.Coll;
using TProject.Graph;

namespace TProject
{
    public class DAO
    {
        private static string DataBaseName { get; } = "Maps_Data_Base.db";

        private static SQLiteConnection connection;

        protected static SQLiteConnection GetConnection()
        {
            if (connection == null)
            {
                try
                {
                    string path = System.IO.Directory.GetCurrentDirectory() + "\\" + DataBaseName;
                    connection = new SQLiteConnection("Data Source=" + path);
                    connection.Open();
                }
                catch
                {
                    connection = null;
                }
            }

            return connection;
        }

        public static bool IsExistDataBase()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\" + DataBaseName;
            return System.IO.File.Exists(path);
        }

        public static void CreateDataBase()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\" + DataBaseName;
            try
            {
                if (GetConnection() == null)
                {
                    throw new SQLiteException();
                }

                #region SQLCommands
                new SQLiteCommand("Create table Maps ([Name] char(30) primary key, [Image] BLOB not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Vertex ([ID] Integer primary key, [XVertex] Integer not null, [YVertex] Integer not null, [Map] char(30) References Maps ([Name]))", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table TrafficLight ([ID]Integer primary key, [GreenSeconds] Integer not null, [RedSeconds] Integer not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Sign ([Type] char(20) primary key, [Value] Integer)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Surface ([NameSurface] char(20) primary key, [KoefSurface] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Street ([Name] char(50) primary key)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Policeman ([TypePolice] char(20) primary key, [Koefficient] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Edge ([ID] Integer primary key, [Direction] bool not null, [SignMaxSpeed] char(20) References Sign ([Type]), [SignTwoWay] bool, [IDVertexFirst] Integer References Vertex ([ID]), [IDVertexSecond] Integer References Vertex ([ID]),  [Name] char(50) References Street ([Name]), [Surface] char(20) References Surface ([NameSurface]), [Police] char(20) references Policeman([TypePolice]), [Map] char(30) References Maps ([Name]))", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Auto ([Model] char(30) primary key, [Fuel] char(30) References Fuel ([Name]), [Сonsumption] real not null, [Speed] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Driver ([FIO] char(30) primary key, [TypeDriver] char(20) not null, [Model] char(30) References Auto ([Model]))", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Fuel ([Name] char(30) primary key, [Cost] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Fine ([NameFine] char(20) primary key, [CostFine] real not null)", GetConnection()).ExecuteNonQuery();

                new SQLiteCommand("Insert into Policeman values ('Добрый', 1)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Insert into Policeman values ('Жадный', 1.5)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Insert into Policeman values ('Супер-жадный', 2.5)", GetConnection()).ExecuteNonQuery();
                #endregion SQLCommands
            }
            catch (SQLiteException) { throw new SQLiteException(String.Format("Невозможно подключиться к файлу базы данных {0}", path)); }
            catch (Exception) { throw new Exception(String.Format("Не найден файл {0}, и отсутствует возможность его создать.", path)); }
        }

        public static List<List<object>> GetAll(string table)
        {
            List<List<object>> list = new List<List<object>>();

            SQLiteDataReader reader = new SQLiteCommand(string.Format("SELECT * FROM {0}", table), GetConnection()).ExecuteReader();

            while (reader.Read())
            {
                List<object> curList = new List<object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    curList.Add(reader[i].ToString());
                }

                list.Add(curList);
            }

            return list;
        }

        public static List<List<object>> GetAll(string table, string where)
        {
            List<List<object>> list = new List<List<object>>();

            SQLiteDataReader reader = new SQLiteCommand(string.Format("SELECT * FROM {0} where {1}", table, where), GetConnection()).ExecuteReader();

            while (reader.Read())
            {
                List<object> curList = new List<object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    curList.Add(reader[i].ToString());
                }

                list.Add(curList);
            }

            return list;
        }

        public static long GetMaxID(string table)
        {
            long val = 0;
            try
            {
                val = (long)new SQLiteCommand(string.Format("SELECT * FROM {0} ORDER BY ID DESC LIMIT 1", table), GetConnection()).ExecuteScalar();
            }
            catch { }
            return val;
        }

        internal static bool InsertMap(Vertexes vertexes, Edges edges, Image img, string name)
        {
            try
            {
                new SQLiteCommand(string.Format("DELETE FROM Vertex where Map = '{0}'", name), GetConnection()).ExecuteNonQuery();
                new SQLiteCommand(string.Format("DELETE FROM Edge where Map = '{0}'", name), GetConnection()).ExecuteNonQuery();
                new SQLiteCommand(string.Format("DELETE FROM Maps where Name = '{0}'", name), GetConnection()).ExecuteNonQuery();

                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    formatter.Serialize(stream, new Bitmap(img));
                    var command = GetConnection().CreateCommand();
                    command.CommandText = string.Format("INSERT INTO Maps VALUES ('{0}', @0);", name);
                    SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary)
                    {
                        Value = stream.ToArray()
                    };
                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();
                }

                if (vertexes != null)
                {
                    for (int i = 0; i < vertexes.GetCountElements(); i++)
                    {
                        var vert = vertexes.GetElement(i);
                        new SQLiteCommand(string.Format("Insert into Vertex values ({0}, {1}, {2}, '{3}')", vert.ID, vert.X, vert.Y, name), GetConnection()).ExecuteNonQuery();
                    }

                }
                if (edges != null)
                {
                    for (int i = 0; i < edges.GetCountElements(); i++)
                    {
                        var edge = edges.GetElement(i);

                        string idSign = (edge.SignMaxSpeed != null) ? edge.SignMaxSpeed.TypeName : "null";

                        string police = (edge.Policemen != null) ? edge.Policemen.TypeName : "null";

                        new SQLiteCommand(string.Format("Insert into Edge values ({0}, '{1}', '{2}', '{3}', {4}, {5}, '{6}', '{7}', '{8}', '{9}')", edge.ID, edge.IsBilateral.ToString(), idSign, edge.SignTwoWay.ToString(), edge.GetHead().ID, edge.GetEnd().ID, edge.NameStreet, edge.Coat.TypeName, police, name), GetConnection()).ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static Bitmap LoadMap(string name, out Vertexes vertexes, out Edges edges)
        {
            try
            {
                var command = GetConnection().CreateCommand();
                command.CommandText = string.Format("SELECT Image from maps where Name = '{0}'", name);
                byte[] array = (byte[])command.ExecuteScalar();
                Bitmap bmp;
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream(array, 0, array.Length))
                {
                    bmp = (Bitmap)new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Deserialize(stream);
                }

                vertexes = new Vertexes();

                var list = GetAll("Vertex", string.Format("Map = '{0}'", name));

                foreach (var vert in list)
                {
                    vertexes.AddNoEvent(Vertex.CreateVertex(long.Parse(vert[0].ToString()), int.Parse(vert[1].ToString()), int.Parse(vert[2].ToString())));
                }

                edges = new Edges();

                list = GetAll("Edge", string.Format("Map = '{0}'", name));

                foreach (var edge in list)
                {
                    Vertex head = vertexes.GetForId(long.Parse(edge[4].ToString()));
                    Vertex end = vertexes.GetForId(long.Parse(edge[5].ToString()));
                    Way.Coating coat = Way.Coating.GetCoatingByName(edge[7].ToString());
                    Way.Sign sign = Way.Sign.GetSignByName(edge[2].ToString());
                    Way.Police police = Way.Police.GetPoliceByName(edge[8].ToString());

                    edges.AddNoEvent(Edge.CreateEdge(long.Parse(edge[0].ToString()), head, end, coat, edge[6].ToString(), bool.Parse(edge[1].ToString()), bool.Parse(edge[3].ToString()), sign, police));
                }

                return bmp;
            }
            catch
            {
                vertexes = null;
                edges = null;

                return null;
            }
        }
    }
}