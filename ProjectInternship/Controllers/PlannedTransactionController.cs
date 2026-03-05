using Microsoft.AspNetCore.Mvc;
using ProjectInternship.Services;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Controllers;

public class PlannedTransactionController : Controller
{
    private readonly PlannedTransactionService _service;

    public PlannedTransactionController(
        PlannedTransactionService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new PlannedTransactionSearchVM());
    }

    [HttpPost]
    public async Task<IActionResult> Index(
        PlannedTransactionSearchVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var result = await _service.SearchAsync(model);
        return View(model);
    }
}