<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KpopZtation.Views.Login.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link rel="stylesheet" href="Login.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
     <div class="loginForm">
        <div class="form">
            <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="emailTxt" runat="server" CssClass="textBox"></asp:TextBox>
        </div>
        <div class="form">
            <asp:Label ID="passLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="passTxt" runat="server" CssClass="textBox"></asp:TextBox>
        </div>
        <div class="form">
            <asp:CheckBox ID="rememberCbox" runat="server"></asp:CheckBox>
            <asp:Label ID="rememberLbl" runat="server" Text="Remember Me"></asp:Label>
        </div>
        <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />
        <asp:Label ID="errorMsgLbl" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptPlaceHolder" runat="server">
</asp:Content>
