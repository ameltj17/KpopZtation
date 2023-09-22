using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Repository;

namespace KpopZtation.Handler
{
    public class CustomerHandler
    {
        public static string login(string email, string password)
        {
            customer cs = CustomerRepository.findCustomer(email, password);
            if (cs == null)
            {
                return "Username or Password is incorrect!";
            }
            return "";
        }
        public static string register(string name, string email, string gender, string address, string password)
        {
            customer cs = CustomerRepository.findCustomer(email);
            if (cs != null)
            {
                return "Email has already been used!";
            }

            CustomerRepository.insertCustomer(name, email, gender, address, password);
            return "";
        }
        public static string updateProfile(int customerId, string name, string email, string gender, string address, string password)
        {
            customer cs = CustomerRepository.findCustomer(email);

            if (cs != null && cs.customerId != customerId)
            {
                return "Email has already been used!";
            }

            CustomerRepository.updateCustomer(customerId, name, email, gender, address, password);
            return "";
        }
    }
}