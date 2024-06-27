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
        public List<Show> ShowsBuyed { get; set; }
        
        public Client() { }
        public Client(string name, string email, string password) 
        {
            UserName = name;
            Email = email;
            Password = password;
            UserRole = Enums.UserType.Client;
            ShowsBuyed = new List<Show>();
        }
    }
}
