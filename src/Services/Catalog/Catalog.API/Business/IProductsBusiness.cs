using Catalog.API.Models;

namespace Catalog.API.Business
{
    public interface IProductsBusiness
    {
        Task<IEnumerable<Products>> FindAll();
    }
}
