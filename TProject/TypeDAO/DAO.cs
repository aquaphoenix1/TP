using System;
using System.Collections.Generic;
using System.Data.SQLite;

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
                // new SQLiteCommand("Create table Map ([IDMap] Integer primary key autoincrement, [File] Integer not null, [YVertex]Integer not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Vertex ([ID] Integer primary key, [XVertex] Integer not null,[YVertex]Integer not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table TrafficLight ([ID]Integer primary key, [GreenSeconds] Integer not null, [RedSeconds] Integer not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Sign ([ID] integer primary key, [Type] char(20) not null, [Value] Integer)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Surface ([ID] Integer primary key, [NameSurface] char(20) not null, [KoefSurface] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Street ([ID] Integer primary key, [Name] char(50) not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Edge ([ID] Integer primary key, [Direction] bool not null, [IDSign] integer References Sign ([ID]), [IDVertexFirst] Integer References Vertex ([ID]), [IDVertexSecond] Integer References Vertex ([ID]),  [IDName] char(50) References Street ([ID]), [IDSurface] char(20) References Surface ([ID]), [Length] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Policemen ([ID] integer primary key, [TypePolice] char(20) not null, [Koefficient] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Auto ([ID] Integer primary key, [Model] char(30), [IDFuel] Integer References Fuel ([ID]), [Сonsumption] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Driver ([ID] Integer primary key, [TypeDriver] char(20) not null, [IDAuto] Integer References Auto ([ID]))", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Fuel ([ID] Integer primary key, [Name] char(30) not null, [Cost] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Fine ([ID] Integer primary key, [NameFine] char(20), [CostFine] real not null)", GetConnection()).ExecuteNonQuery();
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