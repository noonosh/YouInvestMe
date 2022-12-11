using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace YouInvestMe.Models.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            // Creates the two roles used in the program
            builder.HasData(
            new IdentityRole
            {
                Name = "Creator",
                NormalizedName = "CREATOR"
            },
            new IdentityRole
            {
                Name = "Manager",
                NormalizedName = "MANAGER"
            });
        }
    }
}
