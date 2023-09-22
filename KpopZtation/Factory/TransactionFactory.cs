using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;

namespace KpopZtation.Factory
{
    public class TransactionFactory
    {
        public static transactionHeader createTransactionHeader(int id, DateTime date, int customerId)
        {
            transactionHeader th = new transactionHeader();
            th.transactionId = id;
            th.transactionDate = date;
            th.customerId = customerId;

            return th;
        }

        public static transactionDetail createTransactionDetail(int transactionId, int albumId, int qty)
        {
            transactionDetail td = new transactionDetail();
            td.transactionId = transactionId;
            td.albumId = albumId;
            td.qty = qty;

            return td;
        }
    }
}