﻿using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository _showRepository;

        public ShowService(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }


        public bool AddShow(TimeSpan runTime, TimeSpan startTime, int movieId)
        {
            return _showRepository.AddShow(runTime, startTime, movieId);
        }


        public bool DeleteShow(int movieId, TimeSpan startTime)
        {
            return _showRepository.DeleteShow(movieId, startTime);
        }
    }
}
