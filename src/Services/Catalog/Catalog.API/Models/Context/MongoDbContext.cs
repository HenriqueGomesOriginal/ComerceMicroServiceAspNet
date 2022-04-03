using MongoDB.Driver;

namespace Catalog.API.Models.Context
{
    public class MongoDbContext
    {
        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            
            // To seed database default values
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Products>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }

        public IMongoCollection<Products> Products { get; }
    }
}
