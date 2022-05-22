using Catalog.API.Models;

namespace Catalog.API.Repository
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Products>> FindAll();
        public Task<Products> Create(Products products);
        public Task<Products> Update(Products products);
        public Task<Products> Find(string id);
        public Task<bool> Delete(string id);
    }
}
