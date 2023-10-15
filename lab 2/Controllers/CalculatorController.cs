using lab_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_2.Controllers;

public class CalculatorController : Controller
{
    public enum Operators
    {
        ADD, SUB, MUL, DIV
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Form()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Result(Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
}