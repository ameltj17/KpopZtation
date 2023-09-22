using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;

namespace KpopZtation.Factory
{
    public class CustomerFactory
    {
        public static customer createCustomer(int id, string name, string email, string gender, string address, string password, string role)
        {
            customer cs = new customer();
            cs.customerId = id;
            cs.customerName = name;
            cs.customerEmail = email;
            cs.customerPassword = password;
            cs.customerGender = gender;
            cs.customerAddress = address;
            cs.customerRole = role;

            return cs;
        }
    }
}