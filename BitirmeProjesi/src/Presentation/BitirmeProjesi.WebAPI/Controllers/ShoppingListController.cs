using BitirmeProjesi.Domain.Entities;
using BitirmeProjesi.Domain.Entitiess;
using BitirmeProjesi.Infrastructure;
using BitirmeProjesi.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BitirmeProjesi.WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShoppingListController : ControllerBase
    {
        
        private ApplicationDbContext _context = null;
        private readonly IMongoCollection<MongoShoppingList> _shoppinglist;
        private readonly IMessageProducer _messagePublisher;
        public ShoppingListController(ApplicationDbContext applicationDbContext, IMessageProducer messagePublisher, IOptions<ShoppingListsDatabaseSettings> options)
        {
            _messagePublisher = messagePublisher;
            this._context = applicationDbContext;
            var mongoclient = new MongoClient(options.Value.ConnectionString);
            _shoppinglist = mongoclient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<MongoShoppingList>(options.Value.ShoppingListName);
        }
        [HttpGet]
        public IEnumerable<ShoppingList> Get()
        {// tüm kullanıcıların bilgisini getirir
            //var users = _context.ShoppingLists.ToList();
            try
            {
                var itemname = _context.ShoppingLists.Include(x => x.Items).ToList();
                // include kullanmamın sebebi verilerin normalde null olarak dönnmesi. Lazy loading ya da include kullanacaktım include seçtim
                var users = _context.ShoppingLists.ToList();



                return itemname;
            }
            catch(Exception e)
            {
                throw e;
            }
            


        }

        [HttpGet("GetById")]
        public ShoppingList Get(int id)
        {
            try
            {
                var user = _context.ShoppingLists.Find(id);
                return user;
            }
            catch(Exception e)
            {
                throw e;

            }

        }
        [HttpPost]
        public void Post(string categoryname, string title, ICollection<Item> Items)
        {

            try
            {
                ShoppingList sl = new ShoppingList()
                {
                    CategoryName = categoryname,
                    Title = title,
                    Items = Items,
                    CreatedDate = DateTime.Now,
                    UserId = User.Identity.Name,


                };
                _context.ShoppingLists.Add(sl);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }




        }
        [HttpPatch]
        public void IsCompleted(int iscompleted,int listid)
        {//burada MSSQL den gelen veriler shoppinglistin tamamlanmasıyla birlikte MongoDb ye RabbitMQ aracılığıyla gider
            var shoppinglist = _context.ShoppingLists.Include(x => x.Items).FirstOrDefault(x => x.Id == listid);
      
            if (iscompleted == 1)
            {
                MongoShoppingList mg = new MongoShoppingList()
                {
                    Id = Convert.ToString(shoppinglist.Id),
                    CategoryName = shoppinglist.CategoryName,
                    Title = shoppinglist.Title,
                    Items = shoppinglist.Items,
                    CompletedDate = DateTime.Now,
                    CreatedDate = shoppinglist.CreatedDate,
                    IsCompleted = iscompleted,
                    UserId = shoppinglist.UserId
                };
                _shoppinglist.InsertOne(mg);
                _messagePublisher.SendMessage(mg);
            }

        }
        [HttpPut]
        public void Put(ShoppingList user)
        {
            try
            {
                var result = _context.ShoppingLists.Find(user.Id);
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {

                var user = _context.ShoppingLists.Find(id);
                _context.ShoppingLists.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        



    }
}
