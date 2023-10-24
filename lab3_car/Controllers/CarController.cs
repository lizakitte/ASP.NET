using Microsoft.AspNetCore.Mvc;
using lab3_car.Models;

namespace lab3_car.Controllers
{
    public class CarController : Controller
    {
        static readonly Dictionary<int, Car> _cars = new Dictionary<int, Car>();
        static int id = 1;
        public IActionResult Index()
        {
            return View(_cars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car _model)
        {
            if (ModelState.IsValid)
            {
                _model.Id = id++;
                _cars[_model.Id] = _model;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_cars[id]);
        }

        [HttpPost]
        public IActionResult Update(Car _model)
        {
            if (ModelState.IsValid)
            {
                _cars[_model.Id] = _model;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_cars[id]);
        }

        [HttpPost]
        public IActionResult Delete(Car _model)
        {
            _cars.Remove(_model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_cars[id]);
        }
        [HttpPost]
        public IActionResult Details(Car _model)
        {
            return RedirectToAction("Index");
        }
    }
}
