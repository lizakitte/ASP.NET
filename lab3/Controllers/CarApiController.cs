using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarApiController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetCarByName(string? q)
        {
            return Ok(
                q == null
                ?
                _context.Cars
                .Select(c => new { name = c.Model, id = c.Id })
                .ToList()
                :
                _context.Cars
                .Where(c => c.Model.ToUpper().StartsWith(q.ToUpper()))
                .Select(c => new { name = c.Model, id = c.Id })
                .ToList()
                );
        }

        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _context.Cars.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(contact);
            }
        }
    }
}
