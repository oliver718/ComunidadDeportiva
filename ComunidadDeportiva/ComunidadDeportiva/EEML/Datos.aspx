<%@ Page Title="" Language="C#" MasterPageFile="~/EstaEsMiLiga.Master" AutoEventWireup="true" CodeBehind="Datos.aspx.cs" Inherits="ComunidadDeportiva.EEML.Datos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    ESTA ES MI LIGA-Mis datos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
            <asp:Label ID="LblTitulo" runat="server" Text="DATOS DEL EQUIPO"></asp:Label>
    </div>
    <table>
        <tr>
            <td>
                <b><asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label></b>
            </td>
            <td>
                <asp:Label ID="LblNombre" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b><asp:Label ID="Label6" runat="server" Text="Dueño:"></asp:Label></b>
            </td>
            <td>
                <asp:Label ID="LblDueño" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b><asp:Label ID="Label2" runat="server" Text="Jugando desde:"></asp:Label></b>
            </td>
            <td>
                 <asp:Label ID="LblFecha" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b><asp:Label ID="Label4" runat="server" Text="Presupuesto:"></asp:Label></b>
            </td>
            <td>
                <asp:Label ID="LblPresupuesto" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b><asp:Label ID="Label5" runat="server" Text="Salario semanal de los jugadores:"></asp:Label></b>
            </td>
            <td>
                <asp:Label ID="LblSalario" runat="server"></asp:Label>
            </td>
        </tr> 
    </table>
</asp:Content>
