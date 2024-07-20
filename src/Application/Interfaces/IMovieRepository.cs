using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieRepository
    {
        public List<Movie> GetAll();

        public Movie? GetMovieByTitle(string title);

        public void AddMovie(Movie movie);

        public bool UpdateMovie(string title, string newTitle);

        public bool DeleteMovie(string title);
    }
}
