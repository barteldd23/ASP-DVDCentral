using DDB.DVDCentral.UI.Models;
using DDB.DVDCentral.UI.ViewModels;
using DVDCentral.BL.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DDB.DVDCentral.UI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Movie List";
            return View(MovieManager.Load());
        }
        public IActionResult Browse(int id)
        {
            string genre = GenreManager.LoadById(id).Description;
            ViewBag.Title = "Movie List filtered by: " + genre;
            return View(nameof(Index), MovieManager.Load(id));
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create New Movie";
            MovieViewModel movieViewModel = new MovieViewModel();
            movieViewModel.Movie = new Movie();
            movieViewModel.Formats = FormatManager.Load();
            movieViewModel.Directors = DirectorManager.Load();
            movieViewModel.Ratings = RatingManager.Load();
            movieViewModel.Genres = GenreManager.Load();

            if (Authenticate.IsAuthenticated(HttpContext))
                return View(movieViewModel);
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            
        }

        [HttpPost]
        public IActionResult Create(Movie movie, MovieViewModel movieViewModel)
        {
            try
            {
                int result = MovieManager.Insert(movie);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(movieViewModel);
            }
        }
    }
}
