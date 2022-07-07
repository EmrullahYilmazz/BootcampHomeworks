using BitirmeProjesi.Domain.Entitiess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Infrastructure
{
    public interface IITemService
    {
        public IEnumerable<Item> Get();
        public void Delete(int id);
        public IActionResult Post(string name, int quantity, int shoplistid, Domain.Entitiess.Type type);
    }
}
