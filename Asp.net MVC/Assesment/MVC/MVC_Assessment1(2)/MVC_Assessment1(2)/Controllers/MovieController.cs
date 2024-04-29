using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MoviesApp.Models;
using MVC_Assessment1_2_.Models;

namespace Assessment1_2_.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieRepository _repository;

        public MoviesController()
        {
            _repository = new MovieRepository();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _repository.GetAllMovies();
            return View(movies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _repository.AddMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            Movies movie = _repository.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            Movies movie = _repository.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteMovie(id);
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year)
        {
            var movies = _repository.GetMoviesByYear(year);
            return View(movies);
        }


    }
}