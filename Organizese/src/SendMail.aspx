<%@ Page Title="" Language="C#" MasterPageFile="~/src/ControlPanel.Master" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="Organizese.src.SendMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button Text="Enviar" ID="sendMail" runat="server" OnClick="sendMail_Click"/>
    <img src="http://www.organizeseop.com.br/src/img/imgRight.jpg" style="width:250px; height:250px; border-radius:15px"/>
    <asp:Label runat="server" ID="lblRetorno" Text="" />
</asp:Content>
