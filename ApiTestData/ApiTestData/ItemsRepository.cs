namespace ApiTestData
{
    using ApiTestData.Models;
    using System.Collections.Generic;
    public abstract class ItemsRepository
    {
        public abstract IList<Item> GetAllItems();
        public abstract bool DeleteItem(string id);
        public abstract bool CreateItem(Item item);
        public abstract bool EditItem(Item item);
        public abstract Item GetItemById(string id);    

    }
}