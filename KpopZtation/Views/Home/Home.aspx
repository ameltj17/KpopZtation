<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtation.Views.Home.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
     <link rel="stylesheet" href="Home.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="banner" id="banner" runat="server" visible="true">
        <image class="slides" src="../../Images/merchBanner1.png"></image>
        <image class="slides" src="../../Images/merchBanner2.png"></image>
        <image class="slides" src="../../Images/merchBanner3.png"></image>
    </div>

    <div class="title">
        <h1>Welcome to the World of K-Pop</h1>
        <h3>Discover Your Favorite K-Pop Artists: Explore the Ultimate Lineup of Artists at KpopZtation!!</h3>
    </div>

    <div class="artistList">
        <asp:Table ID="artistTb" runat="server" CssClass="artistTable"></asp:Table>
    </div>

    <div>
        <asp:Label ID="errorMsgLbl" runat="server" Text=""></asp:Label>
    </div>

    <div class="insertBtnCtn" id="insertBtnCtn" runat="server" visible="false">
        <asp:Button ID="insertArtistBtn" CssClass="insertArtistBtn" runat="server" Text="Insert New Artist" OnClick="insertArtistBtn_Click"/>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptPlaceHolder" runat="server">
    <script>
        var slides = document.getElementsByClassName("slides");
        var currentSlide = 0;

        function showSlide() {
            for (var i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }

            currentSlide++;
            if (currentSlide >= slides.length) {
                currentSlide = 0;
            }

            slides[currentSlide].style.display = "block";

            setTimeout(showSlide, 2000);
        }
        showSlide();
    </script>
</asp:Content>
