using AppGr8.WebApiECommerce.Services;
using AppGr8.WebApiECommerce.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGr8.WebApiECommerce.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductService productsService;

        public ProductsController(ProductService productsService)
        {
            this.productsService = productsService;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IActionResult GetAllProducts()
        {
            var products = productsService.GetAll();
            return Ok(products);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (productsService.Contains(id))
            {
                var product = productsService.Get(id);
                return Ok(product);
            }
            else
                return NotFound($"Unable to find product with id {id}");
        }

        [HttpPost("Create")]
        public IActionResult Create(Product product)
        {
            var createdProduct = productsService.Create(product);

            return Ok(createdProduct);
        }

        [HttpPut("Update")]
        public IActionResult Update(Product product)
        {
            if (productsService.Contains(product.Id))
            {
                var updatedProduct = productsService.Update(product);
                return Ok(updatedProduct);
            }
            else
                return NotFound($"Unable to find product with id {product.Id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (productsService.Contains(id))
            {
                productsService.Delete(id);
                return NoContent();
            }
            else
                return NotFound($"Unable to find product with id {id}");
        }

    }
}
