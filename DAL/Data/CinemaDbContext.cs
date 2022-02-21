using Core.Entities;
using DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    internal class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configurations
            modelBuilder.ApplyConfiguration(new MovieConfigurations());
            //...

            // Seed data
            modelBuilder.SeedGenres();
            //...
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
    }
}
