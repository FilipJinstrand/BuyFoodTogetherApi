using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyFoodTogetherApi.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        [BsonElement("Person")]
        public string Person { get; set; }

        [BsonElement("IsCompleted")]
        public bool IsCompleted { get; set; }
    }
}
