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
                    <asp:TextBox ID="txtTitle" runat="server" placeholder="Título" class="form-control"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:TextBox ID="txtSubTitle" runat="server" placeholder="Subtítulo" class="form-control"></asp:TextBox>
                </div>
                <br />

                <div>
                    <asp:TextBox ID="txtBodyPost" runat="server" placeholder="Postagem..." class="form-control" TextMode="MultiLine" Rows="50" Style="height: 350px"></asp:TextBox>
                </div>
                <br />

                <div>
                    <asp:Button ID="btnPost" runat="server" Text="Postar" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
