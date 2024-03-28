using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quartica.Web.Service.Helpers;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [QuarticaAuthorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("fetchAllProductAsync")]
        public async Task<ActionResult<List<Product>>> GetAllProducts([FromQuery] string searchString = "")
        {
            try
            {
                var products = await productService.fetchAllProductAsync(searchString);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("fetchProductByProductAsync/{productId}")]
        public async Task<ActionResult<Product>> GetProductById(long productId)
        {
            try
            {
                var product = await productService.fetchProductByProductAsync(productId);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("fetchProductByProductAsync/{productName}")]
        public async Task<ActionResult<Product>> GetProductByName(string productName)
        {
            try
            {
                var product = await productService.fetchProductByProductAsync(productName);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("InsertOrUpdateProductAsync")]
        public async Task<ActionResult<bool>> InsertOrUpdateProduct(Product product)
        {
            try
            {
                var result = await productService.InsertOrUpdateProductAsync(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
