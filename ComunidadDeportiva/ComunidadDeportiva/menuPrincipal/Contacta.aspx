<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Contacta.aspx.cs" Inherits="ComunidadDeportiva.Contacta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Contacta
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
        <asp:Label ID="LblTitulo" runat="server" Text="CONTACTA CON NOSOTROS"></asp:Label>
    </div>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Envianos cualquier duda ó reclamación sobre la página ó 
        sobre usuarios de la comunidad que creas que han hecho algo que no está permitido."></asp:Label>  
    <br /><br />
    <div class="tituloContenido">
    <asp:Label ID="Label1" runat="server" Text="Asunto:"></asp:Label>
    </div>
    <br />
    <asp:TextBox ID="TxtAsunto" runat="server" Width="99%"></asp:TextBox>
    <br /><br /><br />
    <div class="tituloContenido">
    <asp:Label ID="Label2" runat="server" Text="Mensaje:"></asp:Label>
    </div>
    <br />
    <div class="textarea">
        <asp:TextBox ID="TxtMensaje" runat="server" TextMode="MultiLine" Width="99%" Height="200px"></asp:TextBox>
    </div>
    <asp:Label ID="LblMensaje" runat="server"></asp:Label>
    <br /><br />
    <asp:Button ID="BtnEnviar" runat="server" Text="Enviar" 
        onclick="BtnEnviar_Click" />


</asp:Content>
