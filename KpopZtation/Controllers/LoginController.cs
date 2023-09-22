using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Handler;

namespace KpopZtation.Controllers
{
    public class LoginController
    {
        public static string checkEmail(string email)
        {
            string info = "";
            if (email.Equals(""))
            {
                info = "Email can not be empty";
            }
            return info;
        }

        public static string checkPassword(string password)
        {
            string info = "";
            if (password.Equals(""))
            {
                info = "Password can not be empty";
            }
            return info;
        }

        public static string login(string email, string password)
        {
            string info = checkEmail(email);
            if (info.Equals(""))
            {
                info = checkPassword(password);
            }
            if (info.Equals(""))
            {
                info = CustomerHandler.login(email, password);
            }
            return info;
        }
    }
}