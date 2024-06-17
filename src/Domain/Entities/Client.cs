using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        public List<Show> Shows { get; set; }
        
        public Client(string name, EmailAddressAttribute email, string password) 
        {
            UserName = name;
            Email = email;
            Password = password;
            UserRole = Enums.UserType.Client;
        }
    }
}
