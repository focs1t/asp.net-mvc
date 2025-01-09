
using Microsoft.EntityFrameworkCore;
using rest.Models;

namespace StudentMVC.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {  }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Определение связей для навигационных свойств
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Visitor)
                .WithMany()
                .HasForeignKey(t => t.VisitorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Attraction)
                .WithMany()
                .HasForeignKey(t => t.AttractionId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
