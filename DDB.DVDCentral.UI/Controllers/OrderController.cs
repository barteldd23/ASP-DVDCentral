using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDB.DVDCentral.UI.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController
        public ActionResult Index()
        {
            ViewBag.Title = "Orders";
            return View(OrderManager.Load());
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var item = OrderManager.LoadById(id);
            ViewBag.Title = "Order";
            ViewBag.Subject = "No. : " + item.Id.ToString();
            return View(item);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.Subject = "Order";
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order rating)
        {
            try
            {
                int result = OrderManager.Insert(rating);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = OrderManager.LoadById(id);
            ViewBag.Title = "Edit Order";
            ViewBag.Subject = "No. : " + item.Id.ToString();
            return View(item);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order rating)
        {
            try
            {
                int result = OrderManager.Update(rating);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = OrderManager.LoadById(id);
            ViewBag.Title = "Are You sure you want to delete this?";
            ViewBag.Subject = "Order No.: " + item.Id.ToString();
            return View(item);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = OrderManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
