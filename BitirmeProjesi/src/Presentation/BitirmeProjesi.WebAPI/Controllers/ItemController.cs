using BitirmeProjesi.Domain.Entitiess;
using BitirmeProjesi.Domain.Entities;
using BitirmeProjesi.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using BitirmeProjesi.Infrastructure;
using Microsoft.Extensions.Caching.Memory;

namespace BitirmeProjesi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        const string cacheKey = "Key";
        private readonly IMemoryCache _memCache;
        private ApplicationDbContext applicationDbContext = null;
        private IITemService service;

        public ItemController(ApplicationDbContext applicationDbContext, IMemoryCache memCache)
        {
            this.applicationDbContext = applicationDbContext;
            _memCache = memCache;
        }

        public ItemController(IITemService service)
        {
            this.service = service;
        }

        [HttpGet("cache")]
        public ActionResult<IEnumerable<Item>> GetByCache()
        {
            //InMemoryCache
            Item item = new Item()
            {
                ShoppingListId = 4,
                Id = 1,
                Name = "pantolon",
                Quantity = 2,
                Type = Domain.Entitiess.Type.Adet
            };
            if (!_memCache.TryGetValue(cacheKey, out item))
            {
                var cacheExpOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                    Priority = CacheItemPriority.Normal
                };
                _memCache.Set(cacheKey, item, cacheExpOptions);
            }
            return Ok();
        }
        [HttpGet]
        public IEnumerable<Item> Get()
        {

            var users = applicationDbContext.Items.ToList();
            return users;
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {

                var ıtem = applicationDbContext.Items.FirstOrDefault(f => f.Id == id);
                applicationDbContext.Remove(ıtem);
                applicationDbContext.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
            return BadRequest();
        }
        [HttpPost]
        public void Post(string name, int quantity,int shoplistid,Domain.Entitiess.Type type)
        {//burada tüm parametreler değilde kullanıcının görmesi gereken parametreler yazıldı sadece
            try
            {
                Item sl = new Item()
                {
                    Name = name,
                    Quantity = quantity,
                    ShoppingListId = shoplistid,
                    Type = type


                };
                applicationDbContext.Items.Add(sl);
                applicationDbContext.SaveChanges();

            }
            catch(Exception e)
            {
                Response.StatusCode = 500;
                throw e;
            }
            
        }
        [HttpPut]
        public void Put(Item user)
        {

            try
            {
                var result = applicationDbContext.ShoppingLists.Find(user.Id);
                if (result != null)
                {
                    applicationDbContext.Entry(result).CurrentValues.SetValues(user);
                    applicationDbContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }
    }
}
