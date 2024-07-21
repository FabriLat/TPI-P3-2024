using Application.Interfaces;
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
                client.BoughtShows.Add(show);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public List<Show> ViewPurchases(int clientId)
        {
            var client = _context.Users.OfType<Client>().Include(c => c.BoughtShows).FirstOrDefault(c => c.Id == clientId);

            if (client == null)
            {
                throw new Exception("Cliente no encontrado");
            }

            return client.BoughtShows; // devuelvo lista

        }

    }
}
