<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="KpopZtation.Views.AlbumDetail.AlbumDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link rel="stylesheet" href="AlbumDetail.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
     <div class="container">
        <div class ="albumProfile">
            <asp:Image ID="albumImage" CssClass="albumImage" runat="server" ImageUrl="~/Images/Album/omg.jpg" />
            <div class="albumName">
                <asp:Label ID="nameLbl" CssClass="nameLbl" runat="server" Text="Ditto"></asp:Label>
            </div>
        </div>
        <div class="line-ctn">
            <div class="line"></div>
        </div>
        <div class="albumDetail">
            <div class="desc">
                <asp:Label ID="descTitleLbl" CssClass="descTitleLbl" runat="server" Text="Description:"></asp:Label>
                <asp:Label ID="descContentLbl" CssClass="content" runat="server" Text="Released in April 2021. The pop and R&B EP contains five tracks showcasing BIBI’s vocals in multiple forms over mainly trap beats."></asp:Label>
            </div>
            <div class="desc">
                <asp:Label ID="priceTitleLbl" CssClass="priceTitleLbl" runat="server" Text="Price:"></asp:Label>
                <asp:Label ID="priceContentLbl" CssClass="content" runat="server" Text="Rp 200000"></asp:Label>
            </div>
            <div class="desc">
                <asp:Label ID="stockTitleLbl" CssClass="stockTitleLbl" runat="server" Text="Stock:"></asp:Label>
                <asp:Label ID="stockContentLbl" CssClass="content" runat="server" Text="30"></asp:Label>
            </div>
        </div>
        <div class="addToCart" id="addToCart" runat="server">
            <asp:Label ID="qtyTitleLbl" CssClass="qtyTitleLbl" runat="server" Text="Qty:"></asp:Label>
            <asp:TextBox ID="qtyTxt" CssClass="qtyTxtBox" runat="server" Text="0"></asp:TextBox>
            <asp:Button ID="addToCartBtn" CssClass="addToCartBtn" runat="server" Text="Add to Cart" OnClick="addToCartBtn_Click" />
        </div>
        <div class="errorMsg">
            <asp:Label ID="errorMsgLbl" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptPlaceHolder" runat="server">
</asp:Content>
