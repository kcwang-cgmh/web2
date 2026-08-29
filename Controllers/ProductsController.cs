using Microsoft.AspNetCore.Mvc;
using web2.Models;

namespace web2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPut]
        public ActionResult<Product> Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}