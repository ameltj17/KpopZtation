using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;

namespace KpopZtation.Factory
{
    public class CartFactory
    {
        public static cart createCart(int customerId, int albumId, int qty)
        {
            cart c = new cart();
            c.customerId = customerId;
            c.albumId = albumId;
            c.qty = qty;
            return c;
        }
    }
}