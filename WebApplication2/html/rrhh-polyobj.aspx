﻿<%@ Page Title="RRHH - Politicas y Objetivos" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rrhh-polyobj.aspx.cs" Inherits="WebApplication2.html.rrhh_polyobj" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <html>
<h2>RRHH - Politicas y Objetivos</h2>

<p><asp:HyperLink ID="id01" runat="server" NavigateUrl="~/rrhh/pol_y_obj/nombre_documento.pdf" Target="_blank">CAMBIAR NOMBRE DOC</asp:HyperLink></p>

<%--recordar ir aumentando el ID en 1 cada vez que se agrega una linea.--%>

</html>

</asp:Content>
