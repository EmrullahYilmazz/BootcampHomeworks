using BitirmeProjesi.Domain.Entitiess;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Domain.Entities
{
    public class MongoShoppingList
    {
        [BsonId]
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public ICollection<Item> Items { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }

        public int IsCompleted { get; set; }
        public string UserId
        {
            get; set;
        }

    }
}
