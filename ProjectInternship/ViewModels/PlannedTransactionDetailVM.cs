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

        [StringLength(30)]
        public string? InsertOpeId { get; set; }

        [StringLength(20)]
        public string? InsertPgmId { get; set; }

        [StringLength(20)]
        public string? InsertPgmPrm { get; set; }

        public DateTime? InsertDate { get; set; }

        [StringLength(30)]
        public string? UpdateOpeId { get; set; }

        [StringLength(20)]
        public string? UpdatePgmId { get; set; }

        [StringLength(20)]
        public string? UpdatePgmPrm { get; set; }

        public DateTime? UpdateDate { get; set; }

    }
}
