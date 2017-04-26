using System;
using System.Collections.Generic;
using System.Linq;
using ApiTestData.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ApiTestData
{
    public class MongoDBItemsRepository : ItemsRepository
    {
        public override Item GetItemById(string id)
        {
            try
            {
                ItemToSave _item = null;
                const string connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("test");
                var collection = database.GetCollection<ItemToSave>("items");
                Guid _id;
                if (Guid.TryParse(id, out _id))
                {
                    var _data = collection.Find(a => a.GuidId == _id).FirstOrDefault();
                    return Convertor.ConvertBackClass(_data);
                }
                return Convertor.ConvertBackClass(_item);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public override bool CreateItem(Item item)
        {
            try
            {
                const string connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("test");
                var collection = database.GetCollection<ItemToSave>("items");
                //var _item = new ItemMongo(Guid.NewGuid(), item.Name, item.Count, item.DateTime);
                collection.InsertOne(new ItemToSave{ GuidId = Guid.NewGuid(), Name = "Наименование " + (new Random()).Next(0, 1000), Count = 1, DateTime = DateTime.Now });
                var _data = collection.Find(_ => true).ToList();
                return true;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public override bool DeleteItem(string guid)
        {
            try
            {
                Guid _guid;
                if (Guid.TryParse(guid, out _guid))
                {
                    const string connectionString = "mongodb://localhost:27017";
                    var client = new MongoClient(connectionString);
                    var database = client.GetDatabase("test");
                    var collection = database.GetCollection<Item>("items");
                    var _data = collection.DeleteOne(a => a.Id == _guid);
                    return true;
                }
                throw new Exception("параметры неудовлетворяют требованиям");
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public override bool EditItem(Item item)
        {
            try
            {
                const string connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("test");
                var collection = database.GetCollection<BsonDocument>("items");
                var filter = Builders<BsonDocument>.Filter.Eq("GuidId", item.Id);
                var update = Builders<BsonDocument>.Update
                                                   .Set("Name", item.Name)
                                                   .Set("Count", item.Count)
                                                   .Set("Datetime", item.DateTime);
                var result = collection.UpdateMany(filter, update);
                return true;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);

            }
        }

        public override IList<Item> GetAllItems()
        {
            var _list = new List<Item>();
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<ItemToSave>("items");
            var _data = collection.AsQueryable().ToList();

            foreach (var El in _data)
            {
                _list.Add(Convertor.ConvertBackClass(El));
            }
            return _list;
        }
    }
}