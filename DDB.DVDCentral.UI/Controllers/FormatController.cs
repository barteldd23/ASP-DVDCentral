using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDB.DVDCentral.UI.Controllers
{
    public class FormatController : Controller
    {
        // GET: FormatController
        public ActionResult Index()
        {
            return View(FormatManager.Load());
        }

        // GET: FormatController/Details/5
        public ActionResult Details(int id)
        {
            Format format = FormatManager.LoadById(id);
            return View(format);
        }

        // GET: FormatController/Create
        public ActionResult Create()
        {
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
            Format format = FormatManager.LoadById(id);
            return View(format);
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
            Format format = FormatManager.LoadById(id);
            return View(format);
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
