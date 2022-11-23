using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YouInvestMe.Models;

namespace YouInvestMe.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<YouInvestMe.Models.Idea> Idea { get; set; }
        public DbSet<YouInvestMe.Models.Account> Account { get; set; }
    }
}
