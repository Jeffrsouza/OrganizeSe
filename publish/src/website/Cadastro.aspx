<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Organizese.src.website.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <!-- Bootstrap CSS File -->
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../styles/styleSite.css" rel="stylesheet" />
</head>

<body class="cadBody">
    <form id="form1" runat="server">
        <div class="cadDivForm">
        <span class="cadTitle">Organize-se Agora!</span>
        </div>
        <br />      
          <asp:Literal ID="ltlErro" runat="server"></asp:Literal>
        <br />      
        <div class="cadDivForm">
            <div class="cadDivLeft">Nome:</div>
            <div class="cadDivRight">
                <asp:TextBox ID="txtNome" runat="server" class="cadTxt"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="cadDivForm">
            <div class="cadDivLeft">Sobrenome:</div>
            <div class="cadDivRight">
                <asp:TextBox runat="server" class="cadTxt" ID="txtSobrenome"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="cadDivForm">
            <div class="cadDivLeft">CPF:</div>
            <div class="cadDivRight">
                <asp:TextBox runat="server" class="cadTxt" ID="txtCpf"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="cadDivForm">
            <div class="cadDivLeft">Email:</div>
            <div class="cadDivRight">
                <asp:TextBox runat="server" class="cadTxt" ID="txtEmail"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="cadDivForm">
            <div class="cadDivLeft">Senha:</div>
            <div class="cadDivRight">
                <asp:TextBox runat="server" class="cadTxt" ID="txtSenha"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="cadDivForm">
            <div class="cadDivLeft">Confirmar Senha:</div>
            <div class="cadDivRight">
                <asp:TextBox runat="server" class="cadTxt" ID="txtSenha2"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="cadDivForm">
            <div class="cadDivLeft">Data Nascimento:</div>
            <div class="cadDivRight">
                <input class="cadData" type="date" id="dtNascimento" runat="server" />
            </div>
        </div>
        <br />
        <div class="cadDivForm">
            <div class="cadDivLeft">Gênero:</div>
            <div class="cadDivRight">
                <asp:RadioButtonList ID="rblGen" RepeatDirection="Horizontal" runat="server" CssClass="spaced">                    
                    <asp:ListItem Value="F" Selected="True" Text="Feminino" />
                    <asp:ListItem Value="M" Text="Masculino" />
                    <asp:ListItem Value="O" Text="Outros" />
                </asp:RadioButtonList>
            </div>
        </div>
        <br />
        <br />
         <div class="cadDivBtn">
        <asp:Button runat="server" ID="btnCadastrar" CssClass="btn btn-success" OnClick="btnCadastrar_Click" Text="Cadastrar"/>
        </div>
        </form>
</body>
</html>
