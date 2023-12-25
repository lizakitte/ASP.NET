using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactApiController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetContactsByName(string? q)
        {
            return Ok(
                q == null
                ?
                _context.Contacts
                .Select(m => new { name = m.Name, id = m.ContactId })
                .ToList()
                :
                _context.Contacts
                .Where(m => m.Name.ToUpper().StartsWith(q.ToUpper()))
                .Select(m => new { name = m.Name, id = m.ContactId })
                .ToList()
                );
        }

        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _context.Contacts.Find(id);
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
