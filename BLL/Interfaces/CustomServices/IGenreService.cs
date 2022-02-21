using Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public interface IGenreService
    {
        Task AddGenre(GenreDTO genre);
        Task<IEnumerable<GenreDTO>> GetAllGenres();
        Task<GenreDTO> GetGenreById(int id);
        Task EditGenre(GenreDTO genre);
        Task DeleteGenreById(int id);
    }

}
