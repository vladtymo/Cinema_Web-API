﻿using BLL;
using BLL.DTO;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_WebApi.Controllers
{
    /* Log Levels
     * Trace	    0	LogTrace()	        Logs messages only for tracing purposes for the developers.
     * Debug	    1	LogDebug()	        Logs messages for short-term debugging purposes.
     * Information	2	LogInformation()	Logs messages for the flow of the application.
     * Warning	    3	LogWarning()	    Logs messages for abnormal or unexpected events in the application flow.
     * Error	    4	LogError()	        Logs error messages.
     * Critical	    5	LogCritical()	    Logs failures messages that require immediate attention.
     */
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public readonly IGenreService _genreService;
        public readonly ILogger<GenreController> _logger;

        public GenreController(ILogger<GenreController> logger, IGenreService genreService)
        {
            _genreService = genreService;
            _logger = logger;
        }

        //[HttpGet("list")] // api/genre/list
        //[HttpGet("/allgenres")] // allgenres
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public ActionResult<IEnumerable<GenreDTO>> Get()
        {
            return Ok(_genreService.GetAllGenres());
        }

        [HttpGet("{id:int}")] // api/genre/5
        public ActionResult<GenreDTO> Get(int id)
        {
            _logger.LogDebug($"Getting a genre with id {id}");

            var genre = _genreService.GetGenreById(id);

            //if (genre == null)
            //{
            //    _logger.LogError($"Not found a genre with id {id}");
            //    return NotFound();
            //}

            _logger.LogInformation($"Got a genre with id {id}");

            return genre;
        }

        [HttpPost()]
        public ActionResult Post([FromBody] GenreDTO genre)
        {
            // ApiController attribute already checked the model state 
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            _genreService.AddGenre(genre);

            _logger.LogInformation($"Genre was succesfully added!");

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] GenreDTO genre)
        {
            _genreService.EditGenre(genre);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _genreService.DeleteGenreById(id);

            return Ok();
        }
    }
}
