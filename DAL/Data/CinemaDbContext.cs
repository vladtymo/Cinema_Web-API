using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.SeedGenres();
            //...
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
    }
}
