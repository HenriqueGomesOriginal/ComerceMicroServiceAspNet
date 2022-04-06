using Catalog.API.Models;
using Catalog.API.Models.Context;

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repository.Implementation
{
    public class ProductsRepository : IProductsRepository
    {
        // Db context
        private readonly IMongoDbContext _context;

        public ProductsRepository(IMongoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Products>> FindAll()
        {
            return await _context.Products.Find(prop => true).ToListAsync();
        }
    }
}
