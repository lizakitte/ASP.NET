using lab3_App.Models.CarModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab3_App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_manufacturerService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Manufacturer _model = new Manufacturer();
            return View(_model);
        }

        [HttpPost]
        public IActionResult Create(Manufacturer _model)
        {
            if (ModelState.IsValid)
            {
                _manufacturerService.Add(_model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_manufacturerService.FindById(id));
        }

        [HttpPost]
        public IActionResult Edit(Manufacturer _model)
        {
            if (ModelState.IsValid)
            {
                if (_manufacturerService.FindById(_model.ManufacturerId) == null)
                {
                    return NotFound();
                }
                _manufacturerService.Update(_model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var _model = _manufacturerService.FindById(id);
            if (_model is null)
            {
                return NotFound();
            }
            return View(_model);
        }

        [HttpPost]
        public IActionResult Delete(Manufacturer _model)
        {
            if (_manufacturerService.FindById(_model.ManufacturerId) == null)
            {
                return NotFound();
            }
            _manufacturerService.DeleteById(_model.ManufacturerId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var _model = _manufacturerService.FindById(id);
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
        [AllowAnonymous]
        public IActionResult Details()
        {
            return RedirectToAction("Index");
        }
    }
}
