<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Lab_1_ST.History" MasterPageFile="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:label runat="server" text="ФИО" ID="name_lbl" Font-Bold="True" Font-Size="Large" ></asp:label><br/>
    <asp:label runat="server" text="СЧЕТ" ID="acoulr_lbl" Font-Italic="True"></asp:label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="5"> 
        <Columns>
            <asp:BoundField runat="server" DataField="id" HeaderText="ID"/>
            <asp:BoundField runat="server" DataField="type" HeaderText="Тип"/>
            <asp:BoundField runat="server" DataField="sum" HeaderText="Сумма"/>
            <asp:ButtonField runat="server" Text="Редактировать" HeaderText="Редактировать"/>
        </Columns> 
    </asp:GridView>
    <br />
    <asp:button runat="server" text="Создать" id="createButton" OnClick="createButton_Click" />
</asp:Content>
