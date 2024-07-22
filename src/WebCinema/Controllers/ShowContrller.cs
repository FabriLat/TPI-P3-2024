using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService=showService;
        }   


        [HttpPost("[action]")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AddShow([FromQuery]string runTime, [FromQuery] string startTime, [FromQuery] int movieId)
        {
            if (_showService.AddShow(runTime, startTime, movieId))
                return Ok("Se agrego la funcion con exito!!");

            return NotFound("La pelicula no exite o esta intentando agregar una funcion ya existente");
        }

        [HttpDelete("[action]")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DeleteShow(int movieId, string startTime)
        {
            if (_showService.DeleteShow(movieId, startTime))
                return Ok($"La funcion de las {startTime} se elimino correctamente!!");

            return NotFound("La pelicula o la funcion no exite");
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult ModifyShow([FromQuery]int movieId, [FromQuery] int starTime, ModifyShow modifyShow)
        {
            if (_showService.ModifyShow(movieId,starTime, modifyShow))
                return Ok("Se modifico con exito!!");

            return NotFound("La pelicula o la funcion no exite");
        }
    }
}
