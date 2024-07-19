using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientShowRepository _clientShowRepository;

        public ClientService(IClientShowRepository clientShowRepository)
        {
            _clientShowRepository = clientShowRepository;
        }


        public Show BuyShow(int showId, int clientId)
        {
            return _clientShowRepository.BuyShow(showId, clientId);
        }

        public List<Show> ViewPurchases(int clientId)
        {
            return _clientShowRepository.ViewPurchases(clientId);
        }

    }
}
