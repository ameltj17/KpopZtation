<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KpopZtation.Views.Register.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link rel="stylesheet" href="Register.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
     <div class="regisForm">
        <div class="form">
            <asp:Label ID="nameLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="nameTxt" runat="server" CssClass="textBox"></asp:TextBox>
        </div>
        <div class="form">
            <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="emailTxt" runat="server" CssClass="textBox"></asp:TextBox>
        </div>
        <div class="form_gender">
            <asp:Label ID="genderLbl" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButton ID="femaleBtn" runat="server" Text="Female" GroupName="genderGroup" />
            <asp:RadioButton ID="maleBtn" runat="server" Text="Male" GroupName="genderGroup" />
        </div>
        <div class="form">
            <asp:Label ID="addressLbl" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="addressTxt" runat="server" CssClass="textBox"></asp:TextBox>
        </div>
        <div class="form">
            <asp:Label ID="passLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="passTxt" runat="server" CssClass="textBox"></asp:TextBox>
        </div>
        <asp:Button ID="regisBtn" runat="server" Text="Register" OnClick="regisBtn_Click" /><br/>
        <asp:Label ID="errorMsgLbl" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptPlaceHolder" runat="server">
</asp:Content>
