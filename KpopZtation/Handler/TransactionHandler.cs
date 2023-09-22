using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;
using KpopZtation.Repository;

namespace KpopZtation.Handler
{
    public class TransactionHandler
    {
        public static void insertTransaction(List<cart> carts)
        {
            int transactionId = TransactionHeaderRepository.generateId();
            DateTime currentDate = DateTime.Now;
            int customerId = carts[0].customerId;
            TransactionHeaderRepository.insertTransactionHeader(transactionId, currentDate, customerId);

            foreach (var cart in carts)
            {
                TransactionDetailRepository.insertTransactionDetail(transactionId, cart.albumId, cart.qty);
                AlbumRepository.updateAlbumStock(cart.albumId, -cart.qty);
            }
        }
    }
}