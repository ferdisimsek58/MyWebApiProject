using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(){
           var products = await _context.Products.ToListAsync();
           return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id){
           var products = await _context.Products.FindAsync(id);
           if(products == null){
            return NotFound();
           }
           return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> GetProducts([FromBody] Product newProduct){
           _context.Products.Add(newProduct);
           await _context.SaveChangesAsync();
           return CreatedAtAction(nameof(GetProduct), new {id = newProduct.Id}, newProduct);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> GetProducts(int id,[FromBody] Product updateProduct){
          var product = await _context.Products.FindAsync(id);
          if(product == null){
            return NotFound();
          }
          product.ProductName = updateProduct.ProductName;
          product.Price = updateProduct.Price;
          product.IsActive = updateProduct.IsActive;
          await _context.SaveChangesAsync();
          return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> GetProducts(int id){
          var product = await _context.Products.FindAsync(id);
          if(product == null){
            return NotFound();
          }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
         
        }
    }
}