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

        public List<Client> GetClients()
        {
            return _userRepository.GetUsers();
        }

        public bool SignUp(AddUserDto user)
        {
            try
            {
                _userRepository.AddUser(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(string name)
        {
            try
            {
                _userRepository.DeleteUser(name);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
