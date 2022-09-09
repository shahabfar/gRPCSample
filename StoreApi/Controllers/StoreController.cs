using Microsoft.AspNetCore.Mvc;
using StoreApi.gRPC;
using StoreApi.Model;

namespace StoreApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IProductDetailsClient _client;
        public StoreController(IProductDetailsClient client)
        {
            _client = client;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _client.GetProduct(id);
            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("products/category/{id1}/{id2}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Product>>> GetAll(int id1, int id2)
        {
            var categoryIds = new int[] { id1, id2 };
            var products = await _client.GetCategoryProducts(categoryIds);
            if (products is null)
                return NotFound();

            return Ok(products);
        }
    }
}