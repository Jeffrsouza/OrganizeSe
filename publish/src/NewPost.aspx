<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="Organizese.src.NewPost" %>

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
    <title>Nova Postagem</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group bodyPosts">
            <div class="bodyNewPost">
                <p class="title">Nova Postagem</p>
                <br />
                <br />
                <div>
                    <asp:TextBox ID="txtTitle" runat="server" placeholder="Título" class="form-control" MaxLength="150" OnTextChanged="txtTitle_TextChanged"></asp:TextBox>
                </div>
                <br />
                   <div class="textRight">
                    <asp:DropDownList ID="ddlCat" runat="server" class="btn btn-primary"></asp:DropDownList>
                    <asp:Button ID="btnNegrito" class="negrito" runat="server" Text="B" OnClick="btnNegrito_Click" />
                    <asp:Button ID="btnItalico" class="italico" runat="server" Text="I" OnClick="btnItalico_Click"/>
                    <asp:Button ID="btnSublinhado" class="sublinhado" runat="server" Text="S" OnClick="btnSublinhado_Click" />
                    <asp:Button ID="btnLink" class="btnLink" runat="server" Text="Link" OnClick="btnLink_Click"/>
                </div>
                <br />

                <div>
                    <asp:TextBox ID="txtBodyPost" runat="server" placeholder="Postagem..." class="form-control" TextMode="MultiLine" Rows="50" Style="height: 350px"></asp:TextBox>
                </div>
                <br />
                  <div style="display: flex; flex-direction: column; align-items: center">
                    <asp:Image ID="imagePost" style="width: 600px; height: 200px; border-color: #1E90FF" runat="server" BorderWidth="2px" />
                    &nbsp
                    &nbsp
                    <asp:FileUpload ID="fileUpload" runat="server" onchange="fileUpload_DataBinding" style="max-width: 600px; " />
                </div>
                <br />
                <div>
                    <asp:Button ID="btnPost" runat="server" Text="Postar" OnClick="btnPost_Click" />
                     <asp:Button ID="btnTeste" runat="server" Text="Testar" OnClick="btnTeste_Click" />
                </div>
                <div>
                    <asp:Label ID="textoTest" runat="server" style="text-align:left" />
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
    </script>
</body>
</html>
