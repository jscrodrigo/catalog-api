using CatalogApi.Context;
using CatalogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Text;

namespace CatalogApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _context.Categories?
                .Take(10)
                .AsNoTracking()
                .ToList();

            if (null == categories || !categories.Any())
            {
                return NotFound("Categories not found!");
            }

            return Ok(categories);
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetCategoryWithProducts()
        {
            return _context.Categories
                .Include(p => p.Products)
                .Where(c => c.Id <= 5)
                .ToList();
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public ActionResult GetById(int id)
        {
            var category = _context.Categories?.FirstOrDefault(p => p.Id == id);

            if (null == category)
            {
                return NotFound($"Category {id} not found!");
            }

            return Ok(category);
        }

        [HttpPost]
        public ActionResult Include(Category category)
        {
            if (null == category)
            {
                return BadRequest("Body must be informed!");
            }

            _context.Categories?.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult(
                "GetCategoryById",
                new
                {
                    id = category.Id
                },
                category);
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest("The IDs must be the same!");
            }

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteById(int id)
        {
            var category = _context.Categories?.FirstOrDefault(p => p.Id == id);

            if (null == category)
            {
                return NotFound("The specified product was not found.");
            }

            _context.Categories?.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }
    }
}
