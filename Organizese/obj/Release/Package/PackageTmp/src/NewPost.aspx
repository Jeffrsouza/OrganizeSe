<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="Organizese.src.NewPost" validateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="styles/style.css" rel="stylesheet" />


    <link href="styles/style.css" rel="stylesheet" />
    <title>Postagem</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group bodyPosts">          
            <div class="bodyNewPost">
                <p class="titleNewPost">Postagem</p>
                <div style="display:flex;flex-direction:row;align-items:center">
                        <asp:CheckBox  ID="chkEdit" runat="server" style="margin:20px" AutoPostBack="true"  OnCheckedChanged="chkEdit_CheckedChanged" Text="Edição" />
                    &nbsp
                  <asp:ListBox ID="listPosts" runat="server" AutoPostBack="true" style="width:500px; height:200px" visible="false" OnSelectedIndexChanged="listPosts_SelectedIndexChanged" ></asp:ListBox>
                    &nbsp
                    <asp:Label ID="lblIdPost" Visible="false" runat="server"></asp:Label>
                    &nbsp   
                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />                
                    </div>
                <br />
                <br />
                <div>
                    <asp:TextBox ID="txtTitle" runat="server" placeholder="Título" class="form-control" MaxLength="150"></asp:TextBox>
                </div>
                <br />
                <div class="textRight">
                    <asp:DropDownList ID="ddlCat" runat="server" class="btn btn-primary"></asp:DropDownList>
                    <input type="button" id="btnH2" class="negrito" onclick="h2();" value="h2" />
                    <input type="button" id="btnH3" class="negrito" onclick="h3();" value="h3" />
                    <input type="button" id="btnNeg" class="negrito" onclick="negrito();" value="B" />
                    <input type="button" id="btnIta" class="italico" onclick="italico();" value="I" />
                    <input type="button" id="btnSub" class="sublinhado" onclick="sublinhado();" value="S" />
                    <input id="textLink" placeholder="Link..." style="width: 200px" type="text" />
                    <input id="btnLink" class="btnLink" value="Link" type="button" onclick="link()" />
                    <input id="btnPopUp" class="btnLink" value="PopUp" type="button" onclick="setPopUp()" />
                </div>
                <br />

                <div>
                    <asp:TextBox ID="txtBodyPost" runat="server" placeholder="Postagem..." class="form-control" TextMode="MultiLine" Rows="50" Style="height: 300px"></asp:TextBox>
                    <input id="btnTeste" type="button" value="Testar" onclick="testar();" />
                    <p id="lblTeste" class="textPre"></p>
                </div>
                <br />
                <div style="display: flex; flex-direction: column; align-items: center">
                    <asp:Image ID="imagePost" class="imgFull" Style="border-color: #1E90FF" runat="server" BorderWidth="2px" />
                    &nbsp
                    &nbsp
                    <asp:FileUpload ID="fileUpload" runat="server" onchange="fileUpload_DataBinding" Style="max-width: 600px;" />
                </div>
                <br />
                <div>
                    <asp:Button ID="btnPost" runat="server" Text="Postar" OnClick="btnPost_Click" />
                </div>
            </div>
        </div>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript">
        $("#<%=fileUpload.ClientID%>").on('change', function () {
            if (this.files[0].type.indexOf("image") > -1) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imagePost.ClientID%>').attr('src', e.target.result);
                }
                reader.readAsDataURL(this.files[0]);
                alert('É uma imagem válida')
                }
                else {
                    $('#<%=imagePost.ClientID%>').attr('src', '');
                alert('Não é uma imagem válida')
            }
        });
        function testar() {
            var valor = document.getElementById('txtBodyPost').value;
            if (/[\n|\n\r]/.test(valor)) {
                valor = valor.replace(/[\n|\n\r]/g, '<br/>');
            }
            lblTeste.innerHTML = valor;
        }
        function setPopUp() {
            var ta = document.querySelector("textarea");
            ta.value = ta.value.substring(0, ta.selectionStart) +
                       "<a  href=\"javascript:$find(`modalPopUpEmail`).show();\">" + ta.value.substring(ta.selectionStart, ta.selectionEnd) + "</a>" +
                       ta.value.substring(ta.selectionEnd);
            lblTeste.innerHTML = ta.value;
            testar();
        }
        function h2() {
            var ta = document.querySelector("textarea");
            ta.value = ta.value.substring(0, ta.selectionStart) +
                       "<h2>" + ta.value.substring(ta.selectionStart, ta.selectionEnd) + "</h2>" +
                       ta.value.substring(ta.selectionEnd);
            lblTeste.innerHTML = ta.value;
            testar();
        }
        function h3() {
            var ta = document.querySelector("textarea");
            ta.value = ta.value.substring(0, ta.selectionStart) +
                       "<h3>" + ta.value.substring(ta.selectionStart, ta.selectionEnd) + "</h3>" +
                       ta.value.substring(ta.selectionEnd);
            lblTeste.innerHTML = ta.value;
            testar();
        }

        function negrito() {
            var ta = document.querySelector("textarea");
            ta.value = ta.value.substring(0, ta.selectionStart) +
                       "<b>" + ta.value.substring(ta.selectionStart, ta.selectionEnd) + "</b>" +
                       ta.value.substring(ta.selectionEnd);
            lblTeste.innerHTML = ta.value;
            testar();
        }
        function italico() {
            var ta = document.querySelector("textarea");
            ta.value = ta.value.substring(0, ta.selectionStart) +
                       "<i>" + ta.value.substring(ta.selectionStart, ta.selectionEnd) + "</i>" +
                       ta.value.substring(ta.selectionEnd);
            lblTeste.innerHTML = ta.value;
            ;
        }
        function sublinhado() {
            var ta = document.querySelector("textarea");
            ta.value = ta.value.substring(0, ta.selectionStart) +
                       "<u>" + ta.value.substring(ta.selectionStart, ta.selectionEnd) + "</u>" +
                       ta.value.substring(ta.selectionEnd);
            lblTeste.innerHTML = ta.value;
            testar();
        }
        function link() {
            var ta = document.querySelector("textarea");
            ta.value = ta.value.substring(0, ta.selectionStart) +
                       "<a href=" + textLink.value + ">" + ta.value.substring(ta.selectionStart, ta.selectionEnd) + "</a>" +
                       ta.value.substring(ta.selectionEnd);
            lblTeste.innerHTML = ta.value;
            testar();
        }
    </script>
</body>
</html>
