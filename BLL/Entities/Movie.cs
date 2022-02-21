using DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Movie : IBaseEntity
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
