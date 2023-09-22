using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KpopZtation.Controllers;
using KpopZtation.Models;
using KpopZtation.Repository;

namespace KpopZtation.Views.Form
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        int customerId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            customerId = int.Parse(Request.QueryString["id"]);
            showCustomerProfile(customerId);
        }

        protected void showCustomerProfile(int customerId)
        {
            customer c = CustomerRepository.findCustomer(customerId);
            currNameLbl.Text = c.customerName;
            currEmailLbl.Text = c.customerEmail;
            currGenderLbl.Text = c.customerGender;
            currAddressLbl.Text = c.customerAddress;
            currPassLbl.Text = c.customerPassword;
        }

        public string getGenderValue()
        {
            string selectedGender = "";

            if (femaleBtn.Checked)
            {
                selectedGender = "Female";
            }
            else if (maleBtn.Checked)
            {
                selectedGender = "Male";
            }
            return selectedGender;
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            string email = emailTxt.Text;
            string gender = getGenderValue();
            string address = addressTxt.Text;
            string pass = passTxt.Text;

            errorMsgLbl.Text = UpdateProfileController.updateProfile(customerId, name, email, gender, address, pass);
            if (errorMsgLbl.Text.Equals(""))
            {
                Response.Redirect("~/Views/Form/UpdateProfile.aspx?id=" + customerId);
            }
        }
    }
}