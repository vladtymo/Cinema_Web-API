using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Resources;
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
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public GenreService(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddGenre(GenreDTO genre)
        {
            _context.Genres.Add(_mapper.Map<Genre>(genre));
            _context.SaveChanges();
        }

        public void DeleteGenreById(int id)
        {
            if (id < 0)
                throw new HttpException(ErrorMessages.InvalidId, HttpStatusCode.BadRequest);

            var genre = _context.Genres.FirstOrDefault(g => g.Id == id);

            if (genre == null) 
                throw new HttpException(ErrorMessages.ObjectNotExists, HttpStatusCode.NotFound);

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

        public void EditGenre(GenreDTO genre)
        {
            _context.Genres.Update(_mapper.Map<Genre>(genre));
            _context.SaveChanges();
        }

        public IEnumerable<GenreDTO> GetAllGenres()
        {
            return _mapper.Map<IEnumerable<GenreDTO>>(_context.Genres.ToList()); 
        }

        public GenreDTO GetGenreById(int id)
        {
            if (id < 0) 
                throw new HttpException(ErrorMessages.InvalidId, HttpStatusCode.BadRequest);

            var genre = _context.Genres.Find(id);

            if (genre == null)
                throw new HttpException(ErrorMessages.ObjectNotExists, HttpStatusCode.NotFound);

            return _mapper.Map<GenreDTO>(genre);
        }
    }

}
