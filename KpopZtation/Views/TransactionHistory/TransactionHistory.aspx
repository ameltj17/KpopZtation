<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="KpopZtation.Views.TransactionHistory.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link rel="stylesheet" href="TransactionHistory.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <h1>Transaction History</h1>
    <div class="line-ctn">
        <div class="line"></div>
    </div>
    <div class="transactionList">
        <asp:GridView ID="transactionGridView" runat="server" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="transactionId" HeaderText="Transaction Id" SortExpression="transactionId" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="transactionHeader.transactionDate" HeaderText="Transaction Date" SortExpression="transactionHeader.transactionDate" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="transactionHeader.customer.customerName" HeaderText="Customer Name" SortExpression="transactionHeader.customer.customerName" ItemStyle-HorizontalAlign="Center"/>
                <asp:HyperLinkField HeaderText="Courier" Text="On Process" />
                <asp:TemplateField HeaderText="Album's Image" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Image ID="albumImage" runat="server" ImageUrl='<%# "~/Images/Album/" + Eval("album.albumImage") %>' Width="100" Height="100"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="album.albumName" HeaderText="Album's Name" SortExpression="album.albumName" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="qty" HeaderText="Qty" SortExpression="qty" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="album.albumPrice" HeaderText="Price" SortExpression="album.albumPrice" ItemStyle-HorizontalAlign="Center"/>
            </Columns>
        </asp:GridView>
    </div>
    <div class="line-ctn">
        <div class="line"></div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scriptPlaceHolder" runat="server">
</asp:Content>
