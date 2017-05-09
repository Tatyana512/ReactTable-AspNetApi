
namespace ApiTestData.Controllers
{
    using Castle.Windsor;
    using Models;
    using System;
    using System.Web.Http;

    [RoutePrefix("api/v1/items")]
    public class ItemsController : ApiController
    {
        public ItemsRepository _repository;
      
        public ItemsController()
        {
             var _container = new WindsorContainer();
            _container.Install(Castle.Windsor.Installer.Configuration.FromAppConfig());
            _repository = _container.Resolve<ItemsRepository>();
        }
        // GET: Items
        [HttpGet]
        [Route("getItems")]
        [AllowAnonymous]
        public IHttpActionResult GetItems()
        {
            var _result = _repository.GetAllItems();
            return Json(_result);
        }

        [HttpGet]
        [Route("createItem")]
        [AllowAnonymous]
        public IHttpActionResult createItem(string name, string count, string date)
        {            
            var _guid = Guid.NewGuid();
            int _count = 0;
            DateTime _date = DateTime.Now;
            int.TryParse(count, out _count);
            DateTime.TryParse(date, out _date);
            var _item = new Item(_guid, name, _count, _date);
            var _result = _repository.CreateItem(_item);
            return Json(_result);
        }

        [HttpGet]
        [Route("updateItem")]
        [AllowAnonymous]
        public IHttpActionResult updateItem(string id, string name, string count, string date)
        {
            Guid _guid;
            int _count = 0;
            DateTime _date = DateTime.Now;
            int.TryParse(count, out _count);
            DateTime.TryParse(date, out _date);

            if (Guid.TryParse(id, out _guid))
            {
                var _item = _repository.GetItemById(id);
                _item.Count = _count;
                _item.Name = name;
                _item.DateTime = _date;
                var _result = _repository.EditItem(_item);
                return Json(_result);
            }
            return null;
        }


        [HttpGet]
        [Route("deleteItem")]
        [AllowAnonymous]
        public IHttpActionResult deleteItem(string id)
        {
            Guid _guid;
            if (Guid.TryParse(id, out _guid))
            {
                var _result = _repository.DeleteItem(id);
                return Json(_result);
            }
            else return null;

        }
    }
}