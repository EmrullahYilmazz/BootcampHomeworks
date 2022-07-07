using BitirmeProjesi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Application.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity 
    {
        Task<List<T>> GetAllItem();
        Task<T> GetById(int id);
    }
}
