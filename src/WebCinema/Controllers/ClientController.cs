using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpPost("[action]/{showId}")]
        public IActionResult BuyShow(int showId, int clientId)
        {
            return Ok(_clientService.BuyShow(showId, clientId));
                
        }

        [HttpGet("[action]/{clientId}")]
        public IActionResult ViewPurchases(int clientId)
        {
            return Ok(_clientService.ViewPurchases(clientId));
        }

    }
}
