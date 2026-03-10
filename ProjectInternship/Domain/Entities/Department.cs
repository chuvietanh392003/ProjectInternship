/*
-----------------------------------------------------------------------
File Name   : Department.cs
Layer       : Domain / Entity
Table Name  : SYSTEM.BUMON

Description :
    Entity class representing department master data.

    This table stores department information used in the system.
    Planned transactions are associated with a department through
    the department code.

Primary Key :
        - BumonCD : Department code

Related Entities :
        - PlannedTransaction (one department can have multiple transactions)
-----------------------------------------------------------------------
*/
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
