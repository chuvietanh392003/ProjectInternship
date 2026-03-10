/**
 * ---------------------------------------------
 * Class Name : PlannedTransactionDetailVM
 * Description:
 *     ViewModel for Planned Transaction Detail
 *     (予定伝票明細) screen.
 *
 *     Holds detail information and performs
 *     validation for transaction detail input.
 *
 *     Includes custom validation for:
 *         - Required fields
 *         - Amount must be greater than 0
 *         - Denpyono and Gyono required in update mode
 * ---------------------------------------------
 */
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectInternship.ViewModels
{
    public class PlannedTransactionDetailVM :IValidatableObject
    {
        public decimal? Denpyono {  get; set; }
        public decimal? Gyono { get; set; }
        [Required(ErrorMessage = "年月日は必須です。")]
        public DateTime? Idodt { get; set; }
        [Required(ErrorMessage = "出発地は必須です")]
        public string? ShuppatsuPlc { get; set; }
        [Required(ErrorMessage = "目的地は必須です。")]
        public string? MokutekiPlc { get; set; }
        [Required(ErrorMessage = "経路は必須です。")]
        public string? Keiro { get; set; }
        [Required(ErrorMessage = "金額は必須です。")]
        public decimal? Kingaku { get; set; }
        public bool? IsCreated { get; set; } = false;
        public bool IsCheckedToDelete { get; set; } = false;

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
