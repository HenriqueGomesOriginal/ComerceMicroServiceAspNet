using Catalog.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repository
{
    public interface IProductsRepository
    {
        //public Task<int> Create { get; set; }
        //public Task<int> Update { get; set; }
        //public Task<int> Delete { get; set; }
        Task<IEnumerable<Products>> FindAll();
    }
}
