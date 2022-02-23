using AutoMapper;
using Core.DTO;
using Core.Exceptions;
using Core.Resources;
using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Core
{
    public class GenreService : IGenreService
    {
        //private readonly CinemaDbContext _context;
        private readonly IRepository<Genre> genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IRepository<Genre> genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task AddGenre(GenreDTO genre)
        {
            await genreRepository.InsertAsync(_mapper.Map<Genre>(genre));
            await genreRepository.SaveChangesAsync();
        }

        public async Task DeleteGenreById(int id)
        {
            if (id < 0)
                throw new HttpException(ErrorMessages.InvalidId, HttpStatusCode.BadRequest);

            var genre = await genreRepository.GetByIdAsync(id);

            if (genre == null) 
                throw new HttpException(ErrorMessages.ObjectNotExists, HttpStatusCode.NotFound);

            await genreRepository.DeleteAsync(genre);
            await genreRepository.SaveChangesAsync();
        }

        public async Task EditGenre(GenreDTO genre)
        {
            await genreRepository.UpdateAsync(_mapper.Map<Genre>(genre));
            await genreRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenres()
        {
            return _mapper.Map<IEnumerable<GenreDTO>>(await genreRepository.GetAsync()); 
        }

        public async Task<GenreDTO> GetGenreById(int id)
        {
            if (id < 0) 
                throw new HttpException(ErrorMessages.InvalidId, HttpStatusCode.BadRequest);

            var genre = await genreRepository.GetByIdAsync(id);

            if (genre == null)
                throw new HttpException(ErrorMessages.ObjectNotExists, HttpStatusCode.NotFound);

            return _mapper.Map<GenreDTO>(genre);
        }
    }

}
