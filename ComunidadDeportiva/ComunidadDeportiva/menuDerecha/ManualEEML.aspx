<%@ Page Title="" Language="C#" MasterPageFile="~/EstaEsMiLiga.Master" AutoEventWireup="true" CodeBehind="ManualEEML.aspx.cs" Inherits="ComunidadDeportiva.ManualEEML" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
        <asp:Label ID="LblTitulo" runat="server" Text="ESTA ES MI LIGA"></asp:Label>
    </div>
    <div class="texto">
        <p>
            Si es la primera vez que el usuario entra en ESTA ES MI LIGA
            el sistema le pedirá que ingrese un nombre para su equipo, tras
            comprobar que ese nombre no existe se seleccionarán 18 jugadores aleatorios
            que serán los que formarán parte del equipo virtual que acaba de formar el
            usuario. Una vez dentro del juego, el menú izquierdo cambia, en el aparece el
            nombre del equipo y debajo una serie de opciones:<br /><br />
            “Datos”: Se muestran los datos generales del equipo (nombre, fecha de
            creación del equipo, presupuesto y salario total de los jugadores del
            equipo.<br /><br />
            “Jugadores”: Donde aparecen los jugadores del equipo y sus datos, en
            este apartado el usuario puede despedir a jugadores de su equipo que
            no necesite.<br /><br />
            “Fichar”: En este apartado aparecen todos los jugadores que el usuario
            puede comprar, para realizar esta operación basta con que el usuario
            pulse el botón de fichar que tiene cada jugador y este se añadirá
            automáticamente a su equipo.<br /><br />
            “Clasificación”: Se muestra una clasificación donde aparecen todos
            equipos con su puntuación de la última semana y su puntuación total.
        </p>
    </div>
</asp:Content>
