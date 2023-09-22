using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KpopZtation.Controllers;

namespace KpopZtation.Views.Form
{
    public partial class InsertArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            string extension = System.IO.Path.GetExtension(imageUpload.FileName).ToLower();
            string image = name.ToLower().Replace(" ", "") + extension;
            float size = imageUpload.FileContent.Length;

            errorMsgLbl.Text = InsertArtistController.insertArtist(name, image, extension, size);

            if (errorMsgLbl.Text == "")
            {
                string folderPath = Server.MapPath("~/Images/Artist/");
                string filePath = Path.Combine(folderPath, image);
                imageUpload.SaveAs(filePath);

                Response.Redirect("~/Views/Home/Home.aspx");
            }
        }
    }
}