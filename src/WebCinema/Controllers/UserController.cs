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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService=userService;
        }

        [HttpPost("[action]")]
        public bool SignUp(AddUserDto user) // UserRole: 1 (client)  0 (admin)
        {
            return _userService.SignUp(user);
        }

        [HttpGet("[action]")]
        public List<Client> GetClients()
        {
            return _userService.GetClients();
        }

        [HttpPut("[action]/{name}")]
        public bool ChangePassword(string name, [FromQuery]string prevPassword, [FromQuery] string newPassword)
        {
            return _userService.UpdatePassword(name, prevPassword, newPassword);
        }
    }
}
