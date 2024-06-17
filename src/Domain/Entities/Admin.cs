using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Admin : User
    {
        public Admin(string name, EmailAddressAttribute email, string password)
        {
            UserName = name;
            Email = email;
            Password = password;
            UserRole = Enums.UserType.Admin;
        }
    }
}
