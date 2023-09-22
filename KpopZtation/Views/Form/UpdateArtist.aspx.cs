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
    public partial class UpdateArtist : System.Web.UI.Page
    {
        int artistId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            artistId = int.Parse(Request.QueryString["id"]);
            showArtistInfo(artistId);
        }

        protected void showArtistInfo(int artistId)
        {
            artist artist = ArtistRepository.findArtistById(artistId);

            detailName.Text = artist.artistName.ToString();
            detailImg.ImageUrl = "~/Images/Artist/" + artist.artistImage.ToString();
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            string extension = System.IO.Path.GetExtension(imageUpload.FileName).ToLower();
            string image = name.ToLower().Replace(" ", "") + extension;
            float size = imageUpload.FileContent.Length;

            errorMsgLbl.Text = UpdateArtistController.updateArtist(artistId, name, image, extension, size);

            if (errorMsgLbl.Text.Equals(""))
            {
                ArtistRepository.deleteArtistImage(detailImg.ImageUrl);
                string folderPath = Server.MapPath("~/Images/Artist/");
                string filePath = Path.Combine(folderPath, image);
                imageUpload.SaveAs(filePath);

                Response.Redirect("~/Views/Form/UpdateArtist.aspx?id=" + artistId);
            }
        }
    }
}