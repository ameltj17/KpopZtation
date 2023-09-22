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
    public partial class InsertAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            int artistId = int.Parse(Request.QueryString["id"]);
            string name = nameTxt.Text;
            string desc = descTxt.Text;
            string price = priceTxt.Text;
            string stock = stockTxt.Text;

            string extension = System.IO.Path.GetExtension(imageUpload.FileName).ToLower();
            string image = name.ToLower().Replace(" ", "") + extension;
            float size = imageUpload.FileContent.Length;

            errorMsgLbl.Text = InsertAlbumController.insertAlbum(artistId, name, desc, price, stock, image, extension, size);

            if (errorMsgLbl.Text == "")
            {
                string folderPath = Server.MapPath("~/Images/Album/");
                string filePath = Path.Combine(folderPath, image);
                imageUpload.SaveAs(filePath);

                Response.Redirect("~/Views/ArtistDetail/ArtistDetail.aspx?id=" + artistId);
            }
        }
    }
}