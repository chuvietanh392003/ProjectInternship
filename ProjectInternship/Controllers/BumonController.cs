using Microsoft.AspNetCore.Mvc;

namespace ProjectInternship.Controllers
{
    public class BumonController : Controller

    {
        public IActionResult Index()
        {
            return View();
        }
    }
}