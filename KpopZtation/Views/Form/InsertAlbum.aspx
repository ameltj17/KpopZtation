<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="InsertAlbum.aspx.cs" Inherits="KpopZtation.Views.Form.InsertAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="form" runat="server">
        <asp:Label ID="nameLbl" runat="server" Text="Album Name"></asp:Label><br/>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    </div>
    <div class="form" runat="server">
        <asp:Label ID="descLbl" runat="server" Text="Description"></asp:Label><br/>
        <asp:TextBox ID="descTxt" runat="server"></asp:TextBox>
    </div>
    <div class="form" runat="server">
        <asp:Label ID="priceLbl" runat="server" Text="Price"></asp:Label><br/>
        <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox>
    </div>
    <div class="form" runat="server">
        <asp:Label ID="stockLbl" runat="server" Text="Stock"></asp:Label><br/>
        <asp:TextBox ID="stockTxt" runat="server"></asp:TextBox>
    </div>
    <div class="form" runat="server">
        <asp:Label ID="imageLbl" runat="server" Text="Album Image"></asp:Label><br/>
        <asp:FileUpload ID="imageUpload" runat="server" />
    </div>
    <asp:Button ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click" />
    <br />
    <asp:Label ID="errorMsgLbl" runat="server" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptPlaceHolder" runat="server">
</asp:Content>
