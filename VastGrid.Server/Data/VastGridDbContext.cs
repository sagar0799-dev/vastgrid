using Microsoft.EntityFrameworkCore;
using VastGrid.Server.Models.Entities;

namespace VastGrid.Server.Data
{
    public class VastGridDbContext : DbContext
    {
        public VastGridDbContext(DbContextOptions<VastGridDbContext> options) : base(options) { }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Builder> Builders { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<VisitorLog> VisitorLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1:N Builder -> Apartments
            modelBuilder.Entity<Apartment>()
                .HasOne(a => a.Builder)
                .WithMany(b => b.Apartments)
                .HasForeignKey(a => a.BuilderId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N Apartment -> Residents
            modelBuilder.Entity<Resident>()
                .HasOne(r => r.Apartment)
                .WithMany(a => a.Residents)
                .HasForeignKey(r => r.ApartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N Apartment -> Tickets
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Apartment)
                .WithMany(a => a.Tickets)
                .HasForeignKey(t => t.ApartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N Resident -> Tickets
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Resident)
                .WithMany() // A resident can have many tickets, but we don't need a collection on Resident yet
                .HasForeignKey(t => t.ResidentId)
                .OnDelete(DeleteBehavior.Cascade);

            // M:N Apartment <-> Manager is mapped in the Seed method
            
            // Invoke the Seed method from ModelBuilderExtensions
            modelBuilder.Seed();
        }
    }
}
