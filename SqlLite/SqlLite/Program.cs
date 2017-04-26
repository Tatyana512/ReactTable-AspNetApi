namespace SqlLite
{
    using System;
    using System.Data.SQLite;
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                const string databaseName = @"D:\cyber.db";
                SQLiteConnection connection =
                    new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                SQLiteCommand command =
                    new SQLiteCommand("CREATE TABLE example (id TEXT PRIMARY KEY, name TEXT, count INTEGER, date DATETIME );", connection);
                connection.Open();
                command.ExecuteNonQuery();
                for (var i = 0; i < 100; i++)
                {
                    var _random = (new Random()).Next(0, 1000);
                    var _guid = Guid.NewGuid();
                    var _strvalue = "Наименование товара " + i.ToString();
                    var _date = DateTime.Parse("2017-05-01 10:00:00");
                    command = new SQLiteCommand($"INSERT INTO 'example' ('id', 'name', 'count', 'date') VALUES ('{_guid}', '{_strvalue}', {_random}, '{_date}' );", connection);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                Console.ReadKey(true);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadKey(true);
            }
        }
    }
}
