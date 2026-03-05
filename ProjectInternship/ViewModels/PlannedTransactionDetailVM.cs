using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectInternship.ViewModels
{
    public class PlannedTransactionDetailVM :IValidatableObject
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
        public bool? IsCreated { get; set; } = false;
        public bool IsCheckedToDelete { get; set; } = false;

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
        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            // Denpyono & Gyono bắt buộc khi update
            if (IsCreated ?? false)
            {
                if (!Denpyono.HasValue)
                {
                    yield return new ValidationResult(
                        "伝票番号は必須です。",
                        new[] { nameof(Denpyono) });
                }

                if (!Gyono.HasValue)
                {
                    yield return new ValidationResult(
                        "行番号は必須です。",
                        new[] { nameof(Gyono) });
                }
            }

            // Kingaku phải > 0 
            if (Kingaku.HasValue && Kingaku <= 0)
            {
                yield return new ValidationResult(
                    "金額は0より大きくなければなりません。",
                    new[] { nameof(Kingaku) });
            }
        }
    }
}
