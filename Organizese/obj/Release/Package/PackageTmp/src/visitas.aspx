<%@ Page Title="" Language="C#" MasterPageFile="~/src/ControlPanel.Master" AutoEventWireup="true" CodeBehind="visitas.aspx.cs" Inherits="Organizese.src.visitas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvVisitas" runat="server"
         CssClass="table table-striped" EnableModelValidation="True" 
        AllowPaging="True" ShowFooter="True"  BackColor="White" BorderColor="Black" 
        BorderStyle="None" BorderWidth="5px" CellPadding="2" ForeColor="Black" 
        GridLines="Horizontal" 
        PagerSettings-Position="Top" PagerSettings-Visible="False" PageSize="99999999"></asp:GridView>
</asp:Content>

