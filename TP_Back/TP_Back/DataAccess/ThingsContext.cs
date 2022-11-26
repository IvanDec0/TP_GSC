using Microsoft.EntityFrameworkCore;
using System.Net;
using TP_Back.Entities;

#nullable disable

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
            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .HasMaxLength(150);

            //modelBuilder.Entity<Category>()
                //.HasIndex(c => c.Description);


            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Person>()
                .Property(p => p.PhoneNumber)
                .HasMaxLength(50);

            modelBuilder.Entity<Person>()
                .Property(p => p.Email)
                .HasMaxLength(100);



            modelBuilder.Entity<Thing>()
                .Property(t => t.Description)
                .HasMaxLength(150);

            modelBuilder.Entity<Thing>()
              .Property(t => t.CreationDate)
              .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Thing>()
             .HasOne(t => t.Category);

            
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
