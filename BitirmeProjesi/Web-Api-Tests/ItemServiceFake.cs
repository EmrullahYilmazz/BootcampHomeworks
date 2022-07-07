using BitirmeProjesi.Domain.Entitiess;
using BitirmeProjesi.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api_Tests
{
    public class ItemServiceFake : IITemService
    {
        private readonly List<Item> _item;

        public ItemServiceFake()
        {
            _item = new List<Item>()
            {
                new Item() { Id = 1, Name = "Ceket", Quantity = 1, ShoppingListId=4, Type = BitirmeProjesi.Domain.Entitiess.Type.Adet }
            };
        }

        public void Delete(int id)
        {
            var exist = _item.First(a => a.Id == id);
            _item.Remove(exist);
        }

        public IEnumerable<Item> Get()
        {
            return _item;
        }

        public IActionResult Post(string name, int quantity, int shoplistid, BitirmeProjesi.Domain.Entitiess.Type type)
        {
            Item it = new Item()
            {
                ShoppingListId = shoplistid,
                Name = name,
                Quantity = quantity,
                Type = type
            };
            _item.Add(it);
            return((IActionResult)it);
        }

        
    }
}
