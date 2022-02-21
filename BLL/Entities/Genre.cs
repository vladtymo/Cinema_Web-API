using DAL.Interfaces;
using DAL.Validators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Genre : IBaseEntity
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        [FirstLetter]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
