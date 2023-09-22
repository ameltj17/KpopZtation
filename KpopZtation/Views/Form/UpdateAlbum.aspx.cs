using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using KpopZtation.Models;
using KpopZtation.Repository;
using KpopZtation.Controllers;

namespace KpopZtation.Views.Form
{
    public partial class UpdateAlbum : System.Web.UI.Page
    {
        int albumId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            albumId = int.Parse(Request.QueryString["id"]);
            showAlbumDetail(albumId);
        }

        protected void showAlbumDetail(int albumId)
        {
            album a = AlbumRepository.findAlbum(albumId);

            currNameLbl.Text = a.albumName;
            currDescLbl.Text = a.albumDescription;
            currPriceLbl.Text = a.albumPrice.ToString();
            currStockLbl.Text = a.albumStock.ToString();
            currImg.ImageUrl = "~/Images/Album/" + a.albumImage.ToString();
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            string desc = descTxt.Text;
            string price = priceTxt.Text;
            string stock = stockTxt.Text;

            string extension = System.IO.Path.GetExtension(imageUpload.FileName).ToLower();
            string image = name.ToLower().Replace(" ", "") + extension;
            float size = imageUpload.FileContent.Length;

            errorMsgLbl.Text = UpdateAlbumController.updateAlbumDetail(albumId, name, desc, price, stock, image, extension, size);

            if (errorMsgLbl.Text.Equals(""))
            {
                AlbumRepository.deleteAlbumImage(currImg.ImageUrl);
                string folderPath = Server.MapPath("~/Images/Album/");
                string filePath = Path.Combine(folderPath, image);
                imageUpload.SaveAs(filePath);

                Response.Redirect("~/Views/Form/UpdateAlbum.aspx?id=" + albumId);
            }
        }
    }
}