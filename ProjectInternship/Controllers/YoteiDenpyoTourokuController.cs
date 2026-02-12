using Microsoft.AspNetCore.Mvc;
using ProjectInternship.Models;
using System.Diagnostics;

namespace ProjectInternship.Controllers
{
    public class YoteiDenpyoTourokuController : Controller

    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string actionType)
        {
            switch (actionType)
            {
                case "register":
                    // xử lý đăng ký
                    break;

                case "delete":
                    // xử lý xóa
                    break;

                case "exit":
                    return RedirectToAction("Index");
            }

            return View();
        }

    }
}
