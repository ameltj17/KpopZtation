using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KpopZtation.Controllers;

namespace KpopZtation.Views.Register
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void regisBtn_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text.ToString();
            string email = emailTxt.Text.ToString();
            string gender = getGenderValue();
            string address = addressTxt.Text.ToString();
            string password = passTxt.Text.ToString();

            errorMsgLbl.Text = RegisterController.register(name, email, gender, address, password);
            if (errorMsgLbl.Text.Equals(""))
            {
                Response.Redirect("~/Views/Login/Login.aspx");
            }
        }
    }
}