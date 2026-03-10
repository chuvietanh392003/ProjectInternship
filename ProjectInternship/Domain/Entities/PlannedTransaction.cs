/*
-----------------------------------------------------------------------
File Name   : PlannedTransaction.cs
Layer       : Domain / Entity
Table Name  : SYSTEM.ES_YDENPYO

Description :
    Entity class representing planned transaction header data.

    This table stores basic information of a planned transaction,
    including fiscal year, transaction dates, department, payment
    method, and total amount.

Primary Key :
        - Denpyono : Transaction number

Related Entities :
        - Department (via BumoncdYkanr)

Main Columns :
        - Kaikeind      : Fiscal year
        - Uketukedt     : Application date
        - Denpyodt      : Transaction date
        - BumoncdYkanr  : Department code
        - Suitokb       : Payment method
        - Shiharaidt    : Planned payment date
        - Kingaku       : Total amount
-----------------------------------------------------------------------
*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectInternship.Domain.Entities
{
    [Table("ES_YDENPYO", Schema = "SYSTEM")]
    public class PlannedTransaction
    {
        [Key]
        [Column("DENPYONO")]
        public decimal? Denpyono { get; set; }

        [Column("KAIKEIND")]
        public decimal? Kaikeind { get; set; }

        [Column("UKETUKEDT")]
        public DateTime? Uketukedt { get; set; }

        [Column("DENPYODT")]
        public DateTime? Denpyodt { get; set; }

        [Column("BUMONCD_YKANR")]
        public string? BumoncdYkanr { get; set; }

        [ForeignKey("BumoncdYkanr")]
        public Department? Bumon { get; set; }

        [Column("BIKO")]
        public string? Biko { get; set; }

        [Column("SUITOKB")]
        public string? Suitokb { get; set; }

        [Column("SHIHARAIDT")]
        public DateTime? Shiharaidt { get; set; }

        [Column("KINGAKU")]
        public decimal? Kingaku { get; set; }

        [Column("INSERT_OPE_ID")]
        public string? InsertOpeId { get; set; }

        [Column("INSERT_PGM_ID")]
        public string? InsertPgmId { get; set; }

        [Column("INSERT_PGM_PRM")]
        public string? InsertPgmPrm { get; set; }

        [Column("INSERT_DATE")]
        public DateTime? InsertDate { get; set; }

        [Column("UPDATE_OPE_ID")]
        public string? UpdateOpeId { get; set; }

        [Column("UPDATE_PGM_ID")]
        public string? UpdatePgmId { get; set; }

        [Column("UPDATE_PGM_PRM")]
        public string? UpdatePgmPrm { get; set; }

        [Column("UPDATE_DATE")]
        public DateTime? UpdateDate { get; set; }
    }
}
