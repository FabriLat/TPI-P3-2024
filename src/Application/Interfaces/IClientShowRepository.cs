using Application.Models;
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
        public bool BuyShow(int showId, int clientId);
        public List<ViewShowDto> ViewPurchases(int clientId);
    }
}
