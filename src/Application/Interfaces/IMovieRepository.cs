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

        public Movie? GetMovieByName(string title);

        public void AddMovie(string title);

        public void DeleteMovie(string title);
    }
}
