<%@ Page Title="" Language="C#" MasterPageFile="~/src/Home.Master" AutoEventWireup="true" CodeBehind="Promocional.aspx.cs" Inherits="Organizese.src.Promocional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="separador"></div>
    <div class="separador"></div>
    <div class="divPopUp">

        <p style="font-weight: bold; color: #fff" class="txtPop">Preencha as informações abaixo e concorra ao sorteio de consultoria online!</p>
        &nbsp
                    <input type="text" id="txtNamePromo" class="form-control txtPop" placeholder="Nome..." />
        &nbsp &nbsp &nbsp
                    <input type="text" id="txtMailPromo" class="form-control txtPop" placeholder="E-mail..." />
        &nbsp &nbsp
                    <div>
                        <input type="checkbox" id="chkOkPromo" class="form-check-label" style="color: #fff;" /><span style="color: #fff">Aceito receber o conteúdo exclusivo</span>
                        <br />
                        <br />
                        <p id="lblMsgRetornoPromo" style="color: #00ff00"></p>
                    </div>
        &nbsp &nbsp   
        <div id="divBtn">
            <input type="button" id="btnOrganizador" value="Cadastrar!" class="btn btn-primary " style="width: 170px;" onclick="validaCadastroPromo()" />
        </div>
        &nbsp &nbsp &nbsp
                    <img src="img/logo.png" class="logoPopUp" />
        &nbsp

        <!-- Modal -->
<div class="modal fade" id="modalOk" tabindex="-1" role="dialog" aria-labelledby="modalOkLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="modalOkLabel">Cadastrado no sorteio!</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <p style="text-align:center"><b>Olá!</b></p>
        <p style="text-align:center"><b>Agora você esta concorrendo a 2h de consultoria online em organização pessoal!</b></p>
        <p style="text-align:center"><b>O atendimento será feito através da nossa página no Facebook e agendada de acordo com a disponibilidade do ganhador(a)!</b></p>
        <p style="text-align:center"><b>O resultado será divulgado dia 01/02 também em nossa página do Facebook!</b></p>
        <p style="text-align:center"><b>Fique de olho e boa sorte!!!</b></p>

                <div style="display:flex;flex-direction:column;align-items:center">
                <section style="display:flex;flex-direction:row">
                    <a href="https://www.facebook.com/conteudosorganizese/?modal=admin_todo_tour" target="_blanck">
                        <div class="icone" id="facebook">
                            <img src="img/facebook.png" class="iconeImg" />
                        </div>
                    </a>
                    <a href="https://www.instagram.com/organizeestrategias/" target="_blanck">
                        <div class="icone" id="instagram">
                            <img src="img/instagram.png" class="iconeImg" />
                        </div>
                    </a>
                    <a href="mailto:organizeseestrategias@gmail.com" target="_blanck">
                        <div class="icone" id="mail">
                            <img src="img/email.png" class="iconeImg" />
                        </div>
                    </a>
                </section>
      </div>
      </div>
      <div class="modal-footer">
        <a href="http://www.organizeseop.com.br" class="btn btn-primary" >OK</a>
      </div>
    </div>
  </div>
</div>

                         <script type="text/javascript">
                             function validaCadastroPromo() {

                                 var nome = document.getElementById('txtNamePromo').value;
                                 var email = document.getElementById('txtMailPromo').value;
                                 var chk = document.getElementById('chkOkPromo');

                                 if (email.indexOf('@') <= -1) {
                                     alert("Preencha o e-mail corretamente.");
                                 } else if (!nome || !email) {
                                     alert("Preencha corretamente os campos.");
                                 } else if (!chk.checked) {
                                     alert("Confirme o recebimento do conteúdo exclusivo.");
                                 }
                                 else {
                                     PageMethods.gravarEmailPromo(nome, email, onSucess, onError);

                                     function onSucess(result) {
                                         $('#modalOk').modal('show');
                                     }

                                     function onError(result) {
                                         alert('Erro ao cadastrar, por favor tente novamente.');
                                     }
                                 }
                             }
                         </script>
    </div>

</asp:Content>
