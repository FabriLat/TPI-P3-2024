using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IActionResult Authenticate([FromBody] AuthenticationRequest credentials)
        {
            string token = "";

            return Ok(token);
        }
    }
}
