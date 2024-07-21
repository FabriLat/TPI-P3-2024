using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly ApplicationContext _context;
        public ShowRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool AddShow(string runTime, string startTime, int movieId) 
        {
            var show = new Show(runTime,startTime);

            show.MovieId = movieId;

            var movie = _context.Movies.Include(m => m.Shows).FirstOrDefault(m => m.Id == movieId);


            if (movie != null && !movie.Shows.Contains(show)) //comprueba que exista la pelicula indicada para agregarla y que la funcion no exista ya 
            {
              
                _context.Shows.Add(show);
                _context.SaveChanges();

                return true;
            }
            
            return false;
        }

        public bool DeleteShow(int movieId, string startTime) 
        {
            var showToDelete = _context.Shows.FirstOrDefault(s => (s.MovieId == movieId && s.StartTime == startTime));

            if (showToDelete != null)
            {
                _context.Shows.Remove(showToDelete);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
     
    }
}