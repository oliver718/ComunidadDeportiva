<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ocio.aspx.cs" Inherits="ComunidadDeportiva.Ocio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Ocio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
            <asp:Label ID="LblTitulo" runat="server" Text="OCIO"></asp:Label>
    </div>
    <br />
    <div class="enlaceOcio">
    <asp:HyperLink ID="HprEstaEsMiLiga" runat="server" NavigateUrl="~/EEML/Datos.aspx">
        <asp:Image ID="Imagen1" runat="server" ImageUrl="~/imagenes/estaesmiliga.png" Width="120px" Height="100px" ToolTip="Esta es mi liga"/><br />
        <div class="textoEnlace">
            <asp:Label ID="Label1" runat="server" Text="Esta es mi liga"></asp:Label>
        </div>
        </asp:HyperLink>
    </div>
</asp:Content>
