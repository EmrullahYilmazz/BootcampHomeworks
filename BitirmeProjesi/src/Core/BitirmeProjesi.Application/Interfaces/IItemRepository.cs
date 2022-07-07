using BitirmeProjesi.Domain.Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Application.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<List<Item>> GetAllItem();
        Task<Item> GetItemById(int id);
    }
}
