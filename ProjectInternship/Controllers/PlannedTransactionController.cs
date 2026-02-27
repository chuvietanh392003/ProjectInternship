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

    public async Task<IActionResult> Index(
        PlannedTransactionSearchVM model)
    {
        var result = await _service.SearchAsync(model);
        if (result.Success == true)
        {
            return View(result.Data);
        }
        else
        {
            return View(result.ErrorMessage);
        }
    }
}