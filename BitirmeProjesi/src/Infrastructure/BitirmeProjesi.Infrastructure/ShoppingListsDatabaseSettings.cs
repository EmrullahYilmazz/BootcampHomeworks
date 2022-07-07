using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Infrastructure
{
    public class ShoppingListsDatabaseSettings
    {
        //MongoDb için gerekli parametreler
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string ShoppingListName { get; set; } = string.Empty;
    }
}
