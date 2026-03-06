using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectInternship.Domain.Entities;

[Table("ES_YDENPYOD")]

[PrimaryKey(nameof(Denpyono), nameof(Gyono))]
public class PlannedTransactionDetail
{
    [Column("DENPYONO")]
    public decimal? Denpyono { get; set; }

    [Column("GYONO")]
    public decimal? Gyono { get; set; }

    [Column("IDODT")]
    [StringLength(8)]
    public DateTime? Idodt { get; set; } 

    [Column("SHUPPATSUPLC")]
    [StringLength(100)]
    public string? ShuppatsuPlc { get; set; }

    [Column("MOKUTEKIPLC")]
    [StringLength(100)]
    public string? MokutekiPlc { get; set; }

    [Column("KEIRO")]
    [StringLength(200)]
    public string? Keiro { get; set; }

    [Column("KINGAKU")]
    public decimal? Kingaku { get; set; }

    [Column("INSERT_OPE_ID")]
    [StringLength(30)]
    public string? InsertOpeId { get; set; }

    [Column("INSERT_PGM_ID")]
    [StringLength(20)]
    public string? InsertPgmId { get; set; }

    [Column("INSERT_PGM_PRM")]
    [StringLength(20)]
    public string? InsertPgmPrm { get; set; }

    [Column("INSERT_DATE")]
    public DateTime? InsertDate { get; set; }

    [Column("UPDATE_OPE_ID")]
    [StringLength(30)]
    public string? UpdateOpeId { get; set; }

    [Column("UPDATE_PGM_ID")]
    [StringLength(20)]
    public string? UpdatePgmId { get; set; }

    [Column("UPDATE_PGM_PRM")]
    [StringLength(20)]
    public string? UpdatePgmPrm { get; set; }

    [Column("UPDATE_DATE")]
    public DateTime? UpdateDate { get; set; }

}