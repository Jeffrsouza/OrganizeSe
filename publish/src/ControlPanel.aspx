<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="Organizese.src.ControlPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Painel de Controle</title>

      <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, height=device-height, initial-scale=1, maximum-scale=1, user-scalable=no" />

    <!-- Bootstrap CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Styles CSS -->
    <link href="styles/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:20px">
        <div>
        <p>
           * E = Apenas Lista de e-mail <br/> * F = Free <br/> * P = Premium <br/> * C = Cancelado <br/>
        </p>       
    </div>
    <asp:GridView runat="server" ID="gvDados"
        CssClass="table table-striped" EnableModelValidation="True" 
        AllowPaging="True" ShowFooter="True"  BackColor="White" BorderColor="Black" 
        BorderStyle="None" BorderWidth="5px" CellPadding="2" ForeColor="Black" 
        GridLines="Horizontal" 
        PagerSettings-Position="Top" PagerSettings-Visible="False" PageSize="99999999">
                
    </asp:GridView>
    </div>
    </form>

      <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="bootstrap/js/jquery-3.3.1.slim.min.js"></script>
    <script src="bootstrap/js/popper.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>

</body>
</html>
