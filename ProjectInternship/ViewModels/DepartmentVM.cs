using ProjectInternship.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectInternship.ViewModels
{
    public class DepartmentVM
    {
        [Required]
        public string? BumonCode { get; set; }

        [Required]
        public string? BumonName { get; set; }

        public List<DepartmentVM>? Results { get; set; }
    }
}
