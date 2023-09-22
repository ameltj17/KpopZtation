using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class AlbumRepository
    {
        static KzEntities db = DatabaseSingleton.GetInstance();

        public static void insertAlbum(int artistId, string name, string img, int price, int stock, string desc)
        {
            int albumId = 1;
            if (db.albums.Count() > 0)
            {
                albumId = db.albums.Max(a => a.albumId) + 1;
            }
            album album = AlbumFactory.createAlbum(albumId, artistId, name, img, price, stock, desc);
            db.albums.Add(album);
            db.SaveChanges();
        }

        public static void updateAlbumDetail(int albumId, string name, string img, int price, int stock, string desc)
        {
            album album = findAlbum(albumId);
            album.albumName = name;
            album.albumImage = img;
            album.albumPrice = price;
            album.albumStock = stock;
            album.albumDescription = desc;
            db.SaveChanges();
        }

        public static void updateAlbumStock(int albumId, int amount)
        {
            album album = findAlbum(albumId);
            album.albumStock += amount;
            db.SaveChanges();
        }

        public static album findAlbum(int albumId)
        {
            return (from a in db.albums where a.albumId.Equals(albumId) select a).FirstOrDefault();
        }

        public static album findAlbum(string name)
        {
            return (from a in db.albums where a.albumName.Equals(name) select a).FirstOrDefault();
        }

        public static List<album> getAlbumsByArtistId(int artistId)
        {
            return (from a in db.albums where a.artistId.Equals(artistId) select a).ToList();
        }

        public static void deleteAlbum(int albumId)
        {
            album album = findAlbum(albumId);
            deleteAlbumImage(album.albumImage);
            db.albums.Remove(album);
            db.SaveChanges();
        }

        public static void deleteAlbums(List<album> albums)
        {
            foreach (var a in albums)
            {
                deleteAlbumImage(a.albumImage);
                db.albums.Remove(a);
            }

            db.SaveChanges();
        }

        public static void deleteAlbumImage(string image)
        {
            string imagePath = image;
            if (!imagePath.StartsWith("~/Images/Album/"))
            {
                imagePath = "~/Images/Album/" + image;
            }
            string physicalPath = System.Web.Hosting.HostingEnvironment.MapPath(imagePath);
            File.Delete(physicalPath);
        }
    }
}