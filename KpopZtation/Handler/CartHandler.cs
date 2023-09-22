using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Repository;

namespace KpopZtation.Handler
{
    public class CartHandler
    {
        public static string addToCart(int customerId, int albumId, string qty)
        {
            cart c = CartRepository.findCart(customerId, albumId);
            album a = AlbumRepository.findAlbum(albumId);

            int decimalQty = int.Parse(qty);

            if (c != null)
            {
                int existQty = c.qty;
                int remainingStock = a.albumStock - existQty;

                if (decimalQty <= remainingStock)
                {
                    CartRepository.addExistCart(customerId, albumId, decimalQty);
                    return "";
                }
                return "Maximum quantity you can add to cart is " + remainingStock.ToString();
            }
            else
            {
                if (decimalQty <= a.albumStock)
                {
                    CartRepository.addNewCart(customerId, albumId, decimalQty);
                    return "";
                }
                return "Maximum quantity you can add to cart is " + a.albumStock.ToString();
            }
        }

        public static string checkOut(int customerId)
        {
            List<cart> carts = CartRepository.getAllCart(customerId);
            if (carts.Count > 0)
            {
                TransactionHandler.insertTransaction(carts);
                CartRepository.removeAllCart(customerId);
                return "";
            }
            return "There is no product in your cart";
        }
    }
}