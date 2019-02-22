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
            <input type="radio" name="grupo" id="rbHome" />
            <input type="radio" name="grupo" id="rbSobre" />
            <input type="radio" name="grupo" id="rbLoja" />
            <input type="radio" name="grupo" id="rbBlog" />
            <input type="radio" name="grupo" id="rbPlanos" />
            <input type="radio" name="grupo" id="rbJuntos" />
            <input type="radio" name="grupo" id="rbContato" />

            <section class="sections">
                <section class="bloco" id="stHome"></section>
                <section class="bloco" id="stSobre"></section>
                <section class="bloco" id="stLoja"></section>
                <section class="bloco" id="stBlog">
                    <div class="blogPosts">
                        <asp:Repeater runat="server" ID="rptBlog">
                            <ItemTemplate>
                                <div class="listBlog">
                                    <div class="">
                                        <span runat="server"><%#Eval("CATEGORIA")%></span>
                                    </div>
                                    <a href="index.aspx?id=<%# Eval("ID") %>">
                                        <asp:Image runat="server" src='<%# "data:image/png;base64,"+ Eval("ARQUIVO") %>' class="imgBlog" /><br/>
                                        <asp:Label runat="server"  class="subTitle"><%# Eval("TITULO").ToString().Length > 120 ? (Eval("TITULO").ToString().Substring(0, 120) + "...") : Eval("TITULO") %></asp:Label>
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </section>
                <section class="bloco" id="stPlanos"></section>
                <section class="bloco" id="stJuntos"></section>
                <section class="bloco" id="stContato"></section>

            </section>
        </div>
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
