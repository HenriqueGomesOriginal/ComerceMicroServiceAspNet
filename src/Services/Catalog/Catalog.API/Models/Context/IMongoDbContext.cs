using MongoDB.Driver;

namespace Catalog.API.Models.Context
{
    public interface IMongoDbContext
    {
        IMongoCollection<Products> Products { get; }
    }
}
