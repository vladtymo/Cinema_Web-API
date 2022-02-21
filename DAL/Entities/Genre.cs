using DAL.Interfaces;
using DAL.Validators;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Genre : IBaseEntity
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        [FirstLetter]
        public string Name { get; set; }
    }
}
