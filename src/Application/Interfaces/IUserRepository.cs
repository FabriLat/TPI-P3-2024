﻿using Application.Models;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        public User? GetUserByName(string name);

        public List<ShowUserDto> GetUsers();

        public void AddUser(AddUserDto user);

        public void DeleteUser(string name);

        public bool UpdatePassword(string name,string newPassword);
    }
}
