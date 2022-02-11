using DAL.Entities;
using System.Collections.Generic;

namespace BLL
{
    public interface IGenreService
    {
        void AddGenre(Genre genre);
        IEnumerable<Genre> GetAllGenres();
        Genre GetGenreById(int id);
        void EditGenre(Genre genre);
        void DeleteGenreById(int id);
    }

}
