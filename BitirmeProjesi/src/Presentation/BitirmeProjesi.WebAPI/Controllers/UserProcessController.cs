using BitirmeProjesi.Domain.Entities;
using BitirmeProjesi.Domain.Entitiess;
using BitirmeProjesi.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BitirmeProjesi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    // Burada sadece sisteme giriş yapan kullanıcının kendine ait verileri gelir
    public class UserProcessController : ControllerBase
    {
        private ApplicationDbContext _context = null;
        public UserProcessController(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }
        [HttpGet]
        public IEnumerable<ShoppingList> Get()
        {

            var userpostlist = _context.ShoppingLists.Where(s => s.UserId == User.Identity.Name).Include(x => x.Items).ToList();


            return userpostlist;


        }
        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {

            var post = _context.ShoppingLists.Find(id);

            if (post.UserId == User.Identity.Name)
            {
                return Ok(post);
            }
            else
            {
                return BadRequest("You cannot delete this list because it does not belong to you.");
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
            catch(Exception e)
            {
                throw e;
            }

            



        }
        [HttpPut]
        public void Put(ShoppingList user)
        {
            try
            {
                var result = _context.ShoppingLists.Find(user.Id);
                if (result.UserId == User.Identity.Name)
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            
    
        }
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {

                var data = _context.ShoppingLists.Find(id);
                if (data.UserId == User.Identity.Name)
                {
                    _context.ShoppingLists.Remove(data);
                    _context.SaveChanges();
                }
                 
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
