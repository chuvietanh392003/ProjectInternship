using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInternship.Services;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Controllers;

public class PlannedTransactionRegistrationController
    : Controller
{
    private readonly PlannedTransactionRegistrationService _service;
    private readonly DepartmentService _departmentService;

    public PlannedTransactionRegistrationController(
        PlannedTransactionRegistrationService service, DepartmentService departmentService)
    {
        _service = service;
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(decimal? Denpyono, bool?IsCreated)  {
        if (Denpyono == null)
        {
            var newRegistrationModal = await _service.CreateNewAsync();
            return View(newRegistrationModal);
        }
        var registrationModal = await _service.GetHeaderDataAsync(Denpyono, IsCreated);
        await _service.LoadDetails(registrationModal);
        return View(registrationModal);
    }

    [HttpPost]
    public async Task<IActionResult> Index(
    PlannedTransactionRegistrationVM model,
    string actionType)
    {
        switch (actionType)
        {
            case "register":

                if (!ModelState.IsValid)
                    return View(model);

                var existed = await _service.IsExist(model.Denpyono);

                var result = await _service.RegisterAsync(model);

                if (existed)
                    TempData["Success"] = $"レコードID = {result.id}の更新が成功しました。";
                else
                    TempData["Success"] = $"レコードID = {result.id}の登録が成功しました。";

                return RedirectToAction("Index");


            case "delete":

                await _service.DeleteAsync(model.Denpyono);

                TempData["Success"] =
                    $"レコードID = {model.Denpyono}の削除が成功しました。";

                return RedirectToAction("Index");


            case "exit":

                return RedirectToAction(
                    "Index",
                    "PlannedTransaction");

        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartmentName(string? code)
    {
        if (string.IsNullOrWhiteSpace(code))
            return Json(null);

        var name = await _departmentService.GetDepartmentNameFromCode(code);

        return Json(name);
    }
}

