using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientShowService
    {
        public bool BuyShow(int showId, int clientId);
        public List<ViewShowDto> ViewPurchases(int clientId);

        public bool CancelPurchease(int clientId, string movieTitle, string startTime);
    }
}
