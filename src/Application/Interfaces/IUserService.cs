using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public List<Client> GetClients();

        public bool SignUp(AddUserDto user);

        public bool DeleteUser(string name);

        public bool UpdatePassword(string name, string prevPassword, string newPassword);
    }
}
