using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Web.Data;
using MovieApp.Web.Models;
using MovieApp.Web.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly MovieContext _context;
        public HomeController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Movie film = _context.Movies.Find(1);
            return View(film);
        }

        public IActionResult list()
        {

            MovieGenreViewModel movie_genre = new MovieGenreViewModel
            {
                Movies = _context.Movies.ToList(),
                Genres = _context.Genres.ToList()
            };
            return View("MoviesList",movie_genre);
        }
        public IActionResult show(int id)
        {
            return View(_context.Movies.Find(id));
        }

        public IActionResult category(int? id,string? q)
        {
            var movies = _context.Movies.AsQueryable();
            if (id == null)
            {
                if (q == null)
                {
                    movies = _context.Movies;
                } else
                {
                    // movies = MovieRepository.Movies.FindAll(element => element.Title == q);
                    movies = movies.Where(element => element.Title == q);
                }
            }
            else
            {
                // movies = MovieRepository.Movies.FindAll(element => element.Genre_Id == id);
                movies = movies.Where(element => element.Genre_Id == id);
            }

            return View("MoviesList",new MovieGenreViewModel { Movies = movies.ToList()});
        }

        public IActionResult New()
        {
            ViewBag.Genres = new SelectList(_context.Genres,"Id","Name");
            return View(new Movie());
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                // MovieRepository.AddMovie(movie);
                _context.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("list");
            }

            ViewBag.Genres = new SelectList(_context.Genres, "Id", "Name");
            return View("New",new Movie());
        }
        public IActionResult Edit(int id) {
            if (_context.Movies.Find(id) != null)
            {
                ViewBag.Genres = new SelectList(_context.Genres, "Id", "Name");
                return View(_context.Movies.Find(id));
            } else
            {
                return RedirectToAction("list");
            }
        }

        [HttpPost]
        public IActionResult Update(int id,Movie movie)
        {
            if (ModelState.IsValid)
            {
                // MovieRepository.Update(movie);
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("list");
            }
            else
            {
                if (_context.Movies.Find(id) != null)
                {
                    ViewBag.Genres = new SelectList(_context.Genres, "Id", "Name");
                    return View("edit",_context.Movies.Find(id));
                }
                else
                {
                    return RedirectToAction("list");
                }
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            // MovieRepository.Delete(id);
            _context.Remove(id);
            _context.SaveChanges();
            TempData["message"] = $"{id} idli kayıt başarıyla silindi";
            return RedirectToAction("list");
        }
    }
}
