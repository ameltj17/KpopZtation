<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="KpopZtation.Views.Form.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <h1>PROFILE</h1>
    <div class="currentProfile">
        <asp:Label ID="currNameLbl" runat="server" Text=""></asp:Label><br/>
        <asp:Label ID="currEmailLbl" runat="server" Text=""></asp:Label><br/>
        <asp:Label ID="currGenderLbl" runat="server" Text=""></asp:Label><br/>
        <asp:Label ID="currAddressLbl" runat="server" Text=""></asp:Label><br/>
        <asp:Label ID="currPassLbl" runat="server" Text=""></asp:Label><br/>
    </div>
    
    <div class="detail" runat="server">
        <asp:Label ID="nameLbl" runat="server" Text="Name"></asp:Label><br/>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    </div>
    <div class="detail" runat="server">
        <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label><br/>
        <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>
    </div>
    <div class="form_gender">
            <asp:Label ID="genderLbl" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButton ID="femaleBtn" runat="server" Text="Female" GroupName="genderGroup" />
            <asp:RadioButton ID="maleBtn" runat="server" Text="Male" GroupName="genderGroup" />
        </div>
    <div class="detail" runat="server">
        <asp:Label ID="addressLbl" runat="server" Text="Address"></asp:Label><br/>
        <asp:TextBox ID="addressTxt" runat="server"></asp:TextBox>
    </div>
    <div class="detail" runat="server">
        <asp:Label ID="passLbl" runat="server" Text="Password"></asp:Label><br/>
        <asp:TextBox ID="passTxt" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="submitBtn" runat="server" Text="Save Changes" OnClick="submitBtn_Click" />
    <br />
    <asp:Label ID="errorMsgLbl" runat="server" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptPlaceHolder" runat="server">
</asp:Content>
