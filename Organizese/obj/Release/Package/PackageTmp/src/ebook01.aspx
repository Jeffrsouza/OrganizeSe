<%@ Page Title="" Language="C#" MasterPageFile="~/src/Home.Master" AutoEventWireup="true" CodeBehind="ebook01.aspx.cs" Inherits="Organizese.src.ebook01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="separador"></div>
    <div class="separador"></div>
    <div class="divPopUp">

        <p style="font-weight: bold; color: #fff" class="txtPop">Preencha as informações abaixo e baixe GRÁTIS o E-book:</p> 
        <p style="font-weight: bold; color: #fff" class="txtPop">7 maneiras para você organizar sua vida em 2019!</p>
        &nbsp
                    <input type="text" id="txtNameBk01" class="form-control txtPop" placeholder="Nome..." />
        &nbsp &nbsp &nbsp
                    <input type="text" id="txtMailBk01" class="form-control txtPop" placeholder="E-mail..." />
        &nbsp &nbsp
                    <div>
                        <input type="checkbox" id="chkOkBk01" class="form-check-label" style="color: #fff;" /><span style="color: #fff">Aceito receber o conteúdo exclusivo</span>
                        <br />
                        <br />
                        <p id="lblMsgRetornoBk01" style="color: #00ff00"></p>
                    </div>
        &nbsp &nbsp   
        <div id="divBtnBk01">
            <input type="button" id="btnOrganizador" value="Cadastrar!" class="btn btn-primary " style="width: 170px;" onclick="validaCadastroBk01()" />
        </div>
        &nbsp &nbsp &nbsp
                    <img src="img/logo.png" class="logoPopUp" />
        &nbsp

                        <script type="text/javascript">

                             function abrir(ok) {
                                 if (ok == true) {
                                     var pagina = "https://drive.google.com/file/d/1W9EqBtKNfaaT4ALPw3ky6cRDRtocrrYe/view"
                                     var abriu = false
                                     var newWindow = window.open(pagina, "Ebook 2019", "width=800,height=600")
                                     if (newWindow) {
                                         abriu = true
                                         window.location.href = "http://organizeseop.com.br";
                                         return false
                                     }
                                 }
                                 if (!abriu && ok == true) $("#divBtnBk01").append("<br/><br/><a href='#' onclick='return abrir()'>Verifique se o e-book esta berto em outra aba ou bloqueio de Pop Up e clique novamente para baixar!<br/>Você pode tentar copiar e colar o seguinte link no seu navegador https://drive.google.com/file/d/1W9EqBtKNfaaT4ALPw3ky6cRDRtocrrYe/view </a>");
                             }



                             function validaCadastroBk01() {
                                 var nome = document.getElementById('txtNameBk01').value;
                                 var email = document.getElementById('txtMailBk01').value;
                                 var chk = document.getElementById('chkOkBk01');

                                 if (email.indexOf('@') <= -1) {
                                     alert("Preencha o e-mail corretamente.");
                                 } else if (!nome || !email) {
                                     alert("Preencha corretamente os campos.");
                                 } else if (!chk.checked) {
                                     alert("Confirme o recebimento do conteúdo exclusivo.");
                                 }
                                 else {
                                     PageMethods.gravarEmailEbook01(nome, email, onSucess, onError);

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
