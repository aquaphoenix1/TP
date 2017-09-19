using System;
using System.Data.SQLite;

namespace TProject
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
                    connection = new SQLiteConnection("Data Source=" + path);
                    connection.Open();
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
                new SQLiteCommand("Create table Vertex ([IDVertex] Integer primary key autoincrement, [XVertex] Integer not null,[YVertex]Integer not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table TrafficLight ([ID]Integer primary key autoincrement, [GreenSeconds] Integer not null, [RedSeconds] Integer not null, [IDVertex] Integer References Vertex ([IDVertex]))", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Sign ([NameSign] char(20) primary key, [XSign] Integer not null, [YSign]Integer not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Street ([IDStreet] integer primary key autoincrement, [NameStreet] char(40) not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Surface ([NameSurface] char(20) primary key, [KoefSurface] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Edge ([IDEdge] Integer primary key autoincrement, [Direction] char(15) not null,[NameSign] char(20) References Sign ([NameSign], [IDVertexFirst] Integer References Vertex ([IDVertex]), [IDVertexSecond] Integer References Vertex ([IDVertex]),  [IDStreet] char(40) References Street ([IDStreet]), [NameSurface] char(20) References Surface ([NameSurface]), [Length] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table TypePolicemen ([TypePolice] char(20) primary key, [KoefPolice] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Policemen ([IDPolicemen] integer primary key,[XPolicemen] Integer not null,[YPolicemen] Integer not null, [FioPolice] char(50), [TypePolice] char(20) References TypePolicemen ([TypePolice]), [IDEdge] Integer References Edge ([IDEdge] )", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Driver ([IDDriver] Integer primary key, [TypeDriver] char(20) not null, [FioDriver] char(50))", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Fuel ([NameFuel] char(20) primary key, [Cost] real not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Auto ([IDAuto] Integer primary key autoincrement, [NameFuel] char(20) References Fuel ([NameFuel], [Model] char(10), [Сonsumption] Integer, [Speed] Integer)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Fine ([NameFine] char(20) primary key, [CostFine] Integer not null)", GetConnection()).ExecuteNonQuery();
                new SQLiteCommand("Create table Offense ([IDAuto] Integer References Auto ([IDAuto]), [IDPolicemen] Integer References Policemen ([IDPolicemen]), [NameFine] char(20) References Fine ([NameFine]), [SumFine] Integer, Constraint PK primary key (IDAuto,IDPolicemen, NameFine))", GetConnection()).ExecuteNonQuery();
                return true;
            }
        }
    }
}