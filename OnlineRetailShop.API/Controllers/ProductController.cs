using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailShop.Repository.Entities;
using OnlineRetailShop.Services.Interface;
using System;
using System.Collections.Generic;

namespace OnlineRetailShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            try
            {
                _productService.AddProduct(product);
                return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Product/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] Product product)
        {
            try
            {
                if (id != product.ProductId)
                    return BadRequest("Product ID mismatch");

                _productService.UpdateProduct(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            try
            {
                var existingProduct = _productService.GetProductById(id);
                if (existingProduct == null)
                    return NotFound();

                _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
