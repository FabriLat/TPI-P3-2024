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

        public void AddShow(TimeSpan runTime, TimeSpan startTime, int movieId) //movieId se enviara desde el servicio obteniendo la movie con un getMovieByName
        {
            var show = new Show(runTime,startTime);

            show.MovieId = movieId;

            _context.Shows.Add(show);
            _context.SaveChanges();
        }

        public void DeleteShow(int movieId, TimeSpan startTime) //movieId se enviara desde el servicio obteniendo la movie con un getMovieByName (el usuario proporcionara el nombre de la movie y el horario a eliminar)
        {
            var showToDelete = _context.Shows.FirstOrDefault(s => (s.MovieId == movieId && s.StartTime == startTime));

            if (showToDelete != null)
            {
                _context.Shows.Remove(showToDelete);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Show not found");
            }
        }

        public void ModifyShows(int movieId, TimeSpan startTime, UpdateShowDto showUpdated) //solo se podran modificar los horarios 
        {
            var showToUpdate = _context.Shows.FirstOrDefault(s => (s.MovieId == movieId && s.StartTime == startTime));

            if (showToUpdate != null)
            {
                showToUpdate.RunTime = showUpdated.RunTime;
                showToUpdate.StartTime = showUpdated.StartTime;
                showToUpdate.EndTime = showUpdated.EndTime;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Show not found");
            }
        }
    }
}
