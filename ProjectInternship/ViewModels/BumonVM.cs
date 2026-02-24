using ProjectInternship.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectInternship.ViewModels
{
    public class BumonVM
    {
        [Required]
        public string? BumonCode { get; set; }

        [Required]
        public string? BumonName { get; set; }

        public List<BumonVM>? Results { get; set; }
    }
}
