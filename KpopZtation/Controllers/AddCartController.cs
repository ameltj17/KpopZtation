using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Repository;
using KpopZtation.Handler;

namespace KpopZtation.Controllers
{
    public class AddCartController
    {
        public static string checkQuantity(string qty, int albumId)
        {
            string info = "";
            int qtyDecimal;
            if (qty.Equals(""))
            {
                info = "Quantity must be filled";
            }
            else if (int.TryParse(qty, out qtyDecimal))
            {
                album album = AlbumRepository.findAlbum(albumId);
                if (qtyDecimal <= 0)
                {
                    info = "Quantity must more than 0";
                }
            }
            else
            {
                info = "Quantity must be filled with valid format";
            }
            return info;
        }

        public static string addToCart(int customerId, int albumId, string qty)
        {
            string info = checkQuantity(qty, albumId);
            if (info.Equals(""))
            {
                info = CartHandler.addToCart(customerId, albumId, qty);
            }
            return info;
        }
    }
}