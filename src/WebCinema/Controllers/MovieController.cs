using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Application.Services;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("[action]")]
        public IActionResult CreateMovie([FromBody]string title)
        {
            var response = _movieService.CreateMovie(title);
            if (response == false)
            {
                return BadRequest();
            }
             return Ok();
        }


        [HttpGet("[action]")]
        public List<Movie> GetAll()
        {
            return _movieService.GetAllMovies();
        }


        [HttpPut("[action]/{title}")]
        public IActionResult UpdateMovie([FromRoute]string title,[FromBody]string newTitle)
        {
            if (_movieService.UpdateMovie(title, newTitle) == true)
            {
                return Ok();
            }else
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]/{title}")]
        public Movie GetByTitle([FromRoute]string title)
        {
            return _movieService.GetMovieByTitle(title);
        }
           
        [HttpDelete("[action]/{title}")]
        public IActionResult DeleteMovie([FromRoute]string title)
        {
            try
            {
                var response = _movieService.DeleteMovie(title);
                if (response)
                {
                    return Ok();
                } else
                {
                    return StatusCode(404);
                }
                
            }
            catch (Exception e)
            {
                return StatusCode(404, $"Error: {e}");
            }
           
            
        }


    }
}

