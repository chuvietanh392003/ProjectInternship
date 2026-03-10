/// <summary>
/// Controller responsible for handling Department search requests.
/// It receives search conditions from DepartmentVM and calls
/// DepartmentService to retrieve matching department data.
/// The result is returned as a PartialView.
/// </summary>
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