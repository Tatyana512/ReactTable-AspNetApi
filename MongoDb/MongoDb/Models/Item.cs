using System;

namespace MongoDb.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime DateTime { get; set; }
    }
}
