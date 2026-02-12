using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectInternship.Data;
using ProjectInternship.Models;

namespace ProjectInternship.Controllers
{
    public class EsYdenpyoController : Controller
    {
        private readonly YdenpyoContext _context;
        public EsYdenpyoController(YdenpyoContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index( EsYdenpyoSearchVM model)
        {
            var query = _context.EsYdenpyos.Include(x => x.Bumon).AsQueryable();
            if (model.Kaikeind.HasValue)
            {
                query = query.Where(x => x.Kaikeind == model.Kaikeind);

            }
            if (model.DenpyonoFrom.HasValue&& model.DenpyonoTo.HasValue)
            {
                query = query.Where(x => x.Denpyono >= model.DenpyonoFrom && x.Denpyono <= model.DenpyonoTo);

            }
            if (model.UketukedtFrom.HasValue && model.UketukedtTo.HasValue)
            {
                query = query.Where(x => x.Uketukedt >= model.UketukedtFrom && x.Uketukedt <= model.UketukedtTo);

            }
            if (model.DenpyodtFrom.HasValue && model.DenpyodtTo.HasValue)
            {
                query = query.Where(x => x.Denpyodt >= model.DenpyodtFrom && x.Denpyodt <= model.DenpyodtTo);

            }
            if (!String.IsNullOrEmpty(model.Suitofuri))
            {
                query = query.Where(x => x.Suitokb ==  "振込");

            }

            if(!String.IsNullOrEmpty(model.Genkin))
            {
                query = query.Where(x => x.Suitokb == "現金");

            }
            model.Results = await query.ToListAsync();
            model.TotalKingaku = model.Results.Where(x => x.Kingaku.HasValue).Sum(x => x.Kingaku.Value);
            return View(model);
        }
        public IActionResult InsertTest()
        {
            var entity = new EsYdenpyo
            {
                Denpyono = 9112,   // PK phải không trùng
                Kaikeind = 20224,

                Denpyodt = new DateTime(2024, 1, 1),
                Uketukedt = new DateTime(2024, 1, 2),
                Shiharaidt = new DateTime(2024, 1, 5),

                Kingaku = 123425.67m,
                Biko = "TEST INSERT FROM EF",

                InsertOpeId = "TEST",
                InsertPgmId = "EF",
                InsertPgmPrm = "MANUAL",
                InsertDate = DateTime.Now
            };

            _context.EsYdenpyos.Add(entity);
            _context.SaveChanges();

            return Content("INSERT OK");
        }



    }
}
