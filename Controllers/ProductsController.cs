using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CatalogApi.Context;
using CatalogApi.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{id:int}", Name="GetProduct")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if(null == product)
            {
                return NotFound("Product not found!");
            }

            return product;
        }

        [HttpPost]
        public ActionResult Include(Product product)
        {
            if (null == product)
            {
                return BadRequest("Body must be informed!");
            }

            _context.Products?.Add(product);
            _context.SaveChanges();

            return new CreatedAtRouteResult(
                "GetProduct",
                new
                {
                    id = product.Id
                },
                product);
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("The IDs must be the same!");
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (null == product)
            {
                return NotFound("The specified product was not found.");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }
    }
}
