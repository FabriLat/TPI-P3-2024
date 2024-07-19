using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        


        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            
        }

        [HttpPost ("[controller]")]
        public IActionResult Authentication([FromBody] AuthenticationRequest credentialsRequest)
        {
            User? user = _authenticationService.ValidateUser(credentialsRequest);

            if (user != null)
            {
                var token = _authenticationService.Autenticate(user);

                return Ok(token);

            }     

            return Unauthorized();  
        }
    }
}
