using DDB.DVDCentral.BL.Models;
using DDB.DVDCentral.UI.Models;
using DDB.DVDCentral.UI.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
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

        public IActionResult StartCheckout()
        {
            cart = GetShoppingCart();

            if (cart.TotalItems == 0)
            {
                ViewBag.Error = "No Items in you Cart";
                return View(nameof(Index), cart);
            }
                
            
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                // MovieViewModel movieViewModel = null;
                // movieViewModel = new MovieViewModel(id);
                // HttpContext.Session.SetObject("genreids", movieViewModel.GenreIds);
                ViewBag.Title = "Processs Order";
                ViewBag.Subject = "Assign to a Customer";

                return View();
            }

            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            
        }

        public IActionResult FinalCheckout()
        {
            cart = GetShoppingCart();
            string message = ShoppingCartManager.Checkout(cart);

            //no more cart after we check out
            if(message == "Thank You For Your Order") 
            {
                HttpContext.Session.SetObject("cart", null);
            }
            
            ViewBag.Title = message;
            return View();
        }
    }
}

