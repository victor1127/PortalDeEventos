using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalDeEventos.Enums;
using PortalDeEventos.Models;

namespace PortalDeEventos.Data
{
    public class ApplicationDbContext : IdentityDbContext<EventUser>
    {

        public DbSet<Events> Events { get; set; }
        public DbSet<EventRegistration> EventRegistration { get; set; }





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
