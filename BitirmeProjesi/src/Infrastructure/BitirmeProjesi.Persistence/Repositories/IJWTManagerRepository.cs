using BitirmeProjesi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Persistence.Repositories
{
    public interface IJWTManagerRepository
{
        Tokens Authenticate(User users);
    }
}
