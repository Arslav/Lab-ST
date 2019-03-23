<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Lab_1_ST.Account" MasterPageFile="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:label runat="server" text="ФИО" ID="name_lbl" Font-Bold="True" Font-Size="Large" ></asp:label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="5"> 
        <Columns>
            <asp:BoundField runat="server" DataField="id" HeaderText="ID Счета"/>
            <asp:BoundField runat="server" DataField="balance" HeaderText="Баланс"/>
            <asp:ButtonField Text="Просмотр истории" HeaderText="История" CommandName="history"/>
            <asp:ButtonField Text="Удалить" HeaderText="Удалить" CommandName="delete"/>
        </Columns> 
    </asp:GridView>
    <br />
    <asp:button runat="server" text="Создать" id="createButton" OnClick="CreateButton_Click"/>
</asp:Content>