using System;
using System.Collections.Generic;
using System.Linq;
using MVC_Assessment1_2_.Models;
using System.Data.Entity;
using Assessment1_2_.Models;

namespace MoviesApp.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movies> GetAllMovies();
        Movies GetMovieById(int id);
        void AddMovie(Movies movie);
        void UpdateMovie(Movies movie);
        void DeleteMovie(int id);
        IEnumerable<Movies> GetMoviesByYear(int year);
    }

    public class MovieRepository : IMovieRepository
    {
        private MoviesDB _context;

        public MovieRepository()
        {
            _context = new MoviesDB();
        }

        public IEnumerable<Movies> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movies GetMovieById(int id)
        {
            return _context.Movies.Find(id);
        }

        public void AddMovie(Movies movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movies movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            Movies movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public IEnumerable<Movies> GetMoviesByYear(int year)
        {
            return _context.Movies.Where(m => m.DateofRelease.Year == year).ToList();
        }
    }
}