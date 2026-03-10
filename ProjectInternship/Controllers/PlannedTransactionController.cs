/// <summary>
/// Controller responsible for handling Planned Transaction search.
/// It displays the search page and processes search requests.
/// Uses PlannedTransactionService to retrieve transaction data
/// based on the search conditions.
/// </summary>
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