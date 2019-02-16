<%@ Page Title="" Language="C#" MasterPageFile="~/src/ControlPanel.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="Organizese.src.ControlPanel2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:20px">
        <div>
        <p>
           * E = Apenas Lista de e-mail <br/> * F = Free <br/> * P = Premium <br/> * C = Cancelado <br/>
        </p>       
    </div>
    <asp:GridView runat="server" ID="gvDados"
        CssClass="table table-striped" EnableModelValidation="True" 
        AllowPaging="True" ShowFooter="True"  BackColor="White" BorderColor="Black" 
        BorderStyle="None" BorderWidth="5px" CellPadding="2" ForeColor="Black" 
        GridLines="Horizontal" 
        PagerSettings-Position="Top" PagerSettings-Visible="False" PageSize="99999999">
                
    </asp:GridView>
    </div>
</asp:Content>
