using System;
using System.Collections.Generic;
using System.Data.SQLite;
using TProject.Coll;

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
                new SQLiteCommand("Create table Vertex ([ID] Integer primary key, [XVertex] Integer not null, [YVertex]Integer not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table TrafficLight ([ID]Integer primary key, [GreenSeconds] Integer not null, [RedSeconds] Integer not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Sign ([Type] char(20) primary key, [Value] Integer)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Surface ([NameSurface] char(20) primary key, [KoefSurface] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Street ([Name] char(50) primary key)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Edge ([ID] Integer primary key, [Direction] bool not null, [SignMaxSpeed] char(20) References Sign ([Type]), [SignTwoWay] bool, [IDVertexFirst] Integer References Vertex ([ID]), [IDVertexSecond] Integer References Vertex ([ID]),  [Name] char(50) References Street ([Name]), [Surface] char(20) References Surface ([NameSurface]), [Length] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Policemen ([TypePolice] char(20) primary key, [Koefficient] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Auto ([Model] char(30) primary key, [Fuel] char(30) References Fuel ([Name]), [Сonsumption] real not null, [Speed] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Driver ([FIO] char(30) primary key, [TypeDriver] char(20) not null, [Model] char(30) References Auto ([Model]))", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Fuel ([Name] char(30) primary key, [Cost] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Fine ([NameFine] char(20) primary key, [CostFine] real not null)", GetConnection()).ExecuteNonQuery();

                new SQLiteCommand("Insert into Policemen values ('Добрый', 1)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Insert into Policemen values ('Жадный', 1.5)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Insert into Policemen values ('Супер-жадный', 2.5)", GetConnection()).ExecuteNonQuery();
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

        internal static bool InsertMap(Vertexes vertexes, Edges edges)
        {
            try
            {
                new SQLiteCommand("DELETE FROM Vertex", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("DELETE FROM Edge", GetConnection()).ExecuteNonQuery();

                for (int i = 0; i < vertexes.GetCountElements(); i++)
                {
                    var vert = vertexes.GetElement(i);
                    new SQLiteCommand(string.Format("Insert into Vertex values ({0}, {1}, {2})", vert.ID, vert.X, vert.Y), GetConnection()).ExecuteNonQuery();
                }

                for (int i = 0; i < edges.GetCountElements(); i++)
                {
                    var edge = edges.GetElement(i);

                    string idSign = (edge.SignMaxSpeed != null) ? edge.SignMaxSpeed.TypeName : "null";

                    new SQLiteCommand(string.Format("Insert into Edge values ({0}, '{1}', '{2}', '{3}', {4}, {5}, '{6}', '{7}', {8})", edge.ID, edge.IsBilateral.ToString(), idSign, edge.SignTwoWay.ToString(), edge.GetHead().ID, edge.GetEnd().ID, edge.NameStreet, edge.Coat.TypeName, edge.GetLength(Viewer.ViewPort.ScaleCoefficient).ToString().Replace(',', '.')), GetConnection()).ExecuteNonQuery();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static bool LoadMap()
        {
            try
            {

                return true;
            }
            catch
            {
                return false;
            }
        }

        /*public void ExecuteForMap(int[,] matrix, string name)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, matrix);
                var command = Connection.CreateCommand();
                command.CommandText = "INSERT INTO maps VALUES (" + (GetMaxId("maps") + 1) + ", @0, '" + name + "');";
                SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary);
                param.Value = stream.ToArray();
                command.Parameters.Add(param);
                command.ExecuteNonQuery();
            }
        }

        private int[,] GetByQueryMap(string query)
        {
            var command = Connection.CreateCommand();
            command.CommandText = query;
            byte[] array = (byte[])command.ExecuteScalar();
            int[,] newMatrix = null;
            using (MemoryStream stream = new MemoryStream(array, 0, array.Length))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                newMatrix = (int[,])formatter.Deserialize(stream);
            }
            return newMatrix;
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            return new Bitmap(ms);
        }*/
    }
}