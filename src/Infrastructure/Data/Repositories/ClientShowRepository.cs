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
    public class ClientShowRepository : IClientShowRepository
    {
        private readonly ApplicationContext _context;

        public ClientShowRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool BuyShow(int showId, int clientId)
        {
            // busca la funcion a comprar en base al id ingresado 
            var show = _context.Shows.FirstOrDefault(s => s.Id == showId);

            // busca el cliente q quiere comprar en base al id ingresado

            var client = _context.Users.OfType<Client>().Include(c => c.BoughtShows).FirstOrDefault(c => c.Id == clientId);

            if (client != null && show != null)
            {
                if (show.SeatsAvailable == 0)
                    return false;

                client.BoughtShows.Add(show);
                show.SeatsAvailable =  show.SeatsAvailable - 1;
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public List<ViewShowDto> ViewPurchases(int clientId)
        {
            var client = _context.Users.OfType<Client>().Include(c => c.BoughtShows).FirstOrDefault(c => c.Id == clientId);

            if (client == null)
            {
                throw new Exception("Cliente no encontrado");
            }

            var listShows = new List<ViewShowDto>();
 
                foreach (var show in client.BoughtShows)
                {
                    var movieTitle = _context.Movies.FirstOrDefault(c => c.Id == show.MovieId).Title; //para mostrar el nombre de la peli

                    var showDto = new ViewShowDto(show.Id, movieTitle, show.RunTime, show.StartTime);

                    listShows.Add(showDto);
                }

            return listShows;
        }


        public bool CancelPurchease(int clientId, string movieTitle, string startTime)
        {
            var client = _context.Users.OfType<Client>().Include(c => c.BoughtShows).FirstOrDefault(c => c.Id == clientId);

            var movie = _context.Movies.FirstOrDefault(m => m.Title == movieTitle);

            if (client == null || movie == null)
            {
                throw new Exception("Cliente o pelicula no encontrado");
            }
            else
            {
                var showToRemove = client.BoughtShows.Where(s => s.MovieId == movie.Id && s.StartTime == startTime).FirstOrDefault();

                if (showToRemove != null)
                { 
                    client.BoughtShows.Remove(showToRemove);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
