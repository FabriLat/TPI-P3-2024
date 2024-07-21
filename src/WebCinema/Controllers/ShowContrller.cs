using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowContrller : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowContrller(IShowService showService)
        {
            _showService=showService;
        }   


        [HttpPost("[action]")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AddShow([FromQuery]TimeSpan runTime, [FromQuery] TimeSpan startTime, [FromQuery] int movieId)
        {
            if (_showService.AddShow(runTime, startTime, movieId))
                return Ok("Se agrego la funcion con exito!!");

            return NotFound("La pelicula no exite o esta intentando agregar una funcion ya existente");
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteShow(int movieId, TimeSpan startTime)
        {
            if (_showService.DeleteShow(movieId, startTime))
                return Ok($"La funcion de las {startTime} se elimino correctamente!!");

            return NotFound("La pelicula o la funcion no exite");
        }
    }
}
