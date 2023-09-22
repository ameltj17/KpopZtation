using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class TransactionHeaderRepository
    {
        static KzEntities db = DatabaseSingleton.GetInstance();

        public static void insertTransactionHeader(int transactionId, DateTime date, int customerId)
        {
            transactionHeader th = TransactionFactory.createTransactionHeader(transactionId, date, customerId);
            db.transactionHeaders.Add(th);
            db.SaveChanges();
        }

        public static int generateId()
        {
            int transactionId = 1;
            if (db.transactionHeaders.Count() > 0)
            {
                transactionId = db.transactionHeaders.Max(t => t.transactionId) + 1;
            }
            return transactionId;
        }

        public static List<transactionHeader> GetAllTransactions()
        {
            return db.transactionHeaders.ToList();
        }
    }
}