using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KpopZtation.Models;
using KpopZtation.Repository;

namespace KpopZtation.Views.TransactionHistory
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        int customerId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            customerId = int.Parse(Request.QueryString["id"]);
            List<transactionDetail> transactions = TransactionDetailRepository.getAllTransactionDetail(customerId);
            
            transactionGridView.DataSource = transactions;
            transactionGridView.DataBind();
        }
    }
}