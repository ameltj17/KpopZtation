using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KpopZtation.Models;
using KpopZtation.Repository;
using KpopZtation.Controllers;

namespace KpopZtation.Views.AlbumDetail
{
    public partial class AlbumDetail : System.Web.UI.Page
    {
        customer cs = null;
        int albumId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            cs = (customer)Session["customer"];
            string role = null;

            if (cs != null)
            {
                role = cs.customerRole;
                if (role == "Admin")
                {
                    addToCart.Visible = false;
                }
            }

            albumId = int.Parse(Request.QueryString["id"]);
            showAlbumDetail(albumId);
        }

        protected void showAlbumDetail(int albumId)
        {
            album a = AlbumRepository.findAlbum(albumId);
            albumImage.ImageUrl = "~/Images/Album/" + a.albumImage;
            nameLbl.Text = a.albumName;
            descContentLbl.Text = a.albumDescription;
            priceContentLbl.Text = "Rp " + a.albumPrice.ToString();
            stockContentLbl.Text = a.albumStock.ToString();
        }

        protected void addToCartBtn_Click(object sender, EventArgs e)
        {
            string qty = qtyTxt.Text.ToString();

            if (cs != null && cs.customerRole == "Custo")
            {
                errorMsgLbl.Text = AddCartController.addToCart(cs.customerId, albumId, qty);
                if (errorMsgLbl.Text.Equals(""))
                {
                    Response.Redirect("~/Views/Cart/Cart.aspx?id=" + cs.customerId);
                }
            }
            else
            {
                Response.Redirect("~/Views/Login/Login.aspx");
            }
        }
    }
}