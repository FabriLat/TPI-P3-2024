using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            
            _movieRepository = movieRepository;
        }


        public bool CreateMovie(string title)
        {

            var movieToAdd = new Movie(title);
            _movieRepository.AddMovie(movieToAdd);
            return true;
        }

        public bool UpdateMovie(string title, string newTitle)
        {
            _movieRepository.UpdateMovie(title, newTitle);
            return true;
        }

        public bool DeleteMovie(string name)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
        }

        public Movie? GetMovieByTitle(string title)
        {
            return _movieRepository.GetMovieByTitle(title);
        }


    }
}
