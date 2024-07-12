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

        public void SignUp(AddUserDto user);

        public void DeleteUser(string name);

        public bool UpdatePassword(string name, string prevPassword, string newPassword);
    }
}
