using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService=userService;
        }

        [HttpPost("[action]")]
        public IActionResult SignUp(AddUserDto user) // UserRole: 1 (client)  0 (admin) (solo los admin podran agregar admins)
        {
            if (user.UserRole == UserType.Admin) //validacion para que solo admins agreguen admins
            {

                var userRole = User.Claims.FirstOrDefault(c => c.Type.Contains("role"))?.Value;


                if (userRole != "Admin")
                {
                    return Unauthorized("No tienes permiso para registrar administradores.");
                }
            }

            if (_userService.SignUp(user))
                return Ok("Usuario Registrado!!");

            return BadRequest("Ese nombre de usuario ya se encuentra registrado");
        }

        [HttpGet("[action]")]
        [Authorize(Policy = "AdminOnly")]
        public List<ShowUserDto> GetUsers()
        {
            return _userService.GetUsers();
        }

        [HttpPut("[action]")]
        [Authorize]
        public IActionResult ChangePassword([FromQuery]string prevPassword, [FromQuery] string newPassword)
        {
            var name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;

            if (_userService.UpdatePassword(name, prevPassword, newPassword))
                return Ok("La contraseña se modifico correctamente");

            return BadRequest("la contraseña es incorrecta");
        }

        [HttpDelete("[action]")] //Lo podra utilizar solo el admin
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DeleteUser(string name)
        {
            if (_userService.DeleteUser(name))
                return Ok($"Usuario [{name}] eliminado");

            return NotFound("El ususario ingresado no existe");
        }
    }
}
