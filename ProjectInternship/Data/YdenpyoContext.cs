
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectInternship.Models;

namespace ProjectInternship.Data
{
    public class YdenpyoContext : DbContext
    {
        public YdenpyoContext(DbContextOptions<YdenpyoContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectInternship.Models.EsYdenpyo> EsYdenpyos { get; set; }
        public DbSet<ProjectInternship.Models.Bumon> Bumons { get; set; }
    }
}
