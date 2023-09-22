using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class ArtistRepository
    {
        static KzEntities db = DatabaseSingleton.GetInstance();

        public static void insertArtist(string name, string img)
        {
            int artistId = 1;
            if (db.artists.Count() > 0)
            {
                artistId = db.artists.Max(a => a.artistId) + 1;
            }
            artist artist = ArtistFactory.createArtist(artistId, name, img);

            db.artists.Add(artist);
            db.SaveChanges();
        }

        public static List<artist> getArtistAlphabeticalOrder()
        {
            return (from a in db.artists orderby a.artistName ascending select a).ToList();
        }

        public static artist findArtistById(int artistId)
        {
            return (from a in db.artists where a.artistId.Equals(artistId) select a).FirstOrDefault();
        }

        public static artist findArtist(string name)
        {
            name = name.ToLower();
            return (from a in db.artists where a.artistName.ToLower().Equals(name) select a).FirstOrDefault();
        }

        public static void updateArtist(int artistId, string name, string image)
        {
            artist a = findArtistById(artistId);
            deleteArtistImage(a.artistImage);
            a.artistName = name;
            a.artistImage = image;
            db.SaveChanges();
        }

        public static void deleteArtist(int artistId)
        {
            artist a = findArtistById(artistId);
            deleteArtistImage(a.artistImage);
            db.artists.Remove(a);
            db.SaveChanges();
        }

        public static void deleteArtistImage(string image)
        {
            string imagePath = image;
            if (!imagePath.StartsWith("~/Images/Artist/"))
            {
                imagePath = "~/Images/Artist/" + image;
            }
            string physicalPath = System.Web.Hosting.HostingEnvironment.MapPath(imagePath);
            File.Delete(physicalPath);
        }
    }
}