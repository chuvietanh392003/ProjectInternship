using Microsoft.AspNetCore.Mvc;
using ProjectInternship.Models;
using System.Diagnostics;

namespace ProjectInternship.Controllers
{
    public class YoteiDenpyoTourokuController : Controller

    {
        [HttpPost]
        [HttpGet]
        public IActionResult Index(YoteiDenpyoTourokuVM model, string actionType)
        {
            //model.isCreated = true;
            switch (actionType)
            {
                case "register":
                    model.Denpyono = 10012120;
                    model.Denpyodt = DateTime.Now;

                    break;

                case "delete":
                    
                    break;

                case "exit":
                    return RedirectToAction("Index", "EsYdenpyo");
            }

            return View(model);
        }
    }
}
