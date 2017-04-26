using ApiTestData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTestData
{
    public abstract class ItemsRepository
    {
        public abstract IList<Item> GetAllItems();
        public abstract bool DeleteItem(string id);
        public abstract bool CreateItem(Item item);
        public abstract bool EditItem(Item item);
        public abstract Item GetItemById(string id);    

    }
}