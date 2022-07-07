using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Domain.Entities
{
    public class MongoItem
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int? ShoppingListId { get; set; }
        public Type Type { get; set; }
    }
    public enum Type
    {
        Litre = 0,
        Kilogram = 1,
        Adet = 2,

    }
}