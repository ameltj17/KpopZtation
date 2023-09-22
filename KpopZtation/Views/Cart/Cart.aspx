<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="KpopZtation.Views.Cart.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
     <link rel="stylesheet" href="Cart.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="container">
        <h1>CART</h1>
        <div class="line-ctn">
            <div class="line"></div>
        </div>
        <div class="cartList" runat="server">
            <asp:Table ID="cartTb" runat="server" CssClass="cartTable"></asp:Table>
        </div>
        <div class="checkOut" id="checkOut" runat="server">
            <asp:Button ID="checkOutBtn" runat="server" Text="Check Out" OnClick="checkOutBtn_Click"/>
        </div>
        <div>
            <asp:Label ID="errorMsgLbl" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptPlaceHolder" runat="server">
</asp:Content>
