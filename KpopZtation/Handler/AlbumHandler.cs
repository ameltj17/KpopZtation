using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Repository;

namespace KpopZtation.Handler
{
    public class AlbumHandler
    {
        public static string insertAlbum(int artistId, string name, string desc, string price, string stock, string img)
        {
            album a = AlbumRepository.findAlbum(name);
            if (a != null)
            {
                return "Album name you entered has already been registered";
            }

            int priceDecimal = int.Parse(price);
            int stockDecimal = int.Parse(stock);

            AlbumRepository.insertAlbum(artistId, name, img, priceDecimal, stockDecimal, desc);
            return "";
        }

        public static string updateAlbum(int albumId, string name, string desc, string price, string stock, string img)
        {
            int priceDecimal = int.Parse(price);
            int stockDecimal = int.Parse(stock);
            AlbumRepository.updateAlbumDetail(albumId, name, img, priceDecimal, stockDecimal, desc);
            return "";
        }

        public static string deleteAlbum(int albumId)
        {
            List<transactionDetail> td = TransactionDetailRepository.findTransactionsByAlbumId(albumId);
            if(td.Count > 0)
            {
                return "Unable to delete the selected album as it's currently associated with some users' transaction history";
            }
            CartRepository.removeAllCartByAlbumId(albumId);
            AlbumRepository.deleteAlbum(albumId);
            return "";
        }
    }
}