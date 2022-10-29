using Microsoft.EntityFrameworkCore;
using System.Net;
using TP_Back.Entities;

namespace TP_Back.DataAccess
{
    public class ThingsContext : DbContext
    {
        public ThingsContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                .Property(x => x.CreateDate)
                .HasDefaultValueSql("GETUTCDATE()");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
