using Application.Interfaces;
using Application.Models;
using Domain.Entities;
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
        public IActionResult CreateMovie([FromBody]string title) // UserRole: 1 (client)  0 (admin) (solo los admin podran agregar admins)
        {
            _movieService.CreateMovie(title);
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
            _movieService.UpdateMovie(title, newTitle);
            return Ok();
        }


        [HttpGet("[action]/{title}")]
        public Movie GetByTitle([FromRoute]string title)
        {
            return _movieService.GetMovieByTitle(title);
        }


    }
}

