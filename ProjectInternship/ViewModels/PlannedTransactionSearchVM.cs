using ProjectInternship.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectInternship.ViewModels
{
    public class PlannedTransactionSearchVM : IValidatableObject
    {
        public long? Kaikeind { get; set; }
        public long? DenpyonoFrom { get; set; }
        public long? DenpyonoTo { get; set; }

        public DateTime? DenpyodtFrom { get; set; }
        public DateTime? DenpyodtTo { get; set; }

        public DateTime? UketukedtFrom { get; set; }
        public DateTime? UketukedtTo { get; set; }

        public String? Suitofuri { get; set; }
        public String? Genkin { get; set; }
       
        public decimal? TotalKingaku { get; set; }
        public List<PlannedTransaction>? Results { get; set; }

        public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
        {
            // 伝票番号
            if (DenpyonoFrom.HasValue &&
                DenpyonoTo.HasValue &&
                DenpyonoFrom > DenpyonoTo)
            {
                    yield return new ValidationResult(
                    "伝票番号 From は To 以下で入力してください。",
                    new[] { nameof(DenpyonoFrom), nameof(DenpyonoTo) });
            }

            // 伝票日付
            if (DenpyodtFrom.HasValue &&
                DenpyodtTo.HasValue &&
                DenpyodtFrom > DenpyodtTo)
            {
                yield return new ValidationResult(
                    "伝票日付 From は To 以下で入力してください。",
                    new[] { nameof(DenpyodtFrom), nameof(DenpyodtTo) });
            }

            // 申請日
            if (UketukedtFrom.HasValue &&
                UketukedtTo.HasValue &&
                UketukedtFrom > UketukedtTo)
            {
                yield return new ValidationResult(
                    "申請日 From は To 以下で入力してください。",
                    new[] { nameof(UketukedtFrom), nameof(UketukedtTo) });
            }
        }
    }
}

