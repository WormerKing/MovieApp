using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;
        public static List<Movie> Movies { 
            get {
                return _movies;    
            } 
        }
        static MovieRepository()
        {
            _movies = new List<Movie>();
            Random rnd = new Random();
            for (byte i = 1; i < 10; i++)
            {
                _movies.Add(new Movie
                {
                    Title = $"Film {i}",
                    Description = $"Açıklama {i}",
                    Director = $"Yönetmen {i}",
                    Genre_Id = rnd.Next(5),
                    Actors = "Tuncay,Merve,Aslı"
                });
            }
        }

        public static void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public static Movie GetById(int id) {
            return _movies.FirstOrDefault(elm => elm.Id == id);
        }

        public static void Update(Movie movie)
        {
            foreach(Movie mov in _movies)
            {
                if (movie.Id == mov.Id)
                {
                    mov.Title = movie.Title;
                    mov.Description = movie.Description;
                    mov.Director = movie.Director;
                    mov.Actors = movie.Actors;
                    mov.Genre_Id = movie.Genre_Id;
                    break;
                }
            }
        }

        public static void Delete(int id)
        {
            Movie movie = GetById(id);
            if (movie != null)
                _movies.Remove(movie);
        }
    }
}
