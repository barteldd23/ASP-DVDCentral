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
    }
}
