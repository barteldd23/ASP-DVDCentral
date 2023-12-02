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

        public static void Checkout(ShoppingCart cart)
        {
            // Make a new order
            // Set the Order fields as needed.

            // foreach(Movie item in cart.Items)
            //
            // Make a new orderItem
            // Set the OrderItem fields from the item
            // order.OrderItems.Add(orderItem)

            // OrderManager.Insert(order)

            // Decrement the tblMovie.InStkQty appropriately.

            cart = new ShoppingCart();
        }
    }
}
