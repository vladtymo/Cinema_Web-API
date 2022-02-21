using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public static class CinemaDbSeedExtensions
    {
        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new[]
            {
                new Genre() {Name = "Comedy" },
                new Genre() {Name = "Adventure" },
                new Genre() {Name = "Drama" },
                new Genre() {Name = "Romance" },
                new Genre() {Name = "Action" },
                new Genre() {Name = "Thriller" },
                new Genre() {Name = "Crime" },
                new Genre() {Name = "Children" },
                new Genre() {Name = "Fantasy" },
                new Genre() {Name = "Documentary" },
                new Genre() {Name = "Animation" },
                new Genre() {Name = "Musical" },
                new Genre() {Name = "Horror" },
                new Genre() {Name = "Sci-Fi" }
            });
        }
    }
}
