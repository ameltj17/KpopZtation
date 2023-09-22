using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class TransactionDetailRepository
    {
        static KzEntities db = DatabaseSingleton.GetInstance();

        public static void insertTransactionDetail(int transactionId, int albumId, int qty)
        {
            transactionDetail td = TransactionFactory.createTransactionDetail(transactionId, albumId, qty);
            db.transactionDetails.Add(td);
            db.SaveChanges();
        }

        public static List<transactionDetail> getAllTransactionDetail(int customerId)
        {
            return (from t in db.transactionDetails where t.transactionHeader.customerId.Equals(customerId) select t).ToList();
        }

        public static List<transactionDetail> findTransactionsByAlbumId(int albumId)
        {
            return (from t in db.transactionDetails where t.albumId.Equals(albumId) select t).ToList();
        }

        public static List<transactionDetail> getAllTransactionDetail()
        {
            return db.transactionDetails.ToList();
        }
    }
}