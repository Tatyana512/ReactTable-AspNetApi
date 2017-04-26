using MongoDB.Bson.Serialization.Attributes;
using System;
namespace ApiTestData.Models
{
    public class Item
    {
        public Guid _id;
        public string _name;
        public int _count;
        public DateTime _dateTime;
        public Item(Guid id, string name, int count, DateTime datetime)
        {
            _id = id;
            _name = name;
            _count = count;
            _dateTime = datetime;
        }
        public Guid Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value;  } }
        public int Count { get { return _count; }  set { _count = value;  } }
        public DateTime DateTime { get { return _dateTime;  } set { _dateTime = value; } }
    }

    //public class ItemMongo
    //{
    //    public Guid _guidid;
    //    public string _name;
    //    public int _count;
    //    public DateTime _dateTime;
    //    public ItemMongo(Guid id, string name, int count, DateTime datetime)
    //    {
    //        _guidid = id;
    //        _name = name;
    //        _count = count;
    //        _dateTime = datetime;
    //    }
    //    public Guid GuidId { get { return _guidid; } set { _guidid = value; } }
    //    public string Name { get { return _name; } set { _name = value; } }
    //    public int Count { get { return _count; } set { _count = value; } }
    //    public DateTime DateTime { get { return _dateTime; } set { _dateTime = value; } }
    //}

    [BsonIgnoreExtraElements]
    public class ItemToSave
    {
        public Guid GuidId;
        public string Name;
        public int Count;
        public DateTime DateTime;
    }



}