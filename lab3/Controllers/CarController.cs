using Microsoft.AspNetCore.Mvc;
using lab3_App.Models.CarModels;
using lab3_App.Models.ContactModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab3_App.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View(_carService.FindAll());
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

        [HttpGet]
        public IActionResult Create()
        {
            Car _model = new Car();
            _model.Manufacturers = CreateManufacturerItemList();
            return View(_model);
        }

        [HttpPost]
        public IActionResult Create(Car _model)
        {
            if (ModelState.IsValid)
            {
                _carService.Add(_model);
                return RedirectToAction("Index");
            }
            _model.Manufacturers = CreateManufacturerItemList();
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_carService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Car _model)
        {
            if (ModelState.IsValid)
            {
                _carService.Update(_model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_carService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Car _model)
        {
            _carService.DeleteById(_model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_carService.FindById(id));
        }
        [HttpPost]
        public IActionResult Details(Car _model)
        {
            return RedirectToAction("Index");
        }
    }
}
