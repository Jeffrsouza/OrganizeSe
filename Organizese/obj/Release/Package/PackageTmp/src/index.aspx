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
                    <p class="title"><%# Eval("TITULO") %></p>
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
                    <input type="text" id="txtName" class="form-control txtPop" placeholder="Nome..." />
                    &nbsp
                    &nbsp
                    &nbsp
                    <input type="text" id="txtMail" class="form-control txtPop" placeholder="E-mail..." />
                    &nbsp
                    &nbsp
                    <div>
                        <input type="checkbox" id="chkOk" class="form-check-label" style="color: #fff;" /><span style="color: #fff">Aceito receber o conteúdo exclusivo</span>
                        <br />
                        <br />
                        <p id="lblMsgRetorno" style="color: #00ff00"></p>
                    </div>
                    &nbsp
                    &nbsp                  
                    <input type="button" id="btnConfirma" value="Confirmar" class="btn btn-primary " style="width: 120px" onclick="validaCadastro()" />
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

        <script type="text/javascript">
            function validaCadastro() {

                var nome = document.getElementById('txtName').value;
                var email = document.getElementById('txtMail').value;
                var chk = document.getElementById('chkOk');


                if (email.indexOf('@') <= -1) {
                    alert("Preencha o e-mail corretamente.");
                } else if (!nome || !email) {
                    alert("Preencha corretamente os campos.");
                } else if (!chk.checked) {
                    alert("Confirme o recebimento do conteúdo exclusivo.");
                }
                else {
                    PageMethods.gravarEmail(nome,email,onSucess, onError);

                    function onSucess(result) {
                        lblMsgRetorno.innerHTML = "E-mail cadastrado com sucesso!";
                    }

                    function onError(result) {
                        alert('Erro ao cadastrar, por favor tente novamente.');
                    }
                }



            }
        </script>


    </div>

</asp:Content>


