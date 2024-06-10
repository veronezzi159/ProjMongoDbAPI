using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjMongoDbAPI.Models
{
    public class Costumer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
