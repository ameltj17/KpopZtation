<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="KpopZtation.Views.ArtistDetail.ArtistDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link rel="stylesheet" href="ArtistDetail.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class ="artistDetail">
        <asp:Image ID="artistImage" CssClass="artistImage" runat="server" ImageUrl="~/Images/Artist/bibi.jpg" />
        <div class="artistName">
            <asp:Label ID="nameLbl" CssClass="nameLbl" runat="server" Text="Bibi"></asp:Label>
            <asp:Label ID="albumListLbl" CssClass="albumListLbl" runat="server" Text="'s Albums List"></asp:Label>
        </div>
    </div>
    <div class="line-ctn">
        <div class="line"></div>
    </div>
    <div class="albumList">
        <asp:Table ID="albumTb" runat="server" CssClass="albumTable"></asp:Table>
    </div>

    <div>
        <asp:Label ID="errorMsgLbl" runat="server" Text=""></asp:Label>
    </div>

    <div class="insertAlbumCtn" id="insertAlbumCtn" runat="server" visible="false">
        <asp:Button ID="insertAlbumBtn" runat="server" Text="Insert New Album" OnClick="insertAlbumBtn_Click"/>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptPlaceHolder" runat="server">
</asp:Content>
