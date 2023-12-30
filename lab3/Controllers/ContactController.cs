using Microsoft.AspNetCore.Mvc;
using lab3_App.Models.ContactModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace lab3_App.Controllers
{
//    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        public IActionResult PagedIndex(int page = 1, int size = 3)
        {
            if (size < 1)
            {
                return BadRequest();
            }
            return View(_contactService.FindPage(page, size));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            Contact model = new Contact();
            model.OrganizationList = CreateOrganizationItemList();
            return View(model);
        }

        private List<SelectListItem> CreateOrganizationItemList()
        {
            var gr = new SelectListGroup()
            {
                Name = "Organizacje",
            };
            return _contactService.FindAllOrganizations()
                            .Select(e => new SelectListItem()
                            {
                                Text = e.Name,
                                Value = e.OrganizationId.ToString(),
                                Group = gr,
                            })
                            .Append(new SelectListItem()
                            {
                                Text = "Brak organizacji",
                                Value = "",
                                Selected = true,
                                Group = new SelectListGroup()
                                {
                                    Name = "Brak",
                                }
                            })
                            .ToList();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Contact model) 
        { 
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            model.OrganizationList = CreateOrganizationItemList();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Contact model)
        {
            _contactService.DeleteById(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _contactService.FindById(id);
            if(model is null)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
            
        }
        [HttpPost]
        public IActionResult Details(Contact model)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateApi()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateApi(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
