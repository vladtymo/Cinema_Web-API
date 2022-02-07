using Cinema_WebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public readonly CinemaDbContext _context;
        public GenreController(CinemaDbContext context)
        {
            _context = context;
        }

        //[HttpGet("list")] // api/genre/list
        //[HttpGet("/allgenres")] // allgenres
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get()
        {
            return _context.Genres.ToList();
        }

        [HttpGet("{id}")] // api/genre/5
        public ActionResult<Genre> Get(int id)
        {
            var genre = _context.Genres.FirstOrDefault(g => g.Id == id);

            if (genre == null) return NotFound();

            return genre;
        }

        [HttpPost]
        public ActionResult Post()
        {
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put()
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
}
