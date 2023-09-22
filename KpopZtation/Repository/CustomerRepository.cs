using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class CustomerRepository
    {
        static KzEntities db = DatabaseSingleton.GetInstance();
        public static void insertCustomer(string name, string email, string gender, string address, string password)
        {
            int custoId = 1;
            if (db.customers.Count() > 0)
            {
                custoId = db.customers.Max(c => c.customerId) + 1;
            }
            string role = "Custo";
            customer customer = CustomerFactory.createCustomer(custoId, name, email, gender, address, password, role);
            db.customers.Add(customer);
            db.SaveChanges();
        }

        public static void updateCustomer(int customerId, string name, string email, string gender, string address, string password)
        {
            customer c = findCustomer(customerId);
            c.customerId = customerId;
            c.customerName = name;
            c.customerEmail = email;
            c.customerGender = gender;
            c.customerAddress = address;
            c.customerPassword = password;
            db.SaveChanges();
        }

        public static customer findCustomer(string email, string password)
        {
            customer cs = (from c in db.customers where c.customerEmail.Equals(email) && c.customerPassword.Equals(password) select c).FirstOrDefault();
            return cs;
        }

        public static customer findCustomer(string email)
        {
            customer cs = (from c in db.customers where c.customerEmail.Equals(email) select c).FirstOrDefault();
            return cs;
        }

        public static customer findCustomer(int id)
        {
            customer cs = (from c in db.customers where c.customerId.Equals(id) select c).FirstOrDefault();
            return cs;
        }
    }
}