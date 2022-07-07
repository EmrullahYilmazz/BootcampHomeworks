using BitirmeProjesi.Domain.Entities;
using BitirmeProjesi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BitirmeProjesi.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MongoDbController : ControllerBase
    {
        private readonly IMongoCollection<MongoShoppingList> _shoppinglist;
        public MongoDbController(IOptions<ShoppingListsDatabaseSettings> options)
        {
            //MongoDb de var olan verileri görüntülemek için ihtiyaç olan ayrı bir controller
            var mongoclient = new MongoClient(options.Value.ConnectionString);
            _shoppinglist = mongoclient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<MongoShoppingList>(options.Value.ShoppingListName);

        }

        [HttpGet]
        public async Task<List<MongoShoppingList>> Get() =>
            await _shoppinglist.Find(_ => true).ToListAsync();



        //public async Task<List<MongoShoppingList>> Get() =>
        //    await _shoppinglist.Find(_ => true).ToListAsync();
        //public async Task<MongoShoppingList> Get(string id) =>
        //    await _shoppinglist.Find(m => m.Id == id).FirstOrDefaultAsync();
        //public async Task Create(MongoShoppingList newmongoShoppingList) =>
        //    await _shoppinglist.InsertOneAsync(newmongoShoppingList);
        //public async Task Update(string id, MongoShoppingList updatemongoShoppingList) =>
        //    await _shoppinglist.ReplaceOneAsync(m => m.Id == id, updatemongoShoppingList);
        //public async Task Remove(string id) =>
        //    await _shoppinglist.DeleteOneAsync(m => m.Id == id);
    }
}
