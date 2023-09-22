using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;

namespace KpopZtation.Factory
{
    public class ArtistFactory
    {
        public static artist createArtist(int id, string name, string img)
        {
            artist a = new artist();
            a.artistId = id;
            a.artistName = name;
            a.artistImage = img;

            return a;
        }
    }
}