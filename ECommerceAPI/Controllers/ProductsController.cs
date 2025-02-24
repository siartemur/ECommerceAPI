using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Services.Interfaces;
using ECommerceAPI.Entities;
using FluentValidation;
using ECommerceAPI.Features.Products.Commands.CreateProduct;
using ECommerceAPI.Features.Products.Commands.UpdateProduct;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Yeni ürün oluşturur.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] CreateProductCommandRequest command)
        {
            try
            {
                var product = await _productService.CreateProductAsync(command);
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] bool includeDeleted = false)
        {
            return Ok(await _productService.GetProductsAsync(includeDeleted));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound($"Ürün {id} bulunamadı.");
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest command)
        {
            try
            {
                var updatedProduct = await _productService.UpdateProductAsync(command);
                return Ok(updatedProduct);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var isDeleted = await _productService.DeleteProductAsync(id);
            if (!isDeleted)
                return NotFound("Ürün bulunamadı veya zaten silinmiş.");

            return Ok("Ürün başarıyla silindi.");
        }
    }
}
