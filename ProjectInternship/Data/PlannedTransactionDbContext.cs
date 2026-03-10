// DB context to connect with db
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectInternship.Domain.Entities;

namespace ProjectInternship.Data
{
    public class PlannedTransactionDbContext : DbContext
    {
        public PlannedTransactionDbContext(DbContextOptions<PlannedTransactionDbContext> options)
            : base(options)
        {
        }

        public DbSet<PlannedTransaction> PlannedTransactions { get; set; }
        public DbSet<PlannedTransactionDetail> TransactionDetails { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
