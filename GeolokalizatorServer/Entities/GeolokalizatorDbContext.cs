using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorSerwer.Entities
{
    public class GeolokalizatorDbContext : DbContext
    {
        /*private string _connectionString =
        "Server=(localdb)\\mssqllocaldb;Database=GeolokalizatorDb;Trusted_Connection=True;";*/

        public GeolokalizatorDbContext(DbContextOptions<GeolokalizatorDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Synchronization> Synchronizations { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Signal> Signals { get; set; }
        public DbSet<User_Data> UserDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsRequired();
                
            modelBuilder.Entity<User>()
                .Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Role>()
                .Property(n => n.Name)
                .IsRequired();

        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }*/
    }
}
