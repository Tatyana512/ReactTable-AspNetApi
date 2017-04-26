using MongoDb.Models;
using MongoDB.Driver;
using System;

namespace MongoDb
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const string connectionString = "mongodb://localhost:27017";               
                var client = new MongoClient(connectionString);               
                var database = client.GetDatabase("test");                
                var collection = database.GetCollection<Item>("items");
                collection.InsertOne(new Item { Id = Guid.NewGuid(), Name = "Наименование "+(new Random()).Next(0, 1000), Count = 1, DateTime = DateTime.Now });
                var _data = collection.Find(_ => true).ToList();             
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
