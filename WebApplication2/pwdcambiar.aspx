<%@ Page Title="DTS - Cambio Contraseña" Language="C#" AutoEventWireup="true" CodeBehind="pwdcambiar.aspx.cs" Inherits="WebApplication2.pwdcambiar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor">
        <%--<div dir="ltr">--%>
        <div id="img"><asp:Image ID="Image1" runat="server" ImageUrl="~/img/fondo_claro_transparente.png"
            Height="80px" Width="300px" /></div>
        <br />

        <div id="txtUno"><h2>
            Cambio Contraseña</h2></div>
            <br />
        <div id="txtDos"><p>
            Ingrese dos veces su nueva contraseña para cambiarla.</p></div>
        
        <br /><div id="sectionCambioUser">
        <div id="lblCambioUser"><label>Usuario:</label></div>
        <div id="txtCambioUser"><input type="text" id="txtCambUser" name="txtCambUser" runat="server" 
                style="width:120px;" disabled="disabled"/></div>
        </div>

                <br /><div id="sectionOldPwd">
        <div id="lblOldPwd"><label>Contraseña Actual:</label></div>
        <div id="txtOldPwd"><input type="text" id="txtOldPw" name="txtOldPw" runat="server" 
                style="width:120px;"/></div>
        </div>

        <br /><div id="sectionCambioPwd1">
        <div id="lblCambio1"><label>Nueva Contraseña:</label></div>
        <div id="txtCambio1"><input type="text" id="txtCambioPw" name="txtCambioPw" runat="server" 
                style="width:120px;"/></div>
        </div>

        <br /><div id="sectionCambioPwd2">
        <div id="lblCambio2"><label>Repita Contraseña:</label></div>
        <div id="txtCambio2"><input type="text" id="txtCambioPwn" name="txtCambioPwn" runat="server" 
                style="width:120px;" /></div>
        </div>

        <br /><div id="boton">
        <asp:Button ID="Button1" runat="server" Text="Cambiar" OnClick="Button1_Click1" Width="70px" />&nbsp&nbsp&nbsp<asp:Button ID="Button2" runat="server" Text="Volver" OnClick="Button2_Click2" Width="70px" /></div>

        <%--</div>--%>
    </div>
    </form>
</body>
</html>
