using BLL.Exceptions;
using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BLL
{
    public class GenreService : IGenreService
    {
        public readonly CinemaDbContext _context;
        public GenreService(CinemaDbContext context)
        {
            _context = context;
        }

        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void DeleteGenreById(int id)
        {
            var genre = _context.Genres.FirstOrDefault(g => g.Id == id);

            if (genre == null) return;// NotFound();

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

        public void EditGenre(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        public Genre GetGenreById(int id)
        {
            if (id < 0) 
                throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);

            var genre = _context.Genres.Find(id);

            if (genre == null)
                throw new HttpException($"The Genre with id {id} does not exist!", HttpStatusCode.NotFound);

            return genre;
        }
    }

}
