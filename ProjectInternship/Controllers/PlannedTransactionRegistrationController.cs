using Microsoft.AspNetCore.Mvc;
using ProjectInternship.Services;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Controllers;

public class PlannedTransactionRegistrationController
    : Controller
{
    private readonly
        PlannedTransactionRegistrationService
        _service;

    public PlannedTransactionRegistrationController(
        PlannedTransactionRegistrationService service)
    {
        _service = service;
    }

    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> Index(
        PlannedTransactionRegistration model,
        string actionType)
    {
        switch (actionType)
        {
            case "register":

                if (!ModelState.IsValid)
                    return View(model);

                var id =
                    await _service.RegisterAsync(model);

                TempData["Success"] =
                    $"Registration successful RecordId = {id}";

                return RedirectToAction("Index");


            case "delete":

                await _service
                    .DeleteAsync(model.Denpyono);

                TempData["DeleteSuccessful"] =
                    "Delete successful!";

                return RedirectToAction("Index");


            case "exit":

                return RedirectToAction(
                    "Index",
                    "PlannedTransaction");
        }

        await _service.LoadDetails(model);

        return View(model);
    }
}