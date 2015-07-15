<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeFile="abainstruc.aspx.cs" Inherits="WebApplication2.uncaldocs" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>Lista Documentos</p>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="FolderContentsDataSource1">
</asp:GridView>
    </asp:Content>

