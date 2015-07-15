<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pwdrecordar.aspx.cs" Inherits="WebApplication2.pwdrecordar" %>

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
            Recordar Contraseña</h2></div>
            <br />
        <div id="txtDos"><p>
            Verifique mail y presione enviar, se le enviara una nueva contraseña al correo especificado, la cual debera cambiar.</p></div>
        
        <br /><div id="sectionCambioUser">
        <div id="lblCambioUser"><label>Usuario:</label></div>
        <div id="txtCambioUser"><input type="text" id="txtMailUser" name="txtMailUser" runat="server" 
                style="width:120px;" disabled="disabled"/></div>
        </div>

                <br /><div id="sectionOldPwd">
        <div id="lblOldPwd"><label>Correo Electronico:</label></div>
        <div id="txtOldPwd"><input type="text" id="txtMail" name="txtMail" runat="server" 
                style="width:120px;"/></div>
        </div>

        <br /><div id="boton">
        <asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click1" Width="70px"/>&nbsp&nbsp&nbsp<asp:Button ID="Button2" runat="server" Text="Volver" OnClick="Button2_Click2" Width="70px"/></div><%--OnClick="Button1_Click1"--%>

        <%--</div>--%>
    </div>
    </form>
</body>
</html>
