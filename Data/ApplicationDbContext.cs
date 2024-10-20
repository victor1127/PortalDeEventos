using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalDeEventos.Enums;

namespace PortalDeEventos.Data
{
    public class ApplicationDbContext : IdentityDbContext<EventUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EventUser>()
            .Property(u => u.Gender)
            .HasConversion(
                v => v.ToString(),     // Convert enum to string for saving to the database
                v => (Gender)Enum.Parse(typeof(Gender), v) // Convert string back to enum when reading from the database
            );
        }
    }
}
