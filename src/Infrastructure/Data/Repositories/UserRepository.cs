using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context) 
        { 
            _context = context;
        }

        public User? GetUserByName(string name)
        {
            var user = _context.Users.FirstOrDefault(user => user.UserName == name);

            if (user != null && user.UserRole == UserType.Client)
            {
                //si es un cliente se le cargan las funciones compradas
                user = _context.Users.OfType<Client>()
                                   .Include(c => c.BoughtShows)
                                   .FirstOrDefault(user => user.UserName == name);
                return user;
            }

            return user;
        }

        public List<ShowUserDto> GetUsers()
        {
            return _context.Users
                  .Select(user => new ShowUserDto
                  {
                      UserName = user.UserName,
                      Email = user.Email,
                      UserRole = user.UserRole == 0? "Admin" : "Client"
                  })
                  .ToList();

        }

        public void AddUser(AddUserDto user)
        {
            User newUser;


            if (user.UserRole == UserType.Client) 
                newUser = new Client(user.UserName, user.Email, user.Password);
            else
                newUser = new Admin(user.UserName, user.Email, user.Password);
            

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public void DeleteUser( string name )
        {
            var user = _context.Users
                  .FirstOrDefault(user => user.UserName == name);

            if (user != null)
            { 
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public bool UpdatePassword(string name, string newPassword)
        {
            var user = _context.Users.FirstOrDefault(user => user.UserName == name);

                user.Password = newPassword;
                _context.SaveChanges();
                return true;
        }
    }
}
