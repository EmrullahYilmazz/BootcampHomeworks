using Hafta4EmrullahYilmazOdev.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
   
        const string cacheKey = "Key";
        private readonly IMemoryCache _memCache;
        public UserController(IMemoryCache memCache)
        {
            _memCache = memCache;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Users>> Get()
        {
            List<Users> catList = new List<Users> { new Users { FirstName = "Admin"}, new Users { FirstName = "Guest" } };

            if (!_memCache.TryGetValue(cacheKey, out catList))
            {
                var cacheExpOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                    Priority = CacheItemPriority.Normal
                };
                _memCache.Set(cacheKey, catList, cacheExpOptions);
            }
            return catList;
        }

        [HttpGet]
        public ActionResult DeleteCache()
        {
            _memCache.Remove(cacheKey);
            return Ok();
        }

        
    }
}
