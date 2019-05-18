<%@ Page Title="" Language="C#" MasterPageFile="~/src/website/WebSite.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Organizese.src.website.Home" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManagerHomeSite" runat="server" EnablePageMethods='true'></asp:ScriptManager>
    <div>
        <nav class="progress">
            <div id="divProgress" class="divProgress"></div>
        </nav>
        <nav class="links">
            <a href="javascript:progress('#stHome');">Home</a>
            <a href="javascript:progress('#stSobre');">Sobre</a>
            <a href="javascript:progress('#stLoja');">Loja</a>
            <a href="javascript:progress('#stBlog');">Blog</a>
            <a href="javascript:progress('#stPlanos');">Planos</a>
            <a href="javascript:progress('#stContato');">Contato</a>
            <a href="javascript:progress('#stContato');">Junte-se</a>
            <a href="javascript:abrirLogin();">Entrar</a>

        </nav>
        <div class="scroll">
            <div id="divLogin" class="login" >
                <asp:TextBox ID="txtEmail" runat="server" PlaceHolder=" Login..." class="txtLogin"></asp:TextBox>
                <asp:TextBox ID="txtSenha" runat="server" PlaceHolder=" Senha..." TextMode="Password" class="txtLogin"></asp:TextBox>
                <asp:Button ID="btnEntrar" CssClass="btnEntrar" runat="server" Text="Entrar" AutoPostBack="false" OnClick="btnEntrar_Click" />
            </div>

            <section class="sections">
                <section class="bloco" id="stHome">
                    <p class="sectionTitle">Organize-se</p>
                    &nbsp
                   &nbsp
                   &nbsp
                    <div></div>
                    <div class="groupIcons">
                        <div class="iconHome wow fadeInUp" data-wow-delay="1s" data-wow-duration="1s">
                            <img class="imgIcon" src="../img/icons/icon_desenv.png" />
                            <p class="subTitle">Evolução</p>
                        </div>
                        <div class="iconHome wow fadeInUp" data-wow-delay="2s" data-wow-duration="1s">
                            <img class="imgIcon" src="../img/icons/icon_calc.png" />
                            <p class="subTitle">Controle</p>
                        </div>
                        <div class="iconHome wow fadeInUp" data-wow-delay="3s" data-wow-duration="1s">
                            <img class="imgIcon" src="../img/icons/icon_education.png" />
                            <p class="subTitle">Estudos</p>
                        </div>
                        <div class="iconHome wow fadeInUp" data-wow-delay="4s" data-wow-duration="1s">
                            <img class="imgIcon" src="../img/icons/icon_foco.png" />
                            <p class="subTitle">Foco</p>
                        </div>
                    </div>
                </section>
                <section class="bloco" id="stSobre">
                    <p class="sectionTitleSobre">Sobre a empresa</p>
                    &nbsp
                    <div class="container-fluid">
                        <div class="about">
                            <div class="col-lg-6 wow fadeInLeft aboutLeft ">
                                <img class="imgAbout" src="../img/aboutOg.png" />
                            </div>
                            <div class="wow fadeInRight aboutRight">
                                <p>
                                    Somos uma empresa <b>especializada em organização pessoal</b> de grandes resultados, 
                                    tanto nas finanças, como nos estudos ou no trabalho
                                </p>

                                <p>
                                    Começamos <b>planejando e montando projetos organizacionais</b> para estudantes 
                                    e trabalhadores com problemas financeiros.
                                </p>
                                <p>
                                    Após alcançar o sucesso em nossos objetivos, montamos uma equipe especializada 
                                    em questões organizacionais das diversas áreas a fim de atingir maiores resultados e manter 
                                    uma ampla cartela de clientes satisfeitos com o próprio sucesso.
                                </p>
                                <p>
                                    Recentemente decidimos ampliar nosso projeto para o meio virtual, disponibilizando 
                                    dicas através de postagens em blog, nas mídias sociais e promovendo e-books para que nossos 
                                    clientes possam estudar e conhecer mais sobre organização pessoal.
                                </p>
                                <p>
                                    Além disso, em nosso site, é possível contatar um de nossos especialistas para <b>conversar e 
                                    desenvolver métodos específicos à rotina do cliente. 
                                    Dessa forma, nosso trabalho consiste em organizar a vida das pessoas e prepará-las 
                                    para o sucesso pessoal.</b>
                                </p>
                            </div>
                        </div>
                    </div>
                </section>
                <section class="bloco" id="stLoja">
                    <p class="sectionTitlePlan">E-book</p>
                    <!--<div class="divLoja">-->
                        <div class="divLivroLeft">
                            <img class="imgLoja"
                                src="../img/produtos/EstabilidadeFinanceira.jpg" />
                            &nbsp
                            <a href="https://simplissimo.com.br/onsales/organize-se/?fbclid=IwAR1SRe9qOHxxHUegAdeYKW4U3_e-0HD8Y1RhPGtRNbstKVL3QU8AziZmunI"
                                class="titleProd">Estabilidade Financeira</a>
                        </div>

                </section>
                <section class="bloco" id="stBlog">
                    <p class="sectionTitle">Blog Organize-se</p>
                    &nbsp
                   &nbsp
                   &nbsp
                    <div class="blogPosts">
                        <asp:Repeater runat="server" ID="rptBlog">
                            <ItemTemplate>
                                <div class="listBlog">
                                    <div class="divCategoria">
                                        <div class="divSubCategoria">
                                            <span class="categoria" runat="server"><%#Eval("CATEGORIA")%></span>
                                        </div>
                                    </div>
                                    <a href="http://www.organizeseop.com.br/src/index.aspx?id=<%# Eval("ID") %>">
                                        <asp:Image runat="server" src='<%# "data:image/png;base64,"+ Eval("ARQUIVO") %>' class="imgBlog" /><br />
                                        <br />
                                        <asp:Label runat="server" class="titlePost"><%# Eval("TITULO").ToString().Length > 100 ? (Eval("TITULO").ToString().Substring(0, 100) + "...") : Eval("TITULO") %></asp:Label>
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </section>
                <section class="bloco" id="stPlanos">
                    <div class="titlePlanos">
                        <p class="sectionTitlePlan">Contrate agora e Organize-se!</p>
                        <p class="subtitlePlan">
                            Tenha acesso á consultorias online ilimitadas, 
                        que podem ser agendadas quando
                        <br />
                            você quiser e de onde você estiver 
                        com os nossos planos.
                        </p>
                    </div>
                    &nbsp
                    <div class="groupPlan">
                        <div class="planType1">
                            <div class="divPlano">
                                <div class="titleTipoPlano">
                                    <p class="titlePlano">Plano Mensal</p>
                                </div>
                                <div class="paragrafo">
                                    <p>
                                        <i class="fa fa-check-square-o iconPlan" aria-hidden="true"></i>
                                        APP exclusivo para Android
                                    </p>
                                    <p>
                                        <i class="fa fa-check-square-o iconPlan" aria-hidden="true"></i>
                                        Acesso ilimitado a consultoria
                                        on-line com um profissional da organização.
                                    </p>
                                    <p>
                                        <i class="fa fa-check-square-o iconPlan" aria-hidden="true"></i>
                                        Parcelado em até 2x
                                    </p>
                                </div>
                                <p class="preco">R$49,99/mês</p>
                            </div>
                            <input type="button" class="btnPlano" value="Contrate Agora!" onclick="contratarPlano()" />
                        </div>
                        <div class="planType2">
                            <div class="divPlano">
                                <div class="titleTipoPlano">
                                    <br />
                                    <p>Plano Anual</p>
                                    <br />
                                </div>
                                <div class="paragrafo">
                                    <p>
                                        <i class="fa fa-check-square-o iconPlan" aria-hidden="true"></i>
                                        APP exclusivo para Android
                                    </p>
                                    <p>
                                        <i class="fa fa-check-square-o iconPlan" aria-hidden="true"></i>
                                        Acesso ilimitado a consultoria
                                        on-line com um profissional da organização.
                                    </p>
                                    <p>
                                        <i class="fa fa-check-square-o iconPlan" aria-hidden="true"></i>
                                        Melhor custo benefício
                                    </p>
                                </div>
                                <p class="preco">R$29,99/mês</p>
                            </div>
                            <input type="button" class="btnPlano" value="Contrate Agora!" />
                        </div>
                        <div class="planType3">
                            <div class="divPlano">
                                <div class="titleTipoPlano">
                                    <br />
                                    <p>Plano Semestral</p>
                                    <br />
                                </div>
                                <div class="paragrafo">
                                    <p>
                                        <i class="fa fa-check-square-o iconPlan" aria-hidden="true"></i>
                                        APP exclusivo para Android
                                    </p>
                                    <p>
                                        <i class="fa fa-check-square-o iconPlan" aria-hidden="true"></i>
                                        Acesso ilimitado a consultoria
                                        on-line com um profissional da organização.
                                    </p>
                                    <p>
                                        <i class="fa fa-check-square-o iconPlan" aria-hidden="true"></i>
                                        Melhor custo benefício
                                    </p>

                                </div>
                                <p class="preco">R$39,99/mês</p>
                            </div>
                            <input type="button" class="btnPlano" value="Contrate Agora!" />
                        </div>
                    </div>
                </section>
                <section class="bloco" id="stContato">
                    <div class="titleContato">
                        <h1>Entre em contato conosco</h1>
                    </div>
                    <div class="divCorpoContato">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="well well-sm">
                                   <!-- <form>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label for="name">
                                                        Nome</label>
                                                    <input type="text" class="form-control" id="nome" placeholder="Nome..."  />
                                                </div>
                                                <div class="form-group">
                                                    <label for="email">
                                                        E-mail</label>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text" id="basic-addon1">@</span>
                                                        </div>
                                                        <input type="email" class="form-control" id="email" placeholder="E-mail..."  />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="wpp">
                                                        Whatsapp</label>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text" id="wpp"><i style="font-size: 20px; color: green" class="fa">&#xf232;</i></span>
                                                        </div>
                                                        <input type="text" class="form-control" id="numwpp" placeholder="Whatsapp..."  />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label for="name">
                                                        Mensagem</label>
                                                    <textarea name="message" id="message" class="form-control" rows="9" cols="25" maxlength="500"
                                                        placeholder="Menssagem (até 500 caractéres)"></textarea>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <button type="submit" class="btn btn-primary pull-right" id="btnContactUs">
                                                    Enviar</button>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <form>
                                    <legend><span class="glyphicon glyphicon-globe"></span></legend>
                                    <address>
                                        <br />
                                        <strong>Organize-se</strong><br />
                                        <br />
                                        <br />
                                        <br />

                                        <!--
                                        <br />
                                        Rodrigo A. Sparma:  
                                <br />
                                        <a href="https://api.whatsapp.com/send?phone=5519992604818&text=GinásticaLaboral:">
                                            <i style="font-size: 24px; color: green" class="fa">&#xf232;</i>&nbsp&nbsp(19) 99260-4818
                                        </a>
                                        <br />
                                        <br />
                                        Melissa Brazuna:
                                <br />
                                        <a href="https://api.whatsapp.com/send?phone=55199991928219&text=GinásticaLaboral:">
                                            <i style="font-size: 24px; color: green" class="fa">&#xf232;</i>&nbsp&nbsp(19) 99192-8219
                                        </a>
                                    </address>
                                        <address>
                                            <strong>E-mail: </strong>
                                            <br>
                                            <a href="mailto:#">organizeestrategias@gmail.com</a>
                                        </address>
                                </form>-->
                            </div>
                        </div>
                    </div>


                </section>

            </section>
        </div>

        <!-- jQuery first, then Popper.js, then Bootstrap JS -->

        <script src="../bootstrap/js/jquery-3.3.1.slim.min.js"></script>
        <script src="../bootstrap/js/popper.min.js"></script>
        <script src="../bootstrap/js/bootstrap.min.js"></script>

        <!-- JavaScript Libraries -->
        <script src="../lib/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="../lib/easing/easing.min.js"></script>
        <script src="../lib/wow/wow.min.js"></script>
        <script src="../lib/superfish/superfish.min.js"></script>
        <script src="../lib/superfish/hoverIntent.js"></script>
        <script src="../lib/magnific-popup/magnific-popup.min.js"></script>
        <script src="../lib/js/main.js"></script>

        <script type="text/javascript">
            function progress(page) {
                var progresso = 0;
                switch (page) {
                    case "#stHome": progresso = 14; break;
                    case "#stSobre": progresso = 28; break;
                    case "#stLoja": progresso = 42; break;
                    case "#stBlog": progresso = 56; break;
                    case "#stPlanos": progresso = 70; break;
                    case "#stJuntos": progresso = 84; break;
                    case "#stContato": progresso = 100; break;
                }
                window.location.href = page;
                document.getElementById('divProgress').style.width = progresso + "%";

            }
            function contratarPlano() {
                window.open('https://pag.ae/7UGTWDhBa', '_blank');
            }

            function abrirLogin() {
                document.getElementById("divLogin").style.display = document.getElementById("divLogin").style.display == 'block' ? 'none' : 'block';
            }

        </script>
    </div>
</asp:Content>
