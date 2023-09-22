using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KpopZtation.Models;
using KpopZtation.Repository;
using KpopZtation.Handler;

namespace KpopZtation.Views.Home
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            customer cs = (customer)Session["customer"];

            if (cs == null && Request.Cookies["customer_cookie"] != null)
            {
                int customerId = int.Parse(Request.Cookies["customer_cookie"].Value);
                cs = CustomerRepository.findCustomer(customerId);
            }
            if (cs != null)
            {
                if (cs.customerRole == "Admin")
                {
                    banner.Visible = false;
                    insertBtnCtn.Visible = true;
                    showArtistAdmin();
                }
                else
                {
                    showArtistCustomer();
                }
            }
            else
            {
                showArtistCustomer();
            }
        }

        protected void showArtistAdmin()
        {
            List<artist> artists = ArtistRepository.getArtistAlphabeticalOrder();

            TableRow row = null;

            for (int i = 0; i < artists.Count; i++)
            {
                if (i % 4 == 0)
                {
                    row = new TableRow();
                    artistTb.Rows.Add(row);
                }

                TableCell imageCell = new TableCell();
                imageCell.Style["text-align"] = "center";
                Image artistImage = new Image();
                artistImage.ImageUrl = "~/Images/Artist/" + artists[i].artistImage;
                artistImage.Style["width"] = "192px";
                artistImage.Style["height"] = "193px";
                artistImage.Style["object-fit"] = "cover";
                artistImage.Style["border-radius"] = "26px";
                artistImage.CssClass = "artistImg";
                imageCell.Controls.Add(artistImage);

                Panel container = new Panel();
                container.CssClass = "artistDetail-ctn";

                Literal artistName = new Literal();
                artistName.Text = "<p>" + artists[i].artistName + "</p>";
                container.Controls.Add(artistName);

                Button readMoreButton = new Button();
                readMoreButton.Text = "Read More";
                readMoreButton.CssClass = "readMoreBtn btn";
                readMoreButton.CommandArgument = artists[i].artistId.ToString();
                readMoreButton.Command += readMorebtn_OnClick;
                container.Controls.Add(readMoreButton);

                Button updateButton = new Button();
                updateButton.Text = "Update";
                updateButton.CssClass = "updateBtn btn";
                updateButton.CommandArgument = artists[i].artistId.ToString();
                updateButton.Command += updateBtn_OnClick;
                container.Controls.Add(updateButton);

                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.CssClass = "deleteBtn btn";
                deleteButton.CommandArgument = artists[i].artistId.ToString();
                deleteButton.Command += deleteBtn_OnClick;
                container.Controls.Add(deleteButton);

                imageCell.Controls.Add(container);
                row.Cells.Add(imageCell);
            }
        }

        protected void showArtistCustomer()
        {
            List<artist> artists = ArtistRepository.getArtistAlphabeticalOrder();

            TableRow row = null;

            for (int i = 0; i < artists.Count; i++)
            {
                if (i % 4 == 0)
                {
                    row = new TableRow();
                    artistTb.Rows.Add(row);
                }

                TableCell imageCell = new TableCell();
                imageCell.Style["text-align"] = "center";
                Image artistImage = new Image();
                artistImage.ImageUrl = "~/Images/Artist/" + artists[i].artistImage;
                artistImage.Style["width"] = "192px";
                artistImage.Style["height"] = "193px";
                artistImage.Style["object-fit"] = "cover";
                artistImage.Style["border-radius"] = "26px";
                artistImage.CssClass = "artistImg";
                imageCell.Controls.Add(artistImage);

                Panel container = new Panel();
                container.CssClass = "artistDetail-ctn";

                Literal artistName = new Literal();
                artistName.Text = "<p>" + artists[i].artistName + "</p>";
                container.Controls.Add(artistName);

                Button readMoreButton = new Button();
                readMoreButton.Text = "Read More";
                readMoreButton.CssClass = "readMoreBtn btn";
                readMoreButton.CommandArgument = artists[i].artistId.ToString();
                readMoreButton.Command += readMorebtn_OnClick;
                container.Controls.Add(readMoreButton);

                imageCell.Controls.Add(container);
                row.Cells.Add(imageCell);
            }
        }

        protected void readMorebtn_OnClick(object sender, CommandEventArgs e)
        {
            int artistId = int.Parse(e.CommandArgument.ToString());
            Response.Redirect("~/Views/ArtistDetail/ArtistDetail.aspx?id=" + artistId);
        }

        protected void updateBtn_OnClick(object sender, CommandEventArgs e)
        {
            int artistId = int.Parse(e.CommandArgument.ToString());
            Response.Redirect("~/Views/Form/UpdateArtist.aspx?id=" + artistId);
        }

        protected void deleteBtn_OnClick(object sender, CommandEventArgs e)
        {
            int artistId = int.Parse(e.CommandArgument.ToString());
            errorMsgLbl.Text = ArtistHandler.deleteArtist(artistId);

            if (errorMsgLbl.Text.Equals(""))
            {
                Response.Redirect("~/Views/Home/Home.aspx");
            }
        }

        protected void insertArtistBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Form/InsertArtist.aspx");
        }
    }
}