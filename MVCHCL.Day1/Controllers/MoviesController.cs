using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHCL.Day1.Models;
using MVCHCL.Day1.ViewModel;
using System.Data.Entity;
namespace MVCHCL.Day1.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        // GET: Movies
        [AllowAnonymous]
        public ActionResult Index()
        {
            var movies = dbContext.Movies.Include(g=>g.Genre).ToList();
            return View("IndexMovies",movies);
        }
        public ActionResult DetailsMovie(int id)
        {
            var movies = dbContext.Movies.Include(g => g.Genre).ToList().SingleOrDefault(a => a.id == id);
            return View(movies);
        }
        //public List<Movie>GetMovies()
        //{
        //    List<Movie> movies = new List<Movie>
        //    {
        //        new Movie{id=1,name="Bahubali 1",Releasedate=Convert.ToDateTime("23-04-2014"),Dateadded=Convert.ToDateTime("23-04-2013"),Genre="Drama"},
        //        new Movie{id=2,name="KGF",Releasedate=Convert.ToDateTime("23-05-2019"),Dateadded=Convert.ToDateTime("23-04-2019"),Genre="Action"},
        //        new Movie{id=3,name="Bahubali 2",Releasedate=Convert.ToDateTime("23-04-2018"),Dateadded=Convert.ToDateTime("23-04-2018"),Genre="Drama"}
        //    };
        //    return movies;
        //}
        public ActionResult DisplayMovie()
        {
            //Movie mv = new Movie { name = "BAHUBHALI" };
            //return View(mv);
            MovieCustomerViewModel viewModel = new MovieCustomerViewModel();
            Movie mv = new Movie { name = "Bahubali" };
            List<Customer> customers = new List<Customer>
            {
                new Customer{customername="deepika"},
                new Customer{customername="sravani"},
                new Customer{customername="Ramya"}
            };
            viewModel.Movie = mv;
            viewModel.Customers = customers;
            return View(viewModel);
        }
        [HttpGet]
        
        public ActionResult Createmovie()
        {
            var movies = new Movie();
            ViewBag.GenreId = ListGenre();
            return View(movies);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Createmovie(Movie Moviefromview)
        {
            if (!ModelState.IsValid)
            {
                var movies = new Movie();
                ViewBag.GenreId = ListGenre();
                return View(Moviefromview);
            }
            // return View();
            dbContext.Movies.Add(Moviefromview);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public List<SelectListItem> ListGenre()
        {
            
            var genre = dbContext.Genres.Select(m => new SelectListItem { Text = m.Genrename, Value = m.Id.ToString() }).ToList();
            genre.Insert(0, new SelectListItem { Text = "---select-----", Value = "0" ,Disabled=true,Selected=true});
            return genre;
        }
    }
}