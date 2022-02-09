using Cinema_WebApi.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_WebApi.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        [FirstLetter]
        public string Name { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        [Required, MaxLength(350)]
        public string Title { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        [Required]
        public Genre Genre { get; set; }
    }
}
