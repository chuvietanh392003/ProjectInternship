using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInternship.Models;
using ProjectInternship.Data;
using System.Diagnostics;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Controllers
{
    public class YoteiDenpyoTourokuController : Controller

    {
        private readonly YdenpyoContext _context;
        public YoteiDenpyoTourokuController(YdenpyoContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View(new YoteiDenpyoTourokuVM());
        //}

        [HttpGet]
        [HttpPost]
        public IActionResult Index(YoteiDenpyoTourokuVM model, string actionType)
        {
            //var query = _context.EsYdenpyos.Include(x => x.Bumon).AsQueryable();
            var maxNo = _context.EsYdenpyos.Select(x => (int?)x.Denpyono).Max() ?? 0;
            switch (actionType)
            {
                case "register":
                    if (!ModelState.IsValid)
                    {
                        return View(model);
                    }
                    var newItem = new EsYdenpyo
                    {
                        Denpyono = model.Denpyono,
                        Kaikeind = model.Kaikeind,
                        Denpyodt = DateTime.Now,
                        Uketukedt = model.Uketukedt,
                        Shiharaidt = model.Shiharaidt,
                        BumoncdYkanr = model.BumoncdYkanr,
                        Suitokb = model.Suitokb,
                        Biko = model.Biko,
                        
                        InsertDate = DateTime.Now,
                        InsertOpeId = "SYSTEM",
                        InsertPgmId = "YoteiDenpyoTouroku"
                    };

                    if (newItem.Denpyono == null)
                    {
                        newItem.Denpyono = maxNo + 1;
                    }

                    _context.EsYdenpyos.Add(newItem);
                    _context.SaveChanges();
                    TempData["Success"] = "Registration successful!";
                    return RedirectToAction("Index");

                case "delete":
                    var DeleteItem = _context.EsYdenpyos.Where(e => e.Denpyono == model.Denpyono).FirstOrDefault();
                    if(DeleteItem != null)
                    {
                        _context.EsYdenpyos.Remove(DeleteItem);
                        _context.SaveChanges();
                        TempData["DeleteSuccessful"] = "Delete successful!";
                        return RedirectToAction("Index");
                    }
                    break;

                case "exit":
                    return RedirectToAction("Index", "EsYdenpyo");
            }

            return View(model);
        }
    }
}
