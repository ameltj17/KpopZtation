using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

using KpopZtation.Handler;

namespace KpopZtation.Controllers
{
    public class RegisterController
    {
        public static string checkName(string name)
        {
            string info = "";
            if (name.Equals(""))
            {
                info = "Name must be filled";
            }
            else if (name.Length < 5 || name.Length > 50)
            {
                info = "Name must be 5-50 characters";
            }
            return info;
        }

        public static string checkEmail(string email)
        {
            string info = "";
            if (email.Equals(""))
            {
                info = "Email must be filled";
            }

            return info;
        }

        public static string checkGender(string gender)
        {
            string info = "";
            if (gender.Equals(""))
            {
                info = "Gender must be selected";
            }
            return info;
        }

        public static string checkAddress(string address)
        {
            string info = "";
            if (address.Equals(""))
            {
                info = "Address must be selected";
            }
            else if (!address.EndsWith("Street"))
            {
                info = "Address must end with 'Street'";
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
            else if (!Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*\d).+$"))
            {
                info = "Password must be alphanumeric (letters+numbers)";
            }
            return info;
        }

        public static string register(string name, string email, string gender, string address, string password)
        {
            string info = checkName(name);
            if (info.Equals(""))
            {
                info = checkEmail(email);
            }
            if (info.Equals(""))
            {
                info = checkGender(gender);
            }
            if (info.Equals(""))
            {
                info = checkAddress(address);
            }
            if (info.Equals(""))
            {
                info = checkPassword(password);
            }
            if (info.Equals(""))
            {
                info = CustomerHandler.register(name, email, gender, address, password);
            }
            return info;
        }
    }
}