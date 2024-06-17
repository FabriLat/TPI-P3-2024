using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context) 
        { 
            _context = context;
        }

        public User? GetUser(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }
    }
}
