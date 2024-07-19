using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientShowRepository
    {
        public Show BuyShow(int showId, int clientId);
        public List<Show> ViewPurchases(int clientId);
    }
}
