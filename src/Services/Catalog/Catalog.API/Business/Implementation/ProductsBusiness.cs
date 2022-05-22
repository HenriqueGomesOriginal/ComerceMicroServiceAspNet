using Catalog.API.Models;
using Catalog.API.Repository;

namespace Catalog.API.Business.Implementation
{
    public class ProductsBusiness : IProductsBusiness
    {
        private IProductsRepository _products;

        public ProductsBusiness(IProductsRepository products)
        {
            _products = products;
        }

        async Task<Products> IProductsBusiness.Create(Products products)
        {
            return await _products.Create(products);
        }

        async Task<bool> IProductsBusiness.Delete(string id)
        {
            return await _products.Delete(id);
        }

        async Task<Products> IProductsBusiness.Find(string id)
        {
            return await _products.Find(id);
        }

        async Task<IEnumerable<Products>> IProductsBusiness.FindAll()
        {
            return await _products.FindAll();
        }

        async Task<Products> IProductsBusiness.Update(Products products)
        {
            return await _products.Update(products);
        }
    }
}
