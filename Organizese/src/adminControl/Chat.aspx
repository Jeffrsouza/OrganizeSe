<%@ Page Title="" Language="C#" MasterPageFile="~/src/adminControl/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="Organizese.src.adminControl.Chat" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scmChat" runat="server" EnablePageMethods='true'></asp:ScriptManager>
    <div>
        <br />
        <!-- Div superior com os protocolos -->
        <div class="div-grid-protocol">
            <asp:GridView ID="gvProtocol" runat="server" OnRowCommand="gvProtocol_RowCommand"
                CssClass="table table-striped" EnableModelValidation="True"
                AllowPaging="True" ShowFooter="false" BackColor="White" BorderColor="#999"
                BorderStyle="none" BorderWidth="2px" CellPadding="2" ForeColor="Black"
                GridLines="Horizontal"
                AutoGenerateColumns="false"
                PagerSettings-Position="Top" PagerSettings-Visible="False" PageSize="999">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Protocolo" />
                    <asp:BoundField DataField="NOME_ADMIN" HeaderText="Admin" />
                    <asp:BoundField DataField="NOME_USER" HeaderText="Cliente" />
                    <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                    <asp:BoundField DataField="DATA" HeaderText="Data" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnSelectProtocolo" runat="server" CausesValidation="false" CommandName="loadChat"
                                Text="Abrir" CommandArgument='<%# Eval("ID")+","+Eval("NOME_USER") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />

        <!-- Div com os os dados do protocolo-->
        <div class="div-chat-details">
            &nbsp&nbsp          
            <div class="div-chat-left">
                Anotações
            </div>
            &nbsp&nbsp
           <div class="div-chat-right">
               Calendário
           </div>
            &nbsp&nbsp

            <!-- Div do chat -->
            <div class="div-chat-middle">
                <a class="msg-header">Protocolo: </a>
                <asp:Label class="msg-header" runat="server" ID="lblProtocol" />
                &nbsp&nbsp
                 <a class="msg-header">Cliente: </a>
                <asp:Label class="msg-header" runat="server" ID="lblNomeClie" />
                <div id="divchat" class="div-chat-msg">
                    <asp:UpdatePanel ID="panelChat" runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="timerChat" runat="server" OnTick="timerChat_Tick" Interval="5000"></asp:Timer>
                            <asp:Repeater runat="server" ID="rptMsg">
                                <ItemTemplate>
                                    <div class='<%# Eval("TIPO").ToString() =="A" ? "msgChatr": "msgChatl" %>'>
                                        <div id='<%# Eval("MSG") %>' class='<%# Eval("TIPO").ToString() =="A" ? "msgChatSend": "msgChatRecive" %>'>
                                            <div style="margin: 15px">
                                                <a class="msg-nome"><%# Eval("TIPO").ToString() == "A"  ?  Eval("NOME_ADMIN") : Eval("NOME_USER") %> </a>
                                                <br />
                                                <div class="msg-bodyChat">
                                                    <%# Eval("MSG") %>
                                                </div>
                                                <br />
                                                <a class="msg-data"><%# Eval("DATA") %></a>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Label runat="server" Text="==> " ID="lbl"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="div-chat-box">
                    &nbsp&nbsp
                    <asp:TextBox ID="txtMsg" runat="server" class="txtMsg" TextMode="MultiLine" Rows="3" MaxLength="250" Enabled="False"></asp:TextBox>
                    &nbsp&nbsp&nbsp
                    <asp:Button ID="btnEnviar" OnClick="btnEnviar_Click" class="btnMsg btn btn-success" runat="server" Text="Enviar" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        window.onload = function scroll() {
            var objScrDiv = document.getElementById("divchat");
            objScrDiv.scrollTop = objScrDiv.scrollHeight;
        }
    </script>
</asp:Content>
