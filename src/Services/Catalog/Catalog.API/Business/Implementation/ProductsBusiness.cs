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

        public Task<IEnumerable<Products>> FindAll()
        {
            return _products.FindAll();
        }
    }
}
