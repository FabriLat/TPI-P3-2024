using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class MovieRepository
    {
        private readonly ApplicationContext _context;
        public MovieRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Movie> GetAll(int id)
        {
            return _context.Movies.ToList();
        }
    }
}
