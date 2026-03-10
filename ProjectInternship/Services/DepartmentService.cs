/**
 * ---------------------------------------------
 * Class Name : DepartmentService
 * Description:
 *     Service class for handling department
 *     related operations.
 *
 *     Provides methods to:
 *         - Retrieve department name by code.
 *         - Search departments by code or name.
 *
 *     Uses Entity Framework Core to access
 *     the Departments table.
 * ---------------------------------------------
 */
using Microsoft.EntityFrameworkCore;
using ProjectInternship.Data;
using ProjectInternship.ViewModels;

namespace ProjectInternship.Services
{
    public class DepartmentService
    {
        private readonly PlannedTransactionDbContext _context;

        public DepartmentService(PlannedTransactionDbContext context)
        {
            _context = context;
        }


        public async Task<string?> GetDepartmentNameFromCode(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;
               return await _context.Departments
                .AsNoTracking()
                .Where(x => x.BumonCD == code)
                .Select(x => x.BumonName)
                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// SearchAsync22222
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<List<DepartmentVM>> SearchAsync(DepartmentVM model)
        {
            var query = _context.Departments
                                .AsNoTracking() 
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(model?.BumonCode))
            {
                query = query.Where(x => x.BumonCD == model.BumonCode);
            }

            if (!string.IsNullOrWhiteSpace(model?.BumonName))
            {
                query = query.Where(x => x.BumonName.Contains(model.BumonName));
            }

            return await query
                .Select(x => new DepartmentVM
                {
                    BumonCode = x.BumonCD,
                    BumonName = x.BumonName
                })
                .ToListAsync();
        }
    }
}