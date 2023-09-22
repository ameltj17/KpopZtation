<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="InsertArtist.aspx.cs" Inherits="KpopZtation.Views.Form.InsertArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="form" runat="server">
        <asp:Label ID="nameLbl" runat="server" Text="Artist Name"></asp:Label>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    </div>
    <div class="form" runat="server">
        <asp:Label ID="imageLbl" runat="server" Text="Artist Image"></asp:Label><br/>
        <asp:FileUpload ID="imageUpload" runat="server" />
    </div>
    <asp:Button ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click" />
    <br />
    <asp:Label ID="errorMsgLbl" runat="server" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptPlaceHolder" runat="server">
</asp:Content>
