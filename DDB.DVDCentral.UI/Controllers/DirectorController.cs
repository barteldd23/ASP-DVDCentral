using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDB.DVDCentral.UI.Controllers
{
    public class DirectorController : Controller
    {
        // GET: DirectorController
        public ActionResult Index()
        {
            ViewBag.Title = "Directors";
            return View(DirectorManager.Load());
        }

        // GET: DirectorController/Details/5
        public ActionResult Details(int id)
        {
            var item = DirectorManager.LoadById(id);
            ViewBag.Title = "Director";
            ViewBag.Subject = item.FullName;
            return View(item);
        }

        // GET: DirectorController/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.Subject = "Director";
            return View();
        }

        // POST: DirectorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Director director)
        {
            try
            {
                int result = DirectorManager.Insert(director);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DirectorController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = DirectorManager.LoadById(id);
            ViewBag.Title = "Edit Director";
            ViewBag.Subject = item.FullName;
            return View(item);
        }

        // POST: DirectorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Director director)
        {
            try
            {
                int result = DirectorManager.Update(director);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DirectorController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = DirectorManager.LoadById(id);
            ViewBag.Title = "Are You sure you want to delete this?";
            ViewBag.Subject = "Director: " + item.FullName;
            return View(item);
        }

        // POST: DirectorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = DirectorManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
