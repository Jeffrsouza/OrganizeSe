<%@ Page Title="" Language="C#" MasterPageFile="~/src/Home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Organizese.src.index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bodyPosts">
        <asp:Repeater runat="server" ID="RptPosts">
            <ItemTemplate>
                <div class="textPost">
                    <div class="textRight">
                        <img style="width: 25px; height: 25px;" src="img/calendar.png" />
                        <span runat="server"><%#Eval("DATAPOST")%></span>
                    </div>
                    <br />
                    <h1 style="text-align: left;"><%# Eval("TITULO") %></h1>
                    <br />
                    <!--Imagem Linha inteira-->
                    <div>
                        <asp:Image runat="server" src='<%# "data:image/png;base64,"+ Eval("ARQUIVO") %>' class="imgFull" />
                    </div>
                    <br />
                    <br />
                    <p>
                        <%# Eval("TEXTO") %>
                    </p>

                    <!--
                    <div class="textRight">
                        <a class="btn btn-primary btn-xs">Read more</a>
                        <a class="btn btn-danger btn-xs">Delete</a>
                    </div>
                         -->
                </div>
                <div class="separador">
                </div>
            </ItemTemplate>
        </asp:Repeater>



        <asp:Panel ID="pnlPopUp" Style="display: none;" runat="server">
            <div style="display: flex; flex-direction: row" class="modalPopUp">
                <div class="divPopUp">
                    &nbsp
                    <p style="font-weight: bold; color: #fff" class="txtPop">Preencha as informações abaixo e tenha acesso aos nossos conteúdos exclusivos</p>
                    &nbsp
                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control txtPop" placeholder="Nome..."></asp:TextBox>
                    &nbsp
                    &nbsp
                    &nbsp
                    <asp:TextBox runat="server" ID="txtMail" CssClass="form-control txtPop" placeholder="E-mail..."></asp:TextBox>
                    &nbsp
                    &nbsp
                    <div>
                        <asp:CheckBox ID="chkOkEmail" class="form-check-label" Style="color: #fff;" Text=" Aceito receber o conteúdo exclusivo"  runat="server" />
                        <asp:Label ID="lblConfirmEmail" style="color:#000" runat="server"></asp:Label>
                    </div>
                    &nbsp
                    &nbsp                  
                    <asp:Button ID="btnConfirm" Text="Confirmar" CssClass="btn btn-primary " Style="width: 120px" onclick="btnConfirm_Click" runat="server" />
                    &nbsp
                    &nbsp
                    &nbsp
                    <img src="img/logo.png" class="logoPopUp" />
                </div>
                &nbsp
                    &nbsp
                <div>
                    <asp:Button ID="cmdFechar" Text="X" CssClass="btn" runat="server" />
                </div>
            </div>
        </asp:Panel>
        <asp:Label ID="lblTeste" runat="server"></asp:Label>

        <asp:ModalPopupExtender ID="modalPopUpEmail" runat="server"
            BehaviorID="modalPopUpEmail"
            BackgroundCssClass="modalBackground"
            CancelControlID="cmdFechar"
            PopupControlID="pnlPopUp" PopupDragHandleControlID="panel3"
            TargetControlID="lblTeste">
        </asp:ModalPopupExtender>
    </div>
</asp:Content>

