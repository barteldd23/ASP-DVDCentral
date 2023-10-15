using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDB.DVDCentral.UI.Controllers
{
    public class RatingController : Controller
    {
        // GET: RatingController
        public ActionResult Index()
        {
            return View(RatingManager.Load());
        }

        // GET: RatingController/Details/5
        public ActionResult Details(int id)
        {
            return View(RatingManager.LoadById(id));
        }

        // GET: RatingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RatingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rating rating)
        {
            try
            {
                int result = RatingManager.Insert(rating);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RatingController/Edit/5
        public ActionResult Edit(int id)
        {
            Rating rating = RatingManager.LoadById(id);
            return View(rating);
        }

        // POST: RatingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rating rating)
        {
            try
            {
                int result = RatingManager.Update(rating);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RatingController/Delete/5
        public ActionResult Delete(int id)
        {
            Rating rating = RatingManager.LoadById(id);
            return View(rating);
        }

        // POST: RatingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = RatingManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
