using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Handler;

namespace KpopZtation.Controllers
{
    public class UpdateArtistController
    {
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

        public static string updateArtist(int id, string name, string image, string extension, float size)
        {
            string info = checkImage(extension, size);
            if (info.Equals(""))
            {
                info = ArtistHandler.updateArtist(id, name, image);
            }
            return info;
        }
    }
}