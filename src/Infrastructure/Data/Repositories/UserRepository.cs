﻿using Application.Models;
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
    public class UserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context) 
        { 
            _context = context;
        }

        public User? GetUserByName(string name)
        {
            return _context.Users.OfType<Client>()
                  .Include(c => c.ShowsBuyed)
                  .FirstOrDefault(user => user.UserName.ToLower() == name.ToLower());
        }

        public List<Client> GetUsers()
        {
            return _context.Users.OfType<Client>()
                  .Include(c => c.ShowsBuyed)
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
        }

        public void DeleteUser( string name )
        {
            var user = _context.Users
                  .FirstOrDefault(user => user.UserName.ToLower() == name.ToLower());

            if (user != null)
                _context.Users.Remove(user);
        }
    }
}
