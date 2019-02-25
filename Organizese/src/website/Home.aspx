<%@ Page Title="" Language="C#" MasterPageFile="~/src/website/WebSite.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Organizese.src.website.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <a href="javascript:progress('#stJuntos');">Junte-se</a>
            <a href="javascript:progress('#stContato');">Contato</a>
        </nav>



        <div class="scroll">
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
                      <p class="sectionTitleSobre" >Sobre a empresa</p>
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
                                    <a href="index.aspx?id=<%# Eval("ID") %>">
                                        <asp:Image runat="server" src='<%# "data:image/png;base64,"+ Eval("ARQUIVO") %>' class="imgBlog" /><br />
                                        <asp:Label runat="server" class="titlePost"><%# Eval("TITULO").ToString().Length > 120 ? (Eval("TITULO").ToString().Substring(0, 120) + "...") : Eval("TITULO") %></asp:Label>
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </section>
                <section class="bloco" id="stPlanos">
                    <p class="sectionTitlePlan">Contrate agora e Organize-se!</p>
                    &nbsp
                    &nbsp
                    <div class="groupPlan">

                        <!--
                        <div class="planType1">
                            <div class="divPlano">
                                <br />
                                <br />
                               <i class="fa fa-check-circle iconPlano"></i> Plano Friends
                            </div>
                            <input type="button" class="btnPlano" value="Contrate Agora!" />
                        </div>
                            -->
                        <div class="planType2">
                            <div class="divPlano">
                                <br />
                                <br />
                                Plano Organizacional
                                <br />
                                <br />
                                R$29,99/mês
                            </div>
                            <input type="button" class="btnPlano" value="Contrate Agora!" />
                        </div>
                        <!--
                            <div class="planType3">
                            <div class="divPlano">
                                <br />
                                <br />
                               <i class="fa fa-check-circle iconPlano"></i> Plano Empresarial
                            </div>
                            <input type="button" class="btnPlano" value="Contrate Agora!" />
                        </div>
                            -->
                    </div>
                </section>
                <section class="bloco" id="stJuntos"></section>
                <section class="bloco" id="stContato"></section>

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

        </script>
    </div>
</asp:Content>
