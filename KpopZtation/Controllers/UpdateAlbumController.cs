using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Handler;

namespace KpopZtation.Controllers
{
    public class UpdateAlbumController
    {
        public static string checkName(string name)
        {
            string info = "";
            if (name.Equals(""))
            {
                info = "Name must be filled";
            }
            else if (name.Length >= 50)
            {
                info = "Name length must less than 50 characters";
            }
            return info;
        }

        public static string checkDesc(string desc)
        {
            string info = "";
            if (desc.Equals(""))
            {
                info = "Description must be filled";
            }
            else if (desc.Length >= 255)
            {
                info = "Description length must less than 255 characters";
            }
            return info;
        }

        public static string checkPrice(string price)
        {
            string info = "";
            int priceDecimal;

            if (int.TryParse(price, out priceDecimal))
            {
                if (priceDecimal < 100000 || priceDecimal > 1000000)
                {
                    info = "Price must between 100000 - 1000000";
                }
            }
            else
            {
                info = "Price must be filled with valid format";
            }

            return info;
        }

        public static string checkStock(string stock)
        {
            string info = "";
            int stockDecimal;

            if (int.TryParse(stock, out stockDecimal))
            {
                if (stockDecimal <= 0)
                {
                    info = "Stock must be more than 0";
                }
            }
            else
            {
                info = "Stock must be filled with valid format";
            }

            return info;
        }

        public static string checkImage(string extension, float size)
        {
            string info = "";
            if (!extension.Equals(".png") && !extension.Equals(".jpg") && !extension.Equals(".jpeg") && !extension.Equals(".jfif"))
            {
                info = "File extension must be .png, .jpg, .jpeg, or .jfif!";
            }
            else if (size > 2 * 1024 * 1024)
            {
                info = "File must be lower than 2 MB";
            }
            return info;
        }

        public static string updateAlbumDetail(int albumId, string name, string desc, string price, string stock, string img, string extension, float size)
        {
            string info = checkName(name);
            if (info.Equals(""))
            {
                info = checkDesc(desc);
            }
            if (info.Equals(""))
            {
                info = checkPrice(price);
            }
            if (info.Equals(""))
            {
                info = checkStock(stock);
            }
            if (info.Equals(""))
            {
                info = checkImage(extension, size);
            }
            if (info.Equals(""))
            {
                info = AlbumHandler.updateAlbum(albumId, name, desc, price, stock, img);
            }
            return info;
        }
    }
}