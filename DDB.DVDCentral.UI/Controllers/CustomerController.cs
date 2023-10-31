using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDB.DVDCentral.UI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {
            ViewBag.Title = "Customers";
            return View(CustomerManager.Load());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var item = CustomerManager.LoadById(id);
            ViewBag.Title = "Customer";
            ViewBag.Subject = item.FullName;
            return View(item);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.Subject = "Customer";
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer rating)
        {
            try
            {
                int result = CustomerManager.Insert(rating);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = CustomerManager.LoadById(id);
            ViewBag.Title = "Edit Customer";
            ViewBag.Subject = item.FullName;
            return View(item);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer rating)
        {
            try
            {
                int result = CustomerManager.Update(rating);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = CustomerManager.LoadById(id);
            ViewBag.Title = "Are You sure you want to delete this?";
            ViewBag.Subject = "Customer: " + item.FullName;
            return View(item);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = CustomerManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
