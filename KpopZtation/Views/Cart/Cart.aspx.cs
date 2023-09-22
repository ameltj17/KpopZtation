using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KpopZtation.Repository;
using KpopZtation.Models;
using KpopZtation.Handler;

namespace KpopZtation.Views.Cart
{
    public partial class Cart : System.Web.UI.Page
    {
        int customerId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            customerId = int.Parse(Request.QueryString["id"]);
            showCartList(customerId);
        }

        protected void showCartList(int customerId)
        {
            List<cart> cart = CartRepository.getAllCart(customerId);

            if(cart.Count == 0)
            {
                errorMsgLbl.Text = "Cart is empty";
            }
            else
            {
                TableRow row = null;

                for (int i = 0; i < cart.Count; i++)
                {
                    row = new TableRow();
                    cartTb.Rows.Add(row);

                    album album = AlbumRepository.findAlbum(cart[i].albumId);

                    //First cell : Image
                    TableCell imageCell = new TableCell();
                    Image albumImage = new Image();
                    albumImage.ImageUrl = "~/Images/Album/" + album.albumImage;
                    albumImage.CssClass = "albumImage";
                    albumImage.Style["margin-right"] = "30px";
                    imageCell.Controls.Add(albumImage);
                    row.Cells.Add(imageCell);

                    //Second cell : Description
                    TableCell descriptionCell = new TableCell();
                    Label nameLabel = new Label();
                    nameLabel.Text = album.albumName;
                    nameLabel.CssClass = "nameLabel";
                    descriptionCell.Controls.Add(nameLabel);

                    LiteralControl lineBreak = new LiteralControl("<br/>");
                    descriptionCell.Controls.Add(lineBreak);

                    Label descriptionPLabel = new Label();
                    descriptionPLabel.Text = album.albumDescription;
                    descriptionPLabel.CssClass = "descLbl";
                    descriptionCell.Controls.Add(descriptionPLabel);
                    row.Cells.Add(descriptionCell);

                    //Third cell : Quantity
                    TableCell qtyCell = new TableCell();
                    Label qtyLabel = new Label();
                    qtyLabel.Text = "Qty: " + cart[i].qty.ToString();
                    qtyLabel.CssClass = "qtyLabel";
                    qtyCell.Controls.Add(qtyLabel);
                    row.Cells.Add(qtyCell);

                    //Fourth cell : Price
                    TableCell priceCell = new TableCell();
                    Label priceLabel = new Label();
                    priceLabel.Text = album.albumPrice.ToString();
                    priceLabel.CssClass = "priceLabel";
                    priceCell.Controls.Add(priceLabel);
                    row.Cells.Add(priceCell);

                    //Fifth cell : Remove Button
                    TableCell btnCell = new TableCell();
                    Button removeBtn = new Button();
                    removeBtn.Text = "Remove";
                    removeBtn.CssClass = "removeBtn";
                    removeBtn.CommandArgument = album.albumId.ToString();
                    removeBtn.Command += removeBtn_OnClick;
                    btnCell.Controls.Add(removeBtn);
                    row.Style["height"] = "200px";
                    row.Cells.Add(btnCell);
                }
            }
        }

        protected void removeBtn_OnClick(object sender, CommandEventArgs e)
        {
            int albumId = int.Parse(e.CommandArgument.ToString());
            CartRepository.removeCart(customerId, albumId);
            Response.Redirect("~/Views/Cart/Cart.aspx?id=" + customerId);
        }

        protected void checkOutBtn_Click(object sender, EventArgs e)
        {
            errorMsgLbl.Text = CartHandler.checkOut(customerId);
            if (errorMsgLbl.Text.Equals(""))
            {
                Response.Redirect("~/Views/TransactionHistory/TransactionHistory.aspx?id=" + customerId);
            }
        }
    }
}