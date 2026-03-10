/// <summary>
/// Controller responsible for handling Planned Transaction Detail operations.
/// It manages the display and submission of detail information
/// such as travel date, departure, destination, route, and amount.
/// Uses PlannedTransactionDetailVM to pass data between the view and controller.
/// </summary>
using Microsoft.AspNetCore.Mvc;
using ProjectInternship.Data;
using ProjectInternship.Domain.Entities;
using ProjectInternship.Services;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Controllers
{
    public class PlannedTransactionDetailController :  Controller
    {
        private readonly PlannedTransactionDetailService _service;

        public PlannedTransactionDetailController(PlannedTransactionDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index(decimal? denpyono, decimal? gyono, DateTime?  idodt, string? shuppatsuPlc, string?  mokutekiPlc, string?  keiro, decimal? kingaku, bool  isCheckedToDelete, bool? isCreated)
        {
            var model = new PlannedTransactionDetailVM
            {
                Denpyono = denpyono,
                Gyono = gyono,
                Idodt = idodt,
                ShuppatsuPlc = shuppatsuPlc,
                MokutekiPlc = mokutekiPlc,
                Keiro = keiro,
                Kingaku = kingaku,
                IsCheckedToDelete = isCheckedToDelete,
                IsCreated = isCreated
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(PlannedTransactionDetailVM model)
        {
            return View(model);
        }
    }
}
