using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Controllers
{
    // localhost:5000/api/products
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private static readonly string[] Products =
        {
            "samsung s6","samsung s7","samsung s8"
        };

        // localhost:5000/api/products
        [HttpGet]
        public string[] GetProducts()
        {
            return Products;
        } 

        // localhost:5000/api/products/2
        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            if(Products.Length-1<id)
                return "";
            return Products[id];
        }


    }
}