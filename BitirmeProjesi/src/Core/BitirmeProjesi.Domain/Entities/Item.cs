using BitirmeProjesi.Domain.Common;
using BitirmeProjesi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Domain.Entitiess
{
    public class Item : BaseEntity
    {
        
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int? ShoppingListId { get; set; }
        public Type Type { get; set; }

    }
    public enum Type
    {
        Litre = 0, 
        Kilogram= 1,
        Adet = 2,
        
    }
}
