using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Windows;

namespace EasyHabit
{
    public class SqliteDataAccess
    {
        private static SQLiteConnection conn;
        private static SQLiteCommand cmd;

        private static void SetConn()
        {
            conn = new SQLiteConnection("Data Source=./EasyHabitDB.db; Version=3;");
        }

        public static List<HabitModel> LoadHabits()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionStr()))
            {
                var output = cnn.Query<HabitModel>("select * from Habit", new DynamicParameters());

                return output.ToList();
            }
        }
        public static void SaveHabit(HabitModel habit)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionStr()))
            {
                cnn.Execute($"insert into Habit (habitName, startDate, progress, _minus0, _minus1, _minus2, _minus3, _minus4, _minus0Date, _minus1Date, _minus2Date, _minus3Date, _minus4Date)" +
                    $" values (@habitName,  '{habit.startDate}', '{habit.progress}'," +
                    $" '{habit._minus0}', '{habit._minus1}', '{habit._minus2}', '{habit._minus3}', '{habit._minus4}'," +
                    $" '{habit._minus0Date}', '{habit._minus1Date}', '{habit._minus2Date}', '{habit._minus3Date}', '{habit._minus4Date}')", param:habit);
            }
        }
        public static string LoadConnectionStr(string id = "MyConnectionToDB")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static void ExecuteQuery(string textOfQuery)
        {
            SetConn();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = textOfQuery;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteHabit(string name)
        {
            string textCommand = "delete from Habit where habitName='" + name + "'";
            ExecuteQuery(textCommand);
        }
        public static void UpdateName(string oldName, string nameToSet)
        {
            string textCommand = "update Habit set habitName='"+nameToSet+"' where habitName='"+oldName+"'";
            ExecuteQuery(textCommand);
        }
        public static void UpdateAll(HabitModel habit)
        {
            string textCommand = "update Habit set progress='" + habit.progress + "', _minus0='" + habit._minus0 + "', _minus1='" + habit._minus1 +
                "', _minus2='" + habit._minus2 + "', _minus3='" + habit._minus3 + "', _minus4='" + habit._minus4 + "', _minus0Date='" + habit._minus0Date + 
                "', _minus1Date='" + habit._minus1Date + "', _minus2Date='" + habit._minus2Date + "', _minus3Date='" + habit._minus3Date +
                "', _minus4Date='" + habit._minus4Date + "' where habitName='" + habit.habitName + "'";

            ExecuteQuery(textCommand);
        }
    }
}