using System;
using System.Data.SQLite;

namespace DAOLibrary
{
    public class DAO
    {
        private static string DataBaseName { get; } = "Maps_Data_Base.db";

        private static SQLiteConnection connection;

        private static SQLiteConnection GetConnection()
        {
            if (connection != null)
                return connection;
            else
            {
                try
                {
                    string path = System.IO.Directory.GetCurrentDirectory() + "\\" + DataBaseName;
                    connection = new SQLiteConnection("DataSource=" + path);
                }
                catch
                {
                    connection = null;
                }
                return connection;
            }
        }

        public static bool IsExistDataBase()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\" + DataBaseName;
            return System.IO.File.Exists(path);
        }

        public static bool CreateDataBase()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\" + DataBaseName;
            SQLiteConnection.CreateFile(path);
            SQLiteConnection connection = GetConnection();
            if (connection == null)
                return false;
            else
            {
                new SQLiteCommand("Create table TrafficLight ([ID]Integer primary key autoincrement, [GreenSeconds] Integer not null, [RedSeconds] Integer not null)", GetConnection()).ExecuteNonQuery();
                return true;
            }
        }
    }
}

