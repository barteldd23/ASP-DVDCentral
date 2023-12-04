using DDB.DVDCentral.BL.Models;
using DVDCentral.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DDB.DVDCentral.BL
{
    public static class ShoppingCartManager
    {
        public static void Add(ShoppingCart cart, Movie item)
        {
            if (cart != null) { cart.Items.Add(item); }
        }

        public static void Remove(ShoppingCart cart, Movie item)
        {
            if (cart != null) { cart.Items.Remove(item); }
        }

        public static string Checkout(ShoppingCart cart)
        {
            // Make a new order
            // Set the Order fields as needed.
            Order order = new Order
            {
                CustomerId = 1,
                OrderDate = DateTime.Now,
                ShipDate = DateTime.Now.AddDays(3),
                UserId = CustomerManager.LoadById(1).UserId
            };


            // Make a new orderItem
            // Set the OrderItem fields from the item
            // order.OrderItems.Add(orderItem)
            foreach (Movie item in cart.Items)
            {
               
                try
                {
                    Movie inStkMovie = MovieManager.LoadById(item.Id);
                    if (inStkMovie.InStkQty > 0)
                    {
                        OrderItem orderItem = new OrderItem
                        {
                            MovieId = item.Id,
                            Quantity = 1,
                            Cost = item.Cost,
                        };
                        order.OrderItems.Add(orderItem);
                        inStkMovie.InStkQty -= 1;
                        MovieManager.Update(inStkMovie);
                    }
                    else
                    {
                        throw new Exception("Not enough " + item.Title + " movies in stock.");
                    }
                    
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                
            }

            OrderManager.Insert(order);

            // Decrement the tblMovie.InStkQty appropriately.

            cart = new ShoppingCart();

            return "Thank You For Your Order";
        }
    }
}
