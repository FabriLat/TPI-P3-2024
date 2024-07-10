﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AddUserDto
    {
        public string UserName { get; set; }


        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public UserType UserRole { get; set; }
    }
}
