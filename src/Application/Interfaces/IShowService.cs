using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IShowService
    {
        public bool AddShow(TimeSpan runTime, TimeSpan startTime, int movieId);

        public bool DeleteShow(int movieId, TimeSpan startTime);
    }
}
