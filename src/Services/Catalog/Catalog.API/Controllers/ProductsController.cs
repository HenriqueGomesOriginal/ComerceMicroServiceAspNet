using Catalog.API.Business;
using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsBusiness _business;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductsBusiness business, ILogger<ProductsController> logger)
        {
            _business = business ?? throw new ArgumentNullException(nameof(business)); ;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            var products = await _business.FindAll();

            if (products == null) { return NotFound(); } else { return Ok(products); }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Products>> FindProducts(string id)
        {
            var products = await _business.Find(id);

            if (products == null) { return NotFound(); } else { return Ok(products); }
        }

        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> InsertProducts([FromBody] Products products)
        {
            var result = await _business.Update(products);

            if (result == null) { return NotFound(); } else { return Ok(result); }
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> UpdateProducts([FromBody] Products products)
        {
            var ret = await _business.Create(products);

            if (ret == null) { return NotFound(); } else { return Ok(products); }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> DeleteProducts(string id)
        {
            var ret = await _business.Delete(id);

            if (ret != true) { return NotFound(); } else { return NoContent(); }
        }
    }
}
