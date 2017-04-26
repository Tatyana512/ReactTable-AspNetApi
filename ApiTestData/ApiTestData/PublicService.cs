using System;
using System.Configuration;


namespace ApiTestData
{
    public class ItemsService
    {
        private ItemsRepository _repository;

        public ItemsService()
        {
            string connectionVariant =
               ConfigurationManager.AppSettings["connectionVar"];

            if (_repository != null) 
            if (connectionVariant == "")
                    throw new ArgumentNullException("webconfigConnectionString::false");
            switch (connectionVariant)
            {
                case "mongodb": _repository = new MongoDBItemsRepository();
                    break;

                case "sqlite": _repository = new SqlLiteItemsRepository();
                    break;              
              
            }
          
        }

        public ItemsRepository GetRespository()
        {
            if (_repository != null) return _repository;
            else
            {
                throw new ArgumentNullException("_repository");
            }
        }
    }
}