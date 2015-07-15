<%@ Page Title="DTS - Acceso" Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication2.Acceso.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            Acceso Intranet</h2></div>
            <br />
        <div id="txtDos"><p>
            Si no posee una cuenta contactese con el administrador.</p></div>

        <br /><div id="sectionUser">
        <div id="lbl1"><label>Usuario:</label></div>
        <div id="txt1"><%--<asp:TextBox ID="TextBox1" runat="server" Width="120px"></asp:TextBox>--%>
            <input type="text" id="txtUser" name="txtUser" runat="server" 
                style="width:120px;" disabled="disabled"/></div>
        </div>

        <br /><div id="sectionPwd">
        <div id="lbl2">Contraseña:<label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</label></div>
        <div id="txt2"><%--<asp:TextBox ID="TextBox2" runat="server" Width="120px"></asp:TextBox>--%>
            <input type="text" id="txtPwd" name="txtPwd" runat="server" 
                style="width:120px;" /></div>
        </div>

        <br /><div id="cambioPwd">
        <a href="pwdcambiar.aspx">Cambiar Contraseña</a>
        <br />
        <a href="pwdrecordar.aspx">Recordar Contraseña</a>
        </div>

        <br /><div id="boton">
        <asp:Button ID="Button1" runat="server" Text="Entrar" OnClick="Button1_Click1" /></div>

        <%--</div>--%>
    </div>
    </form>
</body>
</html>
