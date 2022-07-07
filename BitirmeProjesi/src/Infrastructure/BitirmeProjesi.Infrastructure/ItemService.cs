using BitirmeProjesi.Domain.Entitiess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Infrastructure
{
    public class ItemService : IITemService
    {
        public IEnumerable<Item> Get() => throw new NotImplementedException();
        public void Delete(int id) => throw new NotImplementedException();
        public IActionResult Post(string name, int quantity, int shoplistid, Domain.Entitiess.Type type) => throw new NotImplementedException();
    }
}
