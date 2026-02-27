using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ProjectInternship.Domain.Entities
{
    [Table("BUMON", Schema = "SYSTEM")]
    public class Department
    {

        [Key]

        [Column("BUMONCD")]
        public string BumonCD { get; set; }

        [Column("BUMONNM")]
        public string? BumonName { get; set; }

        public ICollection<PlannedTransaction>? PlannedTransactions { get; set; }
    }
}
