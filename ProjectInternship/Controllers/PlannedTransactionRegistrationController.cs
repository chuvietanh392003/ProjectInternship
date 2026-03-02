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
        PlannedTransactionRegistrationVM model,
        string actionType)
    {
        if(model.Results != null)
        Console.WriteLine(model.Results.Count);

        switch (actionType)
        {
            case "register":
                if (!ModelState.IsValid)
                    return View(model);

                var id =
                    await _service.RegisterAsync(model);
                if (await _service.IsExist(model.Denpyono))
                {
                    TempData["Success"] =
                        $"Update successful RecordId = {id}";

                }
                else
                {
                    TempData["Success"] =
                        $"Registration successful RecordId = {id}";
                }


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

        Console.WriteLine(model.Results?.Count);
        model.NextGyono = await _service.GetNextGyonoAsync(model.Denpyono) ;
        return View(model);
    }
}

