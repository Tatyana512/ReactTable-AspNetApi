using System;
using System.Collections.Generic;
using ApiTestData.Models;
using System.Data.SQLite;

namespace ApiTestData
{
    public class SqlLiteItemsRepository : ItemsRepository
    {   
        public override Item GetItemById(string id)
        {
            try
            {
                Item _result = null;
                const string databaseName = @"D:\cyber.db";
                SQLiteConnection connection =
                    new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                SQLiteCommand command =
                      new SQLiteCommand($"SELECT * FROM example WHERE id='{id}'", connection);
                connection.Open();
                SQLiteDataReader sqReader = command.ExecuteReader();
                try
                {
                    while (sqReader.Read())
                    {
                        _result = DataTransform.ToItem(sqReader);
                    }
                }
                finally
                {
                }
                connection.Close();
                return _result;
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public override bool CreateItem(Item item)
        {
           try
            {
                const string databaseName = @"D:\cyber.db";                              
                SQLiteConnection connection =
                    new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                var command = new SQLiteCommand($"INSERT INTO 'example' ('id', 'name', 'count', 'date') VALUES ('{item.Id}', '{item.Name}', {item.Count}, '{item.DateTime}' );", connection);               
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public override bool DeleteItem(string guid)
        {
            try
            {
                const string databaseName = @"D:\cyber.db";
                SQLiteConnection connection =
                    new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                SQLiteCommand command =
                      new SQLiteCommand($"DELETE FROM example WHERE id='{guid}'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public override bool EditItem(Item item)
        {
            try
            {
                const string databaseName = @"D:\cyber.db";
                SQLiteConnection connection =
                    new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                SQLiteCommand command =
                      new SQLiteCommand($"UPDATE example SET name='{item.Name}', count='{item.Count}', date='{item.DateTime}' WHERE id='{item.Id}'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        public override IList<Item> GetAllItems()
        {
            var _items = new List<Models.Item>();
            const string databaseName = @"D:\cyber.db";
            SQLiteConnection connection =
                new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            SQLiteCommand command =
                  new SQLiteCommand("SELECT * FROM example", connection);
            connection.Open();
            SQLiteDataReader sqReader = command.ExecuteReader();
            try
            {
                while (sqReader.Read())
                {
                    _items.Add(DataTransform.ToItem(sqReader));
                }
            }
            finally
            {
            }
            connection.Close();
            return _items;
        }
    }
}