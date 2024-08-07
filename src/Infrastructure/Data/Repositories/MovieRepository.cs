﻿using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationContext _context;
        public MovieRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.Include(s => s.Shows).ToList(); //trae las peliculas con las funciones cargadas en la lista
        }

        public Movie? GetMovieByTitle(string title) 
        { 
            var movie =  _context.Movies.FirstOrDefault(s => s.Title.ToLower() == title.ToLower());
            return movie;
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public bool DeleteMovie(string title) 
        {
            var movieToDelete = _context.Movies.FirstOrDefault(s => s.Title.ToLower() == title.ToLower());

            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }   

        public bool UpdateMovie(string title, string newTitle)
        {
            var movieToUpdate = _context.Movies.Include(s => s.Shows).FirstOrDefault(s => s.Title.ToLower() == title.ToLower());
            if (movieToUpdate != null)
            {
                movieToUpdate.Title = newTitle;
                _context.SaveChanges();
                return true;
            }else
            {
                return false;
            }
           

        }


    }
}
