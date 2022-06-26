using Hafta5EmrullahYilmazOdev.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Hafta5EmrullahYilmazOdev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;
        public UserController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        [HttpGet]
        [Route("Users")]
        public async Task<IEnumerable<Users>> GetAsync(string usersId)
        {
            var cacheKey = usersId;
            IEnumerable<Users> users;
            string json;

            var FromCache = await _distributedCache.GetAsync(usersId);
            if (FromCache != null)
            {
                json = Encoding.UTF8.GetString(FromCache);
                users = JsonConvert.DeserializeObject<List<Users>>(json);
            }
            else
            {
                users = await Task.Run(() => UserService.GetUsers(usersId));
                json = JsonConvert.SerializeObject(users);
                FromCache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1))
                        .SetAbsoluteExpiration(DateTime.Now.AddMonths(1));
                await _distributedCache.SetAsync(cacheKey, FromCache, options);

            }
            return users;

        }
        //paging search ve filtreleme
        [HttpGet]
        [Route("UsersQuery")]
        public IActionResult GetUsers([FromQuery] Users users)
        {

            var metadata = new
            {
                users.Id,
                users.FirstName,
                users.LastName,
                users.CreatedAt,
                users.UpdatedAt
            };

            Response.Headers.Add("Paging", System.Text.Json.JsonSerializer.Serialize(metadata));
            return Ok(users);
        }
    }
}