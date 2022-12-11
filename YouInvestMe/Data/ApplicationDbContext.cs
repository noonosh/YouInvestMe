using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YouInvestMe.Models;
using YouInvestMe.Models.Configuration;

namespace YouInvestMe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<YouInvestMe.Models.Idea> Idea { get; set; }
        public DbSet<YouInvestMe.Models.User> User { get; set; }
        public DbSet<YouInvestMe.Models.Client> Client { get; set; }
        public DbSet<YouInvestMe.Models.RiskLevel> RiskLevel { get; set; }
        public DbSet<YouInvestMe.Models.Product> Product { get; set; }
        public DbSet<YouInvestMe.Models.ClientIdea> ClientIdea { get; set; }

        public ApplicationDbContext (DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Required to have a many to many relationship between Client and Idea model
            builder.Entity<Idea>()
                .HasMany(i => i.Clients)
                .WithMany(c => c.Ideas)
                .UsingEntity<ClientIdea>(
                    g => g.HasOne(m => m.Client).WithMany(i => i.ClientIdeas),
                    g => g.HasOne(m => m.Idea).WithMany(c => c.ClientIdeas)
                    );
             

            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
