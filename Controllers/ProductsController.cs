using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CatalogApi.Context;
using CatalogApi.Models;

namespace CatalogApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _context.Products.ToList();
            if (null == products || !products.Any())
            {
                return NotFound("Products not found.");
            }
            return products;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if(null == product)
            {
                return NotFound("Product not found!");
            }

            return product;
        }
    }
}
