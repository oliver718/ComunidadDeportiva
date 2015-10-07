<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Manual.aspx.cs" Inherits="ComunidadDeportiva.Manual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
Manual de comunidad deportiva
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
        <asp:Label ID="LblTitulo" runat="server" Text="COMUNIDAD DEPORTIVA"></asp:Label>
    </div>
    <div class="texto">
        <p>
            Al acceder al sistema, la primera página que aparecerá será la de “noticias” en la cual
            están las últimas noticas sobre la “comunidad deportiva” (novedades, avisos…). En el
            caso de que el usuario quiera consultar las noticias anteriores se irá al final de la
            página y pulsará en “ver más”, este enlace le llevará a otra página donde estarán todas
            las noticas publicadas.<br /><br />
            En el menú izquierdo hay dos apartados uno es “mi club” y otro “mi selección”, debajo
            de ellos hay varias opciones:<br /><br />
            Foro: El usuario puede crear un tema o entrar en otro que ya esté creado y comentar
            sobre el tema en la parte de comentarios.<br /><br />
            Galería: En la cual hay fotos de los mejores momentos del equipo.<br /><br />
            Jugadores: Donde se muestran los jugadores de ese equipo.<br /><br />
            En los apartados “ligas” y “selecciones” del menú superior el usuario puede acceder a
            un club o una selección, pero si este no es fan, no puede crear temas ni hacer
            comentarios en el apartado foro, pero si leer los comentarios que hayan escrito los
            fans de ese club o selección. A los demás apartados también puede acceder.<br /><br />
            En el apartado “mis datos” el usuario puede modificar sus datos y su contraseña de
            acceso y en el apartado “contacta” el usuario tiene la opción de contactar con un
            administrador de la comunidad para realizarle alguna queja sobre otro usuario o sobre
            el sistema.<br /><br />
            En el apartado “Ocio” habrá varios juegos ó otras aplicaciones en los que el usuario
            podrá entretenerse, además de ganar distintos premios reales.
        </p>
    </div>
</asp:Content>
