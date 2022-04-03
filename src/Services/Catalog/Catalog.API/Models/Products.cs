using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Sumary")]
        public string Sumary { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Price")]
        public float Price { get; set; }
    }
}
