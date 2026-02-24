using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInternship.Data;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Controllers
{
    public class BumonController : Controller

    {
        private readonly YdenpyoContext _context;
        public BumonController(YdenpyoContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(BumonVM model)
        {
            var query = _context.Bumons.AsQueryable();
            if (!String.IsNullOrEmpty(model.BumonCode))
            {
                query = query.Where(x => x.BumonCD.Equals(model.BumonCode));        
            }
            if (!String.IsNullOrEmpty(model.BumonName))
            {
                query = query.Where(x => x.BumonName.Contains(model.BumonName));
            }
            model.Results = await query
            .Select(x => new BumonVM
            {
                BumonCode = x.BumonCD,
                BumonName = x.BumonName
            })
            .ToListAsync();
            return PartialView("Index",model);
        }
    }
}