/**
 * ---------------------------------------------
 * Class Name : PlannedTransactionRegistrationVM
 * Description:
 *     ViewModel for Planned Transaction
 *     Registration screen (予定伝票入力).
 *
 *     Holds header information of a planned
 *     transaction and the list of detail records.
 *
 *     Includes validation for required fields
 *     such as fiscal year, payment method,
 *     department, dates, and business purpose.
 * ---------------------------------------------
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using ProjectInternship.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectInternship.ViewModels
{
    public class PlannedTransactionRegistrationVM
    {
        [Required(ErrorMessage = "年度は必須です。")]
        public decimal? Kaikeind { get; set; }

        public decimal? Denpyono { get; set; }

        public decimal? NextGyono {  get; set;}

        public DateTime? Denpyodt { get; set; }

        [Required(ErrorMessage = "出納方法は必須です。")]
        public String? Suitokb { get; set; }

        [Required(ErrorMessage = "支払予定日は必須です。")]
        public DateTime? Shiharaidt { get; set; }

        [Required(ErrorMessage = "申請日は必須です。")]
        public DateTime? Uketukedt { get; set; }

        [Required(ErrorMessage = "起票部門は必須です。")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "部門コードは数字のみ入力してください。")]
        public String? BumoncdYkanr{  get; set; }
        public String? BumoncdName { get; set; }

        [Required(ErrorMessage = "出張目的は必須です。")]
        public String? Biko { get; set; }

        public Boolean IsCreated { get; set; }

        public decimal? TotalKingaku { get; set; }

        public List<PlannedTransactionDetailVM>? Results { get; set; }
    }
}
