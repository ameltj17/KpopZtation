using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KpopZtation.Models;
using KpopZtation.Repository;


namespace KpopZtation.Views
{
    public partial class NavBar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            resetNavbar();
            if (Session["customer"] != null || Request.Cookies["customer_cookie"] != null)
            {
                customer cs;
                if (Session["customer"] == null)
                {
                    int id = int.Parse(Request.Cookies["customer_cookie"].Value);
                    cs = CustomerRepository.findCustomer(id);
                    Session["customer"] = cs;
                }
                else
                {
                    cs = (customer)Session["customer"];
                }

                //authorization
                if (cs.customerRole == "Custo")
                {
                    cart.Visible = true;
                    transHis.Visible = true;
                    cart.NavigateUrl = "~/Views/Cart/Cart.aspx?id=" + cs.customerId;
                    transHis.NavigateUrl = "~/Views/TransactionHistory/TransactionHistory.aspx?id=" + cs.customerId;
                }
                else if (cs.customerRole == "Admin")
                {
                    transReport.Visible = true;
                    transReport.NavigateUrl = "~/Views/TransactionReport/TransactionReport.aspx";
                }

                login.Visible = false;
                register.Visible = false;
                profile.Visible = true;
                logoutBtn.Visible = true;
                profile.NavigateUrl = "~/Views/Form/UpdateProfile.aspx?id=" + cs.customerId;
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;
            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddMinutes(-1);
            }
            Session.Remove("customer");

            resetNavbar();
            Response.Redirect("~/Views/Home/Home.aspx");
        }

        protected void resetNavbar()
        {
            cart.Visible = false;
            transHis.Visible = false;
            transReport.Visible = false;
            profile.Visible = false;
            logoutBtn.Visible = false;

            home.Visible = true;
            login.Visible = true;
            register.Visible = true;
        }
    }
}