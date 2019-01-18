<%@ Page Title="" Language="C#" MasterPageFile="~/src/Home.Master" AutoEventWireup="true" CodeBehind="popUp.aspx.cs" Inherits="Organizese.src.popUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="separador"></div>
    <div class="separador"></div>
    <div class="divPopUp">

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
        &nbsp &nbsp   
        <div id="divBtn">
            <input type="button" id="btnOrganizador" value="Baixe seu Planejador!" class="btn btn-primary " style="width: 170px;" onclick="validaCadastro()" />
        </div>
        &nbsp &nbsp &nbsp
                    <img src="img/logo.png" class="logoPopUp" />
        &nbsp
                         <script type="text/javascript">

                             function abrir(ok) {
                                 if (ok == true) {
                                     var pagina = "https://drive.google.com/open?id=1hpAclke7AjMeIN0yvfD-r4OGmxI6pT8t"
                                     var abriu = false
                                     var newWindow = window.open(pagina, "Planejador", "width=800,height=600")
                                     if (newWindow) {
                                         abriu = true
                                         window.location.href = "http://organizeseop.com.br";
                                         return false
                                     }
                                 }
                                 if (!abriu && ok == true) $("#divBtn").append("<br/><br/><a href='#' onclick='return abrir()'>Verifique o bloqueio de Pop Up e clique novamente para baixar! </a>");
                             }



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
                                     PageMethods.gravarEmail(nome, email, onSucess, onError);

                                     function onSucess(result) {
                                         abrir(true);
                                     }

                                     function onError(result) {
                                         alert('Erro ao cadastrar, por favor tente novamente.');
                                     }
                                 }
                             }
                         </script>
    </div>
</asp:Content>
