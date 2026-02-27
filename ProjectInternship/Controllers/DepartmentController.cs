using Microsoft.AspNetCore.Mvc;
using ProjectInternship.Services;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(
            DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index(
            DepartmentVM model)
        {
            model ??= new DepartmentVM();

            model.Results =
                await _departmentService
                        .SearchAsync(model);

            return PartialView(model);
        }
    }
}