using BLL.DTO;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
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
