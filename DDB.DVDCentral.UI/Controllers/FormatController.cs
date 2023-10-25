using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDB.DVDCentral.UI.Controllers
{
    public class FormatController : Controller
    {
        // GET: FormatController
        public ActionResult Index()
        {
            ViewBag.Title = "Formats";
            return View(FormatManager.Load());
        }

        // GET: FormatController/Details/5
        public ActionResult Details(int id)
        {
            var item = FormatManager.LoadById(id);
            ViewBag.Title = "Format";
            ViewBag.Subject = item.Description;
            return View(item);
        }

        // GET: FormatController/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.Subject = "Format";
            return View();
        }

        // POST: FormatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Format format)
        {
            try
            {
                int result = FormatManager.Insert(format);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormatController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = FormatManager.LoadById(id);
            ViewBag.Title = "Edit Format";
            ViewBag.Subject = item.Description;
            return View(item);
        }

        // POST: FormatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Format format)
        {
            try
            {
                int result = FormatManager.Update(format);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormatController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = FormatManager.LoadById(id);
            ViewBag.Title = "Are You sure you want to delete this?";
            ViewBag.Subject = "Format: " + item.Description;
            return View(item);
        }

        // POST: FormatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = FormatManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
