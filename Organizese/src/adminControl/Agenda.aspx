<%@ Page Title="" Language="C#" MasterPageFile="~/src/adminControl/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="Organizese.src.adminControl.Agenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divGeral">
        <div class="divLeft">
            <p class="title">Agenda</p>
            <asp:Repeater ID="rptAgenda" runat="server">
                <ItemTemplate>
                    <div class="divAgendamentos">
                        Data/Hora: <%#Eval("DATA")%>
                        <br/>
                        <%# 
                            Eval("IDUSER").ToString().Length >=1
                            ? "<a>Cliente:"+ Eval("IDUSER") +"-"+ Eval("NOME")+"</a>"
                            :"<a style='color:green; font-weight:bold;font-size:17px'>Disponível</a>" 
                        %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="divCenter">
            <p class="title">Atendimentos</p>
            <asp:Repeater runat="server" ID="rptAtendimentos">
                <ItemTemplate>
                    <div class="divAtendimentos">
                        Data/Hora: <%#Eval("DATA")%> 
                        <asp:Button runat="server" id="btnOpenAtd" CommandArgument='<%#Eval("ID")%>' OnClick="btnOpenAtd_Click"/>
                        <br/>
                        <%# 
                            "<a style='color:blue; font-weight:bold;font-size:17px'> Cliente: "+ Eval("IDUSER") +"-"+ Eval("NOME")+"</a>"
                        %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="divRight">
            <p class="title">Novo Horário</p>
            <asp:Calendar ID="dtAgenda" runat="server" SelectedDate="<%# DateTime.Today %>" Height="30%" Width="50%"></asp:Calendar>
            <asp:DropDownList ID="ddlHora" runat="server" CssClass="inputData" ></asp:DropDownList>
            <asp:Button ID="btnNovoHorario" runat="server" Text="Disponibilizar" CssClass="btn-success" OnClick="btnNovoHorario_Click" />
        </div>
    </div>

</asp:Content>
