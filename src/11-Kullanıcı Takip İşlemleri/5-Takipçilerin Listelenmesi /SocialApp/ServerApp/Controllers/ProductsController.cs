using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.DTO;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    // localhost:5000/api/products
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly SocialContext _context;
        public ProductsController(SocialContext context)
        {
           _context = context;
        }

        // localhost:5000/api/products
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _context
            .Products
            .Select(p=> ProductToDTO(p))
            .ToListAsync();
            return Ok(products);
        } 

        // localhost:5000/api/products/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
           var p = await _context.Products.FindAsync(id);
           if(p==null)
           {
               return NotFound();
           }
           
           return Ok(ProductToDTO(p));
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new {id=entity.ProductId},ProductToDTO(entity));
        }

        // localhost:5000/api/products/2
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product entity)
        {
            if (id!=entity.ProductId)
            {
                return BadRequest();
            }

            var product = await _context.Products.FindAsync(id);

            if(product==null)
            {
                return NotFound();
            }

            product.Name = entity.Name;
            product.Price = entity.Price;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

        // localhost:5000/api/products/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if(product==null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private static ProductDTO ProductToDTO(Product p)
        {
            return new ProductDTO()
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                IsActive = p.IsActive
            };
        }


    }
}