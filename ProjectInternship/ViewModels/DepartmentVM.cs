/**
 * -------------------------------------------------------
 * Class Name  : DepartmentVM
 * Description :
 *     ViewModel used for the Department search and 
 *     selection screen (部門一覧).
 *
 *     This model is responsible for:
 *         - Holding search conditions for department code
 *           and department name.
 *         - Storing the list of department search results.
 *
 * Properties :
 *     BumonCode :
 *         Department code used as search condition.
 *
 *     BumonName :
 *         Department name used as search condition.
 *
 *     Results :
 *         List of departments returned from search result.
 *
 * Used In :
 *     - DepartmentController
 *     - Department selection modal view
 * -------------------------------------------------------
 */
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
