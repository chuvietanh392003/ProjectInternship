using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjectInternship.ViewModels
{
    public class YoteiDenpyoTourokuVM
    {
        [Required]
        public long? Kaikeind { get; set; }

        public long? Denpyono { get; set; }

        public DateTime? Denpyodt { get; set; }

        [Required]
        public String? Suitokb { get; set; }

        [Required]
        public DateTime? Shiharaidt { get; set; }

        [Required]
        public DateTime? Uketukedt { get; set; }

        [Required]
        public String? BumoncdYkanr{  get; set; }
        public String? BumoncdName { get; set; }

        [Required]
        public String? Biko { get; set; }

        public Boolean isCreated { get; set; }

        public List<YoteiDenpyoTourokuVM>? Results { get; set; }
    }

}
