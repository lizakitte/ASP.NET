using lab_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Result(Birth model)
        {
            if (!model.IsValid())
                return View("ArgumentError");
            return View(model);
        }

        public IActionResult ArgumentError()
        {
            return View();
        }
    }
}
