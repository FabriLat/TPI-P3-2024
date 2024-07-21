using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return NotFound();
            
                
        }

        [HttpGet("[action]/{clientId}")]
        public IActionResult ViewPurchases(int clientId)
        {
            return Ok(_clientShowService.ViewPurchases(clientId));
        }

    }
}
