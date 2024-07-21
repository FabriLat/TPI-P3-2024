using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {  
            _userRepository = userRepository; 
        }

        public List<ShowUserDto> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public bool SignUp(AddUserDto user) //validar que no exista ya
        {
            if (_userRepository.GetUserByName(user.UserName) == null) // Falta validar que user.UserRole sea  >= 0 y <= 1 
            {
                _userRepository.AddUser(user);
                return true;
            }      
            
            return false;
        }

        public bool DeleteUser(string name) //hacer uso de try catch y manejo de errores
        {
            if (_userRepository.GetUserByName(name) != null) 
            {
                _userRepository.DeleteUser(name);
                return true ;
            }

            return false;
        }

        public bool UpdatePassword(string name, string prevPassword, string newPassword) 
        {
            var user = _userRepository.GetUserByName(name);

            if (user != null && user.Password == prevPassword)
            {
                _userRepository.UpdatePassword(name, newPassword);
                return true;
            }
            else
                return false;//not found o contraseña incorrecta
            
        }
    }
}
