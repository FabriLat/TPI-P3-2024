using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieService
    {
        public bool CreateMovie(string title);

        public bool UpdateMovie(string title);

        public bool DeleteMovie(string title);

        public Movie GetMovieByTitle(string title);

        public List<Movie> GetAllMovies();

    }
}
