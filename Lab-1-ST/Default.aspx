<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab_1_ST._Default" MasterPageFile="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="5" > 
        <Columns>
            <asp:BoundField runat="server" DataField="id" HeaderText="ID"/>
            <asp:BoundField runat="server" DataField="name" HeaderText="Ф.И.О"/> 
            <asp:BoundField runat="server" DataField="age" HeaderText="Возраст"/> 
            <asp:BoundField runat="server" DataField="work" HeaderText="Место работы"/> 
            <asp:ButtonField Text="Просмотр счетов" HeaderText="Счета" CommandName="view"/>
            <asp:ButtonField Text="Редактировать" HeaderText="Редактировать" CommandName="edit"/>
        </Columns> 
    </asp:GridView>
    <br />
    <asp:button runat="server" text="Создать" ID="Button" OnClick="Button_Click" />
</asp:Content>