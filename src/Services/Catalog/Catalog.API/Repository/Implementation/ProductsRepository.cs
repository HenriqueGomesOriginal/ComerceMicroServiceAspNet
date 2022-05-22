using Catalog.API.Models;
using Catalog.API.Models.Context;
using MongoDB.Driver;

namespace Catalog.API.Repository.Implementation
{
    public class ProductsRepository : IProductsRepository
    {
        // Db context
        private readonly MongoDbContext _context;

        public ProductsRepository(MongoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Products> Create(Products products)
        {
            await _context.Products.InsertOneAsync(products);
            return products;
        }

        public async Task<bool> Delete(string id)
        {
            var ret = await _context.Products.DeleteOneAsync(prop => prop.Id == id);
            if (ret.DeletedCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Products> Find(string id)
        {
            return await _context.Products.Find(prop => prop.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Products>> FindAll()
        {
            return await _context.Products.Find(prop => true).ToListAsync();
        }

        public async Task<Products> Update(Products products)
        {
            var ret =  await _context.Products.ReplaceOneAsync(prop => prop.Id == products.Id, products);
            if (ret.ModifiedCount > 0)
            {
                return products;
            } 
            else
            {
                return null;
            }
        }
    }
}
