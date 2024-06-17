using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
 
        public string UserName { get; set; }


        public string Password { get; set; }


        [EmailAddress(ErrorMessage = "Email invalido")]
        public EmailAddressAttribute Email { get; set; }

        public UserType UserRole { get; set; }
    }
}
