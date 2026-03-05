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
        public async Task<IActionResult> Index(decimal? Denpyono, decimal? Gyono, DateTime?  Idodt, string? ShuppatsuPlc, string?  MokutekiPlc, string?  Keiro, decimal? Kingaku, bool  isCheckedToDelete, bool? IsCreated)
        {
            var model = new PlannedTransactionDetailVM
            {
                Denpyono = Denpyono,
                Gyono = Gyono,
                Idodt = Idodt,
                ShuppatsuPlc = ShuppatsuPlc,
                MokutekiPlc = MokutekiPlc,
                Keiro = Keiro,
                Kingaku = Kingaku,
                IsCheckedToDelete = isCheckedToDelete,
                IsCreated = IsCreated
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
