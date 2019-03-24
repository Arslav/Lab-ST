<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientEditor.aspx.cs" Inherits="Lab_1_ST.ClientEditor" MasterPageFile="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>ФИО: <asp:textbox runat="server" id="name" style="margin-left: 63px" Width="170px"></asp:textbox></p>
    <p>Возраст: <asp:textbox runat="server" id="age" style="margin-left: 41px" Width="173px"></asp:textbox></p>
    <p>Место работы: <asp:textbox runat="server" id="work" Width="173px"></asp:textbox></p>
    <asp:button runat="server" text="Удалить" id="delButton" Width="91px" OnClick="DelButton_Click" />
    &nbsp;<asp:button runat="server" text="Сохранить" id="createButton"  OnClick="CreateButton_Click"/>
</asp:Content>