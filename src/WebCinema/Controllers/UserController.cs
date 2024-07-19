using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            if(_userService.SignUp(user))
                return Ok("Usuario Registrado!!");

            return BadRequest("Ese nombre de usuario ya se encuentra registrado");
        }

        [HttpGet("[action]")]
        [Authorize]
        public List<ShowUserDto> GetUsers()
        {
            return _userService.GetUsers();
        }

        [HttpPut("[action]/{name}")]
        public IActionResult ChangePassword(string name, [FromQuery]string prevPassword, [FromQuery] string newPassword)
        {
            if (_userService.UpdatePassword(name, prevPassword, newPassword))
                return Ok("La contraseña se modifico correctamente");

            return BadRequest("El usuario no existe o la contraseña es incorrecta");
        }

        [HttpDelete("[action]")] //Lo podra utilizar solo el admin
        public IActionResult DeleteUser(string name)
        {
            if (_userService.DeleteUser(name))
                return Ok($"Usuario [{name}] eliminado");

            return NotFound("El ususario ingresado no existe");
        }
    }
}
