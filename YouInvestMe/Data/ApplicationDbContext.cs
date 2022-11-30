using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YouInvestMe.Models;
using YouInvestMe.Models.Configuration;

namespace YouInvestMe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<YouInvestMe.Models.Idea> Idea { get; set; }
        public DbSet<YouInvestMe.Models.User> User { get; set; }
        public DbSet<YouInvestMe.Models.Product> Product { get; set; } = default!;
        public DbSet<YouInvestMe.Models.RiskLevel> RiskLevel { get; set; } = default!;
    }
}
