using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
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
            var movieWithTitle = _movieRepository.GetMovieByTitle(title);
            var movieToAdd = new Movie(title);

            if (movieWithTitle == null)
            {
                _movieRepository.AddMovie(movieToAdd);
                    return true;
            }else
            {
                return false;
            }
            

        }

        public bool UpdateMovie(string title, string newTitle)
        {
            var movieToModify = _movieRepository.GetMovieByTitle(title);
            var movieWithTitle = _movieRepository.GetMovieByTitle(newTitle);

            if (movieToModify != null && movieWithTitle == null)
            {
                _movieRepository.UpdateMovie(title, newTitle);
                return true;
            }
            return false; 
           
        }

        public bool DeleteMovie(string title)
        {
                var response = _movieRepository.DeleteMovie(title);
                return response ;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
        }

        public Movie? GetMovieByTitle(string title)
        {
            var response = _movieRepository.GetMovieByTitle(title);
            if (response != null)
            {
                return response;
            }
            else 
            { 
                return null;
            }
        }


    }
}
