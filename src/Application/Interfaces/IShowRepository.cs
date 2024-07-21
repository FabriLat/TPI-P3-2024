﻿using Application.Models;
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
        public bool AddShow(TimeSpan runTime, TimeSpan startTime, int movieId);

        public bool DeleteShow(int movieId, TimeSpan startTime);

    }
}
