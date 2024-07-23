using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ClientOnly")]
    public class ClientController : ControllerBase
    {

        private readonly IClientShowService _clientShowService;

        public ClientController(IClientShowService clientShowService)
        {
            _clientShowService = clientShowService;
        }


        [HttpPost("[action]/{showId}")]
        public IActionResult BuyShow(int showId)
        {
            var clientId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (_clientShowService.BuyShow(showId, int.Parse(clientId)))
            {
                return Ok();
            }
            return NotFound("El id no existe o no quedan mas asientos");
            
                
        }

        [HttpGet("[action]")]
        public IActionResult ViewPurchases()
        {
            var clientId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; //nunca va a retornar null xq se ejecuta solo si se loguea un user

            return Ok(_clientShowService.ViewPurchases(int.Parse(clientId)));
        }


        [HttpDelete("[action]")]
        public IActionResult CancelPurchease(string movieTitle, string startTime)
        {
            var clientId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; 

            if(_clientShowService.CancelPurchease(int.Parse(clientId), movieTitle, startTime))
                return Ok();

            return NotFound("No se encontro la pelicula o la funcion");
        }
    }
}
