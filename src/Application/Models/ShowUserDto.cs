using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ShowUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string UserRole { get; set; }
    }
}
