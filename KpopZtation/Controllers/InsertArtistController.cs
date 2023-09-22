using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Handler;

namespace KpopZtation.Controllers
{
    public class InsertArtistController
    {
        public static string checkName(string name)
        {
            string info = "";
            if (name.Equals(""))
            {
                info = "Name must be filled";
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

        public static string insertArtist(string name, string image, string extension, float size)
        {
            string info = checkName(name);
            if (info.Equals(""))
            {
                info = checkImage(extension, size);
            }
            if (info.Equals(""))
            {
                info = ArtistHandler.insertArtist(name, image);
            }
            return info;
        }
    }
}