using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationApiController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetOrganizationsByName(string? q)
        {
            return Ok(
                q == null 
                ?
                _context.Organisations
                .Select(o => new { name = o.Name, id = o.OrganizationId })
                .ToList()
                :
                _context.Organisations
                .Where(o => o.Name.ToUpper().StartsWith(q.ToUpper()))
                .Select(o => new { name = o.Name, id = o.OrganizationId })
                .ToList()
                );
        }

        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var organization = _context.Organisations.Find(id);
            if(organization == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(organization);
            }
        }
    }
}
