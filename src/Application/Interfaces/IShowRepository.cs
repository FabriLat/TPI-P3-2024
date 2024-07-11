using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IShowRepository
    {
        public void AddShow(TimeSpan runTime, TimeSpan startTime, int movieId);

        public void DeleteShow(int movieId, TimeSpan startTime);

        public void ModifyShows(int movieId, TimeSpan startTime, UpdateShowDto showUpdated);
    }
}
