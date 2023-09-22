using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Repository;

namespace KpopZtation.Handler
{
    public class ArtistHandler
    {
        public static string insertArtist(string name, string image)
        {
            artist a = ArtistRepository.findArtist(name);
            if (a != null)
            {
                return "Artist name you entered has already been registered";
            }

            ArtistRepository.insertArtist(name, image);
            return "";
        }

        public static string updateArtist(int artistId, string name, string image)
        {
            artist a = ArtistRepository.findArtist(name);

            if (a != null)
            {
                return "Name must be unique among artists' name you've been registered!";
            }

            ArtistRepository.updateArtist(artistId, name, image);
            return "";
        }

        public static string deleteArtist(int artistId)
        {
            if (artistAlbumAssociatedWithTransaction(artistId))
            {
                return "Unable to delete the selected artist as his/her albums currently associated with some users' transaction history";
            }

            CartRepository.removeAllCartByArtistId(artistId);
            List<album> artistAlbum = AlbumRepository.getAlbumsByArtistId(artistId);
            if (artistAlbum.Count() > 0)
            {
                AlbumRepository.deleteAlbums(artistAlbum);
            }

            ArtistRepository.deleteArtist(artistId);
            return "";
        }

        public static bool artistAlbumAssociatedWithTransaction(int artistId)
        {
            List<album> albums = AlbumRepository.getAlbumsByArtistId(artistId);

            foreach (var album in albums)
            {
                if (TransactionDetailRepository.findTransactionsByAlbumId(album.albumId).Count() > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}