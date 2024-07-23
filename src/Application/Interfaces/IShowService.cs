using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IShowService
    {
        public bool AddShow(string runTime, string startTime, int movieId);

        public bool DeleteShow(int movieId, string startTime);

        public bool ModifyShow(int movieId, string starTime, ModifyShow modifyShow);
    }
}
