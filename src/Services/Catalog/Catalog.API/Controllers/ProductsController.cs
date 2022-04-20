using Catalog.API.Business;
using Catalog.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsBusiness _business;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductsBusiness business, ILogger<ProductsController> logger)
        {
            _business = business ?? throw new ArgumentNullException(nameof(business)); ;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }



        // GET: ProductsController
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            var products = await _business.FindAll();

            if (products == null) { return NotFound(); } else { return Ok(products); }
        }
    }
}
