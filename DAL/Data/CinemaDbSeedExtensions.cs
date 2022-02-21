using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public enum Genres : int
    {
        Comedy = 1, 
        Adventure, 
        Drama, 
        Romance, 
        Action, 
        Thriller, 
        Crime, 
        Children, 
        Fantasy, 
        Documentary, 
        Animation, 
        Musical, 
        Horror, 
        Sci_Fi
    }

    public static class CinemaDbSeedExtensions
    {
        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new[]
            {
                new Genre() { Id = (int)Genres.Comedy, Name = "Comedy" },
                new Genre() { Id = (int)Genres.Adventure, Name = "Adventure" },
                new Genre() { Id = (int)Genres.Drama, Name = "Drama" },
                new Genre() { Id = (int)Genres.Romance, Name = "Romance" },
                new Genre() { Id = (int)Genres.Action, Name = "Action" },
                new Genre() { Id = (int)Genres.Thriller, Name = "Thriller" },
                new Genre() { Id = (int)Genres.Crime, Name = "Crime" },
                new Genre() { Id = (int)Genres.Children, Name = "Children" },
                new Genre() { Id = (int)Genres.Fantasy, Name = "Fantasy" },
                new Genre() { Id = (int)Genres.Documentary, Name = "Documentary" },
                new Genre() { Id = (int)Genres.Animation, Name = "Animation" },
                new Genre() { Id = (int)Genres.Musical, Name = "Musical" },
                new Genre() { Id = (int)Genres.Horror, Name = "Horror" },
                new Genre() { Id = (int)Genres.Sci_Fi, Name = "Sci-Fi" }
            });
        }
    }
}
