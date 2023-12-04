using DDB.DVDCentral.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DDB.DVDCentral.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCart cart;

        // GET: ShoppingCartController
        public IActionResult Index()
        {
            ViewBag.Title = "Shopping Cart";
            cart = GetShoppingCart();
            HttpContext.Session.SetObject("cart", cart);
            return View(cart);
        }

        private ShoppingCart GetShoppingCart()
        {
            if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
            {
                return HttpContext.Session.GetObject<ShoppingCart>("cart");
            }
            else
            {
                return new ShoppingCart();
            }
        }

        public IActionResult Remove(int id)
        {
            cart = GetShoppingCart();

            //do this way to prevent a hit on the DB!
            Movie movie = cart.Items.FirstOrDefault(item => item.Id == id);

            ShoppingCartManager.Remove(cart, movie);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add(int id)
        {
            cart = GetShoppingCart();
            Movie movie = MovieManager.LoadById(id);

            ShoppingCartManager.Add(cart, movie);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction(nameof(Index), "Movie");
        }

        public IActionResult Checkout()
        {
            cart = GetShoppingCart();
            string message = ShoppingCartManager.Checkout(cart);

            //no more cart after we check out
            HttpContext.Session.SetObject("cart", null);
            ViewBag.Title = message;
            return View();
        }
    }
}

