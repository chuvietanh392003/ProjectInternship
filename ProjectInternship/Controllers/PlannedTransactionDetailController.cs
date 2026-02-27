using Microsoft.AspNetCore.Mvc;
using ProjectInternship.Data;
using ProjectInternship.Domain.Entities;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Controllers
{
    public class PlannedTransactionDetailController :  Controller
    {
        private readonly PlannedTransactionDbContext _context;

        public PlannedTransactionDetailController(PlannedTransactionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Index(PlannedTransactionDetailVM model)
        {

            return View(model);
        }
    }
}
