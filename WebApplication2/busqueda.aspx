<%@ Page Title="DTS - Busqueda" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="busqueda.aspx.cs" Inherits="WebApplication2.busqueda" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><b>Busqueda Documentos</b></h2>
    <p>Ingrese criterio de busqueda.</p>
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<%--            <asp:SqlDataSource ID="resultadoBuscar" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion_DB_Intranet %>"
                SelectCommand="SELECT [Nombre_Documento], [Dir_Documento] FROM [Busqueda] WHERE ([Nombre_Documento] LIKE '%' + @textoBuscado + '%')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" Name="textoBuscado" PropertyName="Text"
                        Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>--%>

            <table border="0">
                <tr>
                    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                            onclick="btnBuscar_Click" /></td>
                </tr>
            </table>

            <br />
            
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="8"><%--DataSourceID="resultadoBuscar"--%>
                <Columns>

                <asp:TemplateField HeaderText="Nro Documento">
                    <ItemTemplate>
                        <asp:Label ID="IdAdjunto" runat="server" Text='<%# Bind("Nro_Documento") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nombre Documento">
                    <ItemTemplate>
                        <asp:Label ID="IdCotizacion" runat="server" Text='<%# Bind("Nombre_Documento") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Link">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# Eval("Dir_Documento") %>' Target="_blank" Text="VER"></asp:HyperLink>
                        <%--<asp:HyperLink ID="lnkDocumento" runat="server" CausesValidation="false" CommandArgument='<%# Eval("Dir_Documento") %>' CommandName="Descargar" Text='<%# Eval("NOMADJUNTO") %>'></asp:HyperLink>--%>
                    </ItemTemplate>
                </asp:TemplateField>                
<%--                    <asp:BoundField DataField="Nombre_Documento" HeaderText="Nombre Documento" SortExpression="Nombre_Documento" />
                    <asp:HyperLinkField DataTextFormatString="Ver" DataNavigateUrlFields="Dir_Documento" Target="_blank" DataTextField="Dir_Documento" HeaderText="Link" SortExpression="Dir_Documento" />
--%>            </Columns>
            </asp:GridView>
        </ContentTemplate>
        <%--        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TextBox1" EventName="" />
        </Triggers>--%>
    </asp:UpdatePanel>
    &nbsp;
</asp:Content>
