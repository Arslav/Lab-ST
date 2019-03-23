<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryEdit.aspx.cs" Inherits="Lab_1_ST.HistoryEdit" MasterPageFile="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>Тип:
        <asp:DropDownList ID="type" runat="server" Height="20px" style="margin-left: 60px" Width="178px">
            <asp:ListItem Value="0">Приход</asp:ListItem>
            <asp:ListItem Value="1">Расход</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>Сумма:<asp:textbox runat="server" id="sum" style="margin-left: 44px" Width="173px"></asp:textbox></p>
    <asp:button runat="server" text="Удалить" id="delButton" Width="91px" OnClick="DelButton_Click" />
    &nbsp;<asp:button runat="server" text="Сохранить" id="createButton" OnClick="CreateButton_Click"/>
</asp:Content>
