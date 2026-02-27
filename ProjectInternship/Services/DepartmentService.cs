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