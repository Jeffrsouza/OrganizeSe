<%@ Page Title="" Language="C#" MasterPageFile="~/src/adminControl/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="Organizese.src.adminControl.Chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
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
                    <asp:BoundField DataField="EMAIL" HeaderText="email" />
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
            <div class="div-chat-middle">
                <a class="msg-header">Cliente: </a><asp:Label class="msg-header" runat="server" ID="lblProtocol"  />
                &nbsp&nbsp
                 <a class="msg-header">Protocolo: </a><asp:Label class="msg-header" runat="server" ID="lblNomeClie" />                
                <div class="div-chat-msg">
                    <asp:Repeater runat="server" ID="rptMsg">
                        <ItemTemplate>
                            <div class='<%# Eval("TIPOREM").ToString() =="A" ? "msgChatr": "msgChatl" %>'>
                                <div id='<%# Eval("MSG") %>' class='<%# Eval("TIPOREM").ToString() =="A" ? "msgChatSend": "msgChatRecive" %>'>
                                    <div style="margin: 15px">
                                        <a class="msg-nome"><%# Eval("TIPOREM").ToString() == "A"  ?  Eval("NOME_ADMIN") : Eval("NOME_USER") %> </a>
                                        <br />
                                        <a  class='<%# Eval("TIPOREM").ToString() =="A" ? "msg-bodyAdmin": "msg-bodyClient" %>' ><%# Eval("MSG") %></a>
                                        <br />
                                        <a  class="msg-data"><%# Eval("DATA") %></a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="div-chat-box">
                    &nbsp&nbsp
                    <asp:TextBox ID="txtMsg" runat="server" class="txtMsg" TextMode="MultiLine" Rows="3" MaxLength="200" Enabled="False"></asp:TextBox>
                    &nbsp&nbsp&nbsp
                    <asp:Button ID="btnEnviar" OnClick="btnEnviar_Click" class="btnMsg btn btn-success" runat="server" Text="Enviar" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
