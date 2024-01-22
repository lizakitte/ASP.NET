using Microsoft.AspNetCore.Mvc;
using lab3_App.Models.CarModels;
using lab3_App.Models.ContactModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace lab3_App.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index(string? search = null)
        {
            var cars = _carService.FindAll();
            if (search is null)
            {
                return View(cars);
            }
            var filteredCars = cars.Where(r => r.Model.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            return View(filteredCars);
        }

        public IActionResult PagedIndex([FromQuery] int page = 1, [FromQuery] int size = 1)
        {
            return View(_carService.FindPage(page, size));
        }

        private List<SelectListItem> CreateManufacturerItemList()
        {
            var gr = new SelectListGroup()
            {
                Name = "Producenty",
            };
            return _carService.FindAllManufacturers()
                            .Select(e => new SelectListItem()
                            {
                                Text = e.Name,
                                Value = e.ManufacturerId.ToString(),
                                Group = gr,
                            })
                            .Append(new SelectListItem()
                            {
                                Text = "Nie wiadomy producent",
                                Value = "",
                                Selected = true,
                                Group = new SelectListGroup()
                                {
                                    Name = "Nie wiadomo",
                                }
                            })
                            .ToList();
        }

        private List<SelectListItem> CreateContactItemList()
        {
            var gr = new SelectListGroup()
            {
                Name = "Kontakty",
            };
            return _carService.FindAllOwnerContacts()
                            .Select(e => new SelectListItem()
                            {
                                Text = e.Name,
                                Value = e.ContactId.ToString(),
                                Group = gr,
                            })
                            .Append(new SelectListItem()
                            {
                                Text = "Nie wiadomy właściciel",
                                Value = "",
                                Selected = true,
                                Group = new SelectListGroup()
                                {
                                    Name = "Nie wiadomo",
                                }
                            })
                            .ToList();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            Car _model = new Car();
            _model.Manufacturers = CreateManufacturerItemList();
            _model.Contacts = CreateContactItemList();
            return View(_model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Car _model)
        {
            if (ModelState.IsValid)
            {
                _carService.Add(_model);
                return RedirectToAction("Index");
            }
            _model.Manufacturers = CreateManufacturerItemList();
            _model.Contacts = CreateContactItemList();
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            return View(_carService.FindById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Car _model)
        {
            if (ModelState.IsValid)
            {
                if (_carService.FindById(_model.Id) == null)
                {
                    return NotFound();
                }
                _carService.Update(_model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var _model = _carService.FindById(id);
            if (_model is null)
            {
                return NotFound();
            }
            return View(_model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Car _model)
        {
            if (_carService.FindById(_model.Id) == null)
            {
                return NotFound();
            }
            _carService.DeleteById(_model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Details(int id)
        {
            var _model = _carService.FindById(id);
            if (_model is null)
            {
                return NotFound();
            }
            else
            {
                return View(_model);
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Details()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateApi()
        {
            return View(new Car());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateApi(Car _model)
        {
            if (ModelState.IsValid)
            {
                _carService.Add(_model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
