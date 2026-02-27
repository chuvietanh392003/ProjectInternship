using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectInternship.ViewModels
{
    public class PlannedTransactionDetailVM
    {
        public decimal? Denpyono {  get; set; }
        public decimal? Gyono { get; set; }
        [Required]
        public DateTime? Idodt { get; set; }
        [Required]
        public string? ShuppatsuPlc { get; set; }
        [Required]
        public string? MokutekiPlc { get; set; }
        [Required]
        public string? Keiro { get; set; }
        [Required]
        public decimal? Kingaku { get; set; }
        public bool isCreated { get; set; } = false;
        public bool isCheckedToDelete { get; set; } = false;

    }
}
