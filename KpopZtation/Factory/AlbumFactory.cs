using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;

namespace KpopZtation.Factory
{
    public class AlbumFactory
    {
        public static album createAlbum(int id, int artistId, string name, string img, int price, int stock, string desc)
        {
            album ab = new album();
            ab.albumId = id;
            ab.artistId = artistId;
            ab.albumName = name;
            ab.albumImage = img;
            ab.albumPrice = price;
            ab.albumStock = stock;
            ab.albumDescription = desc;

            return ab;
        }
    }
}