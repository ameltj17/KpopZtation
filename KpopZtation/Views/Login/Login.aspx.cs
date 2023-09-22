using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KpopZtation.Models;
using KpopZtation.Repository;
using KpopZtation.Controllers;

namespace KpopZtation.Views.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string email = emailTxt.Text.ToString();
            string password = passTxt.Text.ToString();
            bool remember = rememberCbox.Checked;

            errorMsgLbl.Text = LoginController.login(email, password);

            if (errorMsgLbl.Text.Equals(""))
            {
                customer cs = CustomerRepository.findCustomer(email, password);
                Session["customer"] = cs;

                if (remember)
                {
                    HttpCookie cookie = new HttpCookie("customer_cookie");
                    cookie.Value = cs.customerId.ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }

                Response.Redirect("~/Views/Home/Home.aspx");
            }
        }
    }
}