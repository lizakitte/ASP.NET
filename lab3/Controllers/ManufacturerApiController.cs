using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Controllers
{
    [Route("api/manufacturers")]
    [ApiController]
    public class ManufacturerApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ManufacturerApiController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetManufacturersByName(string? q)
        {
            return Ok(
                q == null
                ?
                _context.Manufacturers
                .Select(m => new { name = m.Name, id = m.ManufacturerId })
                .ToList()
                :
                _context.Manufacturers
                .Where(m => m.Name.ToUpper().StartsWith(q.ToUpper()))
                .Select(m => new { name = m.Name, id = m.ManufacturerId })
                .ToList()
                );
        }

        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var manufacturer = _context.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(manufacturer);
            }
        }
    }
}
