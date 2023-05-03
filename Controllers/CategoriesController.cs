using CatalogApi.Context;
using CatalogApi.Models;
using Microsoft.AspNetCore.Mvc;
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
            var categories = _context.Categories.ToList();

            if (null == categories || !categories.Any())
            {
                return NotFound("Categories not found!");
            }

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public ActionResult GetById(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.Id == id);

            if (null == category)
            {
                return NotFound($"Category {id} not found!");
            }

            return Ok(category);
        }
    }
}
