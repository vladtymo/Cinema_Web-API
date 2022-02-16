using BLL.DTO;
using DAL.Entities;
using System.Collections.Generic;

namespace BLL
{
    public interface IGenreService
    {
        void AddGenre(GenreDTO genre);
        IEnumerable<GenreDTO> GetAllGenres();
        GenreDTO GetGenreById(int id);
        void EditGenre(GenreDTO genre);
        void DeleteGenreById(int id);
    }

}
