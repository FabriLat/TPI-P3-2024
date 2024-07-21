using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientShowService : IClientShowService
    {
        private readonly IClientShowRepository _clientRepository;

        public ClientShowService(IClientShowRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        public bool BuyShow(int showId, int clientId)
        {
            
            return _clientRepository.BuyShow(showId, clientId);
        }

        public List<Show> ViewPurchases(int clientId)
        {
            return _clientRepository.ViewPurchases(clientId);
        }

    }
}
