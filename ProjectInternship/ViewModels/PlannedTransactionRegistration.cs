using Microsoft.AspNetCore.Mvc;
using ProjectInternship.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectInternship.ViewModels
{
    public class PlannedTransactionRegistration
    {
        [Required]
        public decimal Kaikeind { get; set; }

        public decimal? Denpyono { get; set; }

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

        public DateTime UketukeDT { get; set; }

        public String? ShuppatsuPLC{ get; set;}

        public String? MokutekiPLC { get; set; }

        public  String? Keiro { get; set; }

        public long? Kingaku { get; set; }

        public decimal? TotalKingaku { get; set; }

        public List<PlannedTransactionDetail>? Results { get; set; }
    }

}
