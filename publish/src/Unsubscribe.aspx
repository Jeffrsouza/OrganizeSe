<%@ Page Title="" Language="C#" MasterPageFile="~/src/Home.Master" AutoEventWireup="true" CodeBehind="Unsubscribe.aspx.cs" Inherits="Organizese.src.Unsubscrib" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-top: 30%">
        <div style="display: flex; flex-direction: column; align-items: center; padding-bottom: 50%">
            <div class="alert alert-warning" role="alert">
                Deseja realmente se descadastrar das listas de e-mail da Organize-se?
            </div>
            &nbsp
            &nbsp
            &nbsp
            &nbsp
            <asp:Button runat="server" ID="btnUnsubscribe" class="btn btn-danger" Text="OK" OnClick="btnUnsubscribe_Click" />
                       &nbsp
                       &nbsp
              <div class="alert alert-success" role="alert">
  <asp:Label runat="server" ID="lblRetorno" visible="false"></asp:Label>
</div>
        </div>
    </div>
</asp:Content>
