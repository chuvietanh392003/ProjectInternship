/// <summary>
/// Controller that handles basic application pages.
/// Provides actions for the Home page, Privacy page,
/// and Error handling.
/// Returns corresponding views for each request.
/// </summary>
using Microsoft.AspNetCore.Mvc;
using ProjectInternship.Domain.Entities; 
using System.Diagnostics;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
