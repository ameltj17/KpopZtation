<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="UpdateArtist.aspx.cs" Inherits="KpopZtation.Views.Form.UpdateArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="detail" runat="server">
        <asp:Label ID="detailName" runat="server" Text=""></asp:Label><br/>
        <asp:Image ID="detailImg" runat="server" /><br/>
    </div>
    <div class="form" runat="server">
        <asp:Label ID="nameLbl" runat="server" Text="Artist Name"></asp:Label>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    </div>
    <div class="form" runat="server">
        <asp:Label ID="imageLbl" runat="server" Text="Artist Image"></asp:Label><br/>
        <asp:FileUpload ID="imageUpload" runat="server" />
    </div>
    <asp:Button ID="submitBtn" runat="server" Text="Save Changes" OnClick="submitBtn_Click" />
    <br />
    <asp:Label ID="errorMsgLbl" runat="server" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptPlaceHolder" runat="server">
</asp:Content>
