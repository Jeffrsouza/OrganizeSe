<%@ Page Title="" Language="C#" MasterPageFile="~/src/ControlPanel.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="Organizese.src.ControlPanel2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="smgCtrlPnl" runat="server" EnablePageMethods='true'></asp:ScriptManager>
    <asp:Timer ID="timeChat" runat="server" Interval="5000" OnTick="timeChat_Tick" Enabled="False"></asp:Timer>
    <div class="divGeral">
        <nav class="nav_tabs">
            <input type="button" value="Chat" id='btn1' class="nav_item" onclick="alterScreen(1)" />
            <input type="button" value="Inscritos" id='btn2' class="nav_item" onclick="alterScreen(2)" />
        </nav>
        <div style="margin: 20px">
            <div class="sctChat" id="screen1">
                <asp:GridView ID="gvProt" runat="server" OnRowCommand="gvProt_RowCommand"
                    CssClass="table table-striped" EnableModelValidation="True"
                    AllowPaging="True" ShowFooter="True" BackColor="White" BorderColor="Black"
                    BorderStyle="None" BorderWidth="5px" CellPadding="2" ForeColor="Black"
                    GridLines="Horizontal"
                    AutoGenerateColumns="false"
                    PagerSettings-Position="Top" PagerSettings-Visible="False" PageSize="99999999">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Customer ID" />
                        <asp:BoundField DataField="NOME_ADMIN" HeaderText="Customer ID" />
                        <asp:BoundField DataField="NOME_USER" HeaderText="Customer ID" />
                        <asp:BoundField DataField="EMAIL" HeaderText="Customer ID" />
                        <asp:BoundField DataField="DATA" HeaderText="Customer ID" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="btnSelectProtocolo" runat="server" CausesValidation="false" CommandName="getProtocol"
                                    Text="Abrir" CommandArgument='<%# Eval("ID") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Repeater runat="server" ID="rptMsg">
                    <ItemTemplate>
                        <div class='<%# Eval("TIPOREM").ToString() =="A" ? "msgChatr": "msgChatl" %>'>
                            <div id='<%# Eval("MSG") %>' class='<%# Eval("TIPOREM").ToString() =="A" ? "msgChatSend": "msgChatRecive" %>'>
                                <div style="margin: 15px">
                                    <p><%# Eval("TIPOREM").ToString() == "A"  ?  Eval("NOME_ADMIN") : Eval("NOME_USER") %> :</p>
                                    <p><%# Eval("MSG") %></p>
                                    <p><%# Eval("DATA") %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:TextBox ID="txtMsg" runat="server"  width="400px" Height="50px" TextMode="MultiLine" Rows="5" ></asp:TextBox>
                <asp:Button ID="btnEnviar" onClick="btnEnviar_Click" runat="server" Text="Enviar"/>
            </div>
            <div id="screen2" style="display: none">
                <div>
                    <p>
                        * E = Apenas Lista de e-mail
                <br />
                        * F = Free
                <br />
                        * P = Premium
                <br />
                        * C = Cancelado
                <br />
                    </p>
                </div>
                <asp:GridView runat="server" ID="gvDados"
                    CssClass="table table-striped" EnableModelValidation="True"
                    AllowPaging="True" ShowFooter="True" BackColor="White" BorderColor="Black"
                    BorderStyle="None" BorderWidth="5px" CellPadding="2" ForeColor="Black"
                    GridLines="Horizontal"
                    PagerSettings-Position="Top" PagerSettings-Visible="False" PageSize="99999999">
                </asp:GridView>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function alterScreen(idScreen) {
            if (idScreen == 1) {
                document.getElementById("screen1").style.display = "block";
                document.getElementById("screen2").style.display = "none";
            } else {
                document.getElementById("screen1").style.display = "none";
                document.getElementById("screen2").style.display = "block";
            }
        }
    </script>
</asp:Content>
