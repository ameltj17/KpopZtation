using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KpopZtation.Models;
using KpopZtation.Repository;
using KpopZtation.Handler;

namespace KpopZtation.Views.ArtistDetail
{
    public partial class ArtistDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            customer cs = (customer)Session["customer"];
            string role = null;

            if (cs == null && Request.Cookies["customer_cookie"] != null)
            {
                int customerId = int.Parse(Request.Cookies["customer_cookie"].Value);
                cs = CustomerRepository.findCustomer(customerId); ;
            }
            if (cs != null)
            {
                role = cs.customerRole;
                if (role == "Admin")
                {
                    insertAlbumCtn.Visible = true;
                }
            }

            int artistId = int.Parse(Request.QueryString["id"]);
            showArtistDetail(artistId);
            showAlbumList(artistId, role);
        }

        protected void showArtistDetail(int artistId)
        {
            artist a = ArtistRepository.findArtistById(artistId);

            artistImage.ImageUrl = "~/Images/Artist/" + a.artistImage;
            nameLbl.Text = a.artistName;
        }

        protected void showAlbumList(int artistId, string csRole)
        {
            List<album> albums = AlbumRepository.getAlbumsByArtistId(artistId);

            TableRow row = null;

            for (int i = 0; i < albums.Count; i++)
            {
                row = new TableRow();
                albumTb.Rows.Add(row);

                //First cell : Image
                TableCell imageCell = new TableCell();
                Image albumImage = new Image();
                albumImage.ImageUrl = "~/Images/Album/" + albums[i].albumImage;
                albumImage.CssClass = "albumImage";
                albumImage.Style["margin-right"] = "30px";
                imageCell.Controls.Add(albumImage);
                row.Cells.Add(imageCell);

                //Second cell : Description
                TableCell descriptionCell = new TableCell();
                Label nameLabel = new Label();
                nameLabel.Text = albums[i].albumName + " (Stock Left: " + albums[i].albumStock + " )";
                nameLabel.CssClass = "albumNameLbl";
                descriptionCell.Controls.Add(nameLabel);

                LiteralControl lineBreak = new LiteralControl("<br/>");
                descriptionCell.Controls.Add(lineBreak);

                Label descriptionPLabel = new Label();
                descriptionPLabel.Text = albums[i].albumDescription;
                descriptionPLabel.CssClass = "albumDescLbl";
                descriptionCell.Controls.Add(descriptionPLabel);
                row.Cells.Add(descriptionCell);

                //Third Cell : Action Button
                TableCell actionCell = new TableCell();
                Button detailsButton = new Button();
                detailsButton.Text = "Details";
                detailsButton.CommandArgument = albums[i].albumId.ToString();
                detailsButton.Command += detailsBtn_OnClick;
                detailsButton.CssClass = "detailsBtn";
                actionCell.Controls.Add(detailsButton);

                if (csRole == "Admin")
                {
                    Button updateButton = new Button();
                    updateButton.Text = "Update";
                    updateButton.CssClass = "updateBtn btn";
                    updateButton.CommandArgument = albums[i].albumId.ToString();
                    updateButton.Command += updateBtn_OnClick;
                    actionCell.Controls.Add(updateButton);

                    Button deleteButton = new Button();
                    deleteButton.Text = "Delete";
                    deleteButton.CssClass = "deleteBtn btn";
                    deleteButton.CommandArgument = albums[i].albumId.ToString();
                    deleteButton.Command += deleteBtn_OnClick;
                    actionCell.Controls.Add(deleteButton);
                }
                actionCell.Style["padding-right"] = "20px";
                row.Cells.Add(actionCell);

                //Fourth Cell : Price + Add to cart
                TableCell buttonCell = new TableCell();
                Label priceLabel = new Label();
                priceLabel.CssClass = "albumPriceLbl";
                priceLabel.Text = "Rp " + albums[i].albumPrice.ToString();
                buttonCell.Controls.Add(priceLabel);
                row.Cells.Add(buttonCell);
                row.Style["height"] = "200px";
                albumTb.Rows.Add(row);
            }
        }

        protected void detailsBtn_OnClick(object sender, CommandEventArgs e)
        {
            int albumId = int.Parse(e.CommandArgument.ToString());
            Response.Redirect("~/Views/AlbumDetail/AlbumDetail.aspx?id=" + albumId);
        }

        protected void updateBtn_OnClick(object sender, CommandEventArgs e)
        {
            int albumId = int.Parse(e.CommandArgument.ToString());
            Response.Redirect("~/Views/Form/UpdateAlbum.aspx?id=" + albumId);
        }
        protected void deleteBtn_OnClick(object sender, CommandEventArgs e)
        {
            int albumId = int.Parse(e.CommandArgument.ToString());
            errorMsgLbl.Text = AlbumHandler.deleteAlbum(albumId);

            if (errorMsgLbl.Text.Equals(""))
            {
                int artistId = int.Parse(Request.QueryString["id"]);
                Response.Redirect("~/Views/ArtistDetail/ArtistDetail.aspx?id=" + artistId);
            }
        }

        protected void insertAlbumBtn_Click(object sender, EventArgs e)
        {
            int artistId = int.Parse(Request.QueryString["id"]);
            Response.Redirect("~/Views/Form/InsertAlbum.aspx?id=" + artistId);
        }
    }
}