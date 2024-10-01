<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="CapaPrensentacion.frmLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar sesión</title>
    <!-- Agregar estilos de Bootstrap para una mejor apariencia -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3 class="mt-5">Login</h3>
            <div class="form-group">
                <label for="txtUsuario">Usuario:</label>
                <asp:TextBox runat="server" id="txtUsuario" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtPassword">Contraseña:</label>
                <asp:TextBox runat="server" id="txtPassword" CssClass="form-control" TextMode="Password" />
            </div>
            <div class="form-group">
                <asp:Button Text="Iniciar sesión" runat="server" ID="btnLogin" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            </div>
            <asp:Label runat="server" id="lblMensaje" CssClass="text-danger" />
        </div>
    </form>
    <!-- Incluir los scripts de Bootstrap para mejorar la funcionalidad -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
