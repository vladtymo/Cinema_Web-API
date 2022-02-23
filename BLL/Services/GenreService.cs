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
        //private readonly IRepository<Genre> genreRepository;
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddGenre(GenreDTO genre)
        {
            await unitOfWork.GenreRepository.InsertAsync(_mapper.Map<Genre>(genre));
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteGenreById(int id)
        {
            if (id < 0)
                throw new HttpException(ErrorMessages.InvalidId, HttpStatusCode.BadRequest);

            var genre = await unitOfWork.GenreRepository.GetByIdAsync(id);

            if (genre == null) 
                throw new HttpException(ErrorMessages.ObjectNotExists, HttpStatusCode.NotFound);

            await unitOfWork.GenreRepository.DeleteAsync(genre);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task EditGenre(GenreDTO genre)
        {
            await unitOfWork.GenreRepository.UpdateAsync(_mapper.Map<Genre>(genre));
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenres()
        {
            return _mapper.Map<IEnumerable<GenreDTO>>(await unitOfWork.GenreRepository.GetAsync()); 
        }

        public async Task<GenreDTO> GetGenreById(int id)
        {
            if (id < 0) 
                throw new HttpException(ErrorMessages.InvalidId, HttpStatusCode.BadRequest);

            var genre = await unitOfWork.GenreRepository.GetByIdAsync(id);

            if (genre == null)
                throw new HttpException(ErrorMessages.ObjectNotExists, HttpStatusCode.NotFound);

            return _mapper.Map<GenreDTO>(genre);
        }
    }

}
