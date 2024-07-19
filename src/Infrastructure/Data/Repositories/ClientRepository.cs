using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationContext _context;

        public ClientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Show BuyShow(int showId, int clientId)
        {
            // busca la funcion a comprar en base al id ingresado 
            var show = _context.Shows.FirstOrDefault(s => s.Id == showId);

            
            if (show == null)
            {
                throw new Exception("Función no encontrada");
            }

            // busca el cliente q quiere comprar en base al id ingresado

            var client = _context.Users.OfType<Client>().FirstOrDefault(c => c.Id == clientId);
        

            if(client == null)
            {
                throw new Exception("Cliente no encontrado");
            }

            // si ya compró funcion, tira error
            if (client.BoughtShows.Contains(show))
            {
                throw new Exception("La función ya ha sido comprada");
            }
            else
            {
                // añado funcion a la lista de compras
                client.BoughtShows.Add(show);
                _context.SaveChanges();
            }

            
            return show;

        }

        public List<Show> ViewPurchases(int clientId)
        {
            var client = _context.Users.OfType<Client>().FirstOrDefault(c => c.Id == clientId);

            if (client == null)
            {
                throw new ArgumentException("Cliente no encontrado");
            }

            return client.BoughtShows; // devuelvo lista

        }

    }
}
