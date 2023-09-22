using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class CartRepository
    {
        static KzEntities db = DatabaseSingleton.GetInstance();

        public static void addNewCart(int customerId, int albumId, int qty)
        {
            cart newCart = CartFactory.createCart(customerId, albumId, qty);
            db.carts.Add(newCart);
            db.SaveChanges();
        }

        public static void addExistCart(int customerId, int albumId, int qty)
        {
            cart existCart = findCart(customerId, albumId);
            existCart.qty += qty;
            db.SaveChanges();
        }

        public static cart findCart(int customerId, int albumId)
        {
            return (from c in db.carts where c.customerId.Equals(customerId) && c.albumId.Equals(albumId) select c).FirstOrDefault();
        }

        public static List<cart> getAllCart(int customerId)
        {
            return (from c in db.carts where c.customerId.Equals(customerId) select c).ToList();
        }

        public static List<cart> getAllCartByAlbumId(int albumId)
        {
            return (from c in db.carts where c.albumId.Equals(albumId) select c).ToList();
        }

        public static void removeCart(int customerId, int albumId)
        {
            cart cart = findCart(customerId, albumId);
            db.carts.Remove(cart);
            db.SaveChanges();
        }

        public static void removeAllCart(int customerId)
        {
            List<cart> carts = getAllCart(customerId);

            foreach (var cart in carts)
            {
                db.carts.Remove(cart);
            }

            db.SaveChanges();
        }

        public static void removeAllCartByAlbumId(int albumId)
        {
            List<cart> carts = getAllCartByAlbumId(albumId);

            foreach (var cart in carts)
            {
                db.carts.Remove(cart);
            }

            db.SaveChanges();
        }

        public static void removeAllCartByArtistId (int artistId)
        {
            List<album> albums = AlbumRepository.getAlbumsByArtistId(artistId);

            foreach (var album in albums)
            {
                List<cart> carts = getAllCartByAlbumId(album.albumId);
                
                foreach (var cart in carts)
                {
                    db.carts.Remove(cart);
                }
            }
            db.SaveChanges();
        }
    }
}