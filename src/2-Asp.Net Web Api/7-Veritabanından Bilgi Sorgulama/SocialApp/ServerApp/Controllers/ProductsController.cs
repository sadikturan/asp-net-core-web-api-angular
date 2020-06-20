using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    // localhost:5000/api/products
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
        public async Task<ActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        } 

        // localhost:5000/api/products/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
           var p = await _context.Products.FirstOrDefaultAsync(i=>i.ProductId==id);
           if(p==null)
           {
               return NotFound();
           }
           
           return Ok(p);
        }

        // [HttpPost]
        // public IActionResult CreateProduct(Product p)
        // {
        //     _products.Add(p);

        //     foreach (var item in _products)
        //     {
        //         Console.WriteLine(item.Name);
        //     }

        //     return Ok(p);
        // }


    }
}