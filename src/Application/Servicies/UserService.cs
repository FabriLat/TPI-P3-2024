using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicies
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {  
            _userRepository = userRepository; 
        }

        public List<Client> GetClients()//esta bien devolver toda la informacion?
        {
            return _userRepository.GetUsers();
        }

        public void SignUp(AddUserDto user) //validar que no exista ya
        {

            _userRepository.AddUser(user);

        }

        public void DeleteUser(string name) //hacer uso de try catch y manejo de errores
        {
            _userRepository.DeleteUser(name);

        }

        public bool UpdatePassword(string name, string prevPassword, string newPassword) //que retorne errores/estados, no bool
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
