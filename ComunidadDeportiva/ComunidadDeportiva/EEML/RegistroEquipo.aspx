<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistroEquipo.aspx.cs" Inherits="ComunidadDeportiva.EEML.RegistroEquipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Esta ES MI LIGA-Registro
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
        <asp:Label ID="LblTitulo" runat="server" Text="ESTA ES MI LIGA"></asp:Label>
    </div>
    <table>
        <tr>
            <td>
                ESTA ES MI LIGA es un juego online en el que tendrás que demostrar cuanto sabes de fútbol.<br /><br />
                Compite contra equipos de otros usuarios de COMUNIDAD DEPORTIVA.<br /><br />
                El usuario que quede ganador se llevará un premio ¡increible!
            </td>
            <td>
                <asp:Image ID="IMG" runat="server" ImageUrl="~/imagenes/imagenEEML.jpg" />
            </td>
        </tr>
    </table>
    <b>¿A QUÉ ESPERAS PARA HACERTE TU EQUIPO?</b><br /><br />
    <asp:Label ID="Label1" runat="server" Text="Nombre del equipo:"></asp:Label>
    <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
    <asp:Button ID="BtnRegistrar" runat="server" Text="Crear equipo" 
        onclick="BtnRegistrar_Click" />
        <br />
        <asp:Label ID="LblMensaje" runat="server"></asp:Label>
</asp:Content>
