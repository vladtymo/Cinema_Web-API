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

        [HttpGet("{id:int}")] // api/genre/5
        public ActionResult<Genre> Get(int id)
        {
            var genre = _context.Genres.FirstOrDefault(g => g.Id == id);

            if (genre == null) return NotFound();

            return genre;
        }

        [HttpPost()]
        public ActionResult Post([FromBody] Genre genre)
        {
            // ApiController attribute already checked the model state 
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            _context.Genres.Add(genre);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var genre = _context.Genres.FirstOrDefault(g => g.Id == id);

            if (genre == null) return NotFound();
            _context.Genres.Remove(genre);
            _context.SaveChanges();

            return Ok();
        }
    }
}
