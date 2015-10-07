<%@ Page Title="" Language="C#" MasterPageFile="~/EstaEsMiLiga.Master" AutoEventWireup="true" CodeBehind="Jugadores.aspx.cs" Inherits="ComunidadDeportiva.EEML.Jugadores" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    ESTA ES MI LIGA-Jugadores
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
        <asp:Label ID="LblTitulo" runat="server" Text="MIS JUGADORES"></asp:Label>
    </div>
    <asp:Label ID="LblMensaje" runat="server"></asp:Label>
    <asp:GridView ID="GrdFotos" runat="server" AutoGenerateColumns="false"
        AllowPaging="True" PageSize="5" Width="100%" 
        onpageindexchanging="GrdFotos_PageIndexChanging" 
        onrowcommand="GrdFotos_RowCommand" BorderColor="White" BorderWidth="0px" GridLines="None">
        <Columns>
            <asp:TemplateField HeaderStyle-BorderStyle="None">
                <ItemTemplate>
                    <div class="ajustarComentarioTotal">
                        <asp:Panel ID="PnlJugador" runat="server" CssClass="conjuntoJugador">
                            <table>
                            <tr>
                                <td>
                                    <asp:Image ID="Image1" runat="server" Height="150px" Width="150px" ImageUrl='<%# getUrl(Eval("foto")) %>' />
                                    <asp:Label ID="LblId" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <b><asp:Label ID="LblTexto" runat="server" Text="Nombre:"></asp:Label></b>
                                                <asp:Label ID="LblNombre" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b><asp:Label ID="LblTexto2" runat="server" Text="Fecha de Nacimiento:"></asp:Label></b>
                                                <asp:Label ID="LblFechaNac" runat="server" Text='<%# arreglarFecha(Eval("fechaNac")) %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b><asp:Label ID="LblTexto3" runat="server" Text="Pais de nacimiento:"></asp:Label></b>
                                                <asp:Label ID="LblNacionalidad" runat="server" Text='<%# Eval("nacionalidad") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b><asp:Label ID="LblTexto4" runat="server" Text="Equipo:"></asp:Label></b>
                                                <asp:Label ID="LblNombreEquipo" runat="server" Text='<%# Eval("nombreEquipo") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b><asp:Label ID="LblTexto5" runat="server" Text="Posición:"></asp:Label></b>
                                                <asp:Label ID="LblPosicion" runat="server" Text='<%# Eval("demarcacion") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b><asp:Label ID="LblTexto7" runat="server" Text="Salario semanal:"></asp:Label></b>
                                                <asp:Label ID="LblSalario" runat="server" Text='<%# pasarAEuros(ponerPuntos(Eval("salario"))) %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                
                                                <b><asp:Label ID="LblTexto6" runat="server" Text="Puntuación de la anterior semana:"></asp:Label></b>
                                                <asp:Label ID="LblPrecio" runat="server" Text='<%# Eval("puntuacionSemanal") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="BtnDespedir"
                                        Text="Despedir"
                                        CommandName="Despedir"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </td>
                            </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <asp:RoundedCornersExtender ID="RndComentario" runat="server"
                        TargetControlID="PnlJugador"
                        Radius="10"
                        Corners="All" BorderColor="Green"/>
                </ItemTemplate>
                <ItemStyle Width="100%"/>
                <HeaderStyle BorderStyle="None"></HeaderStyle>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BorderStyle="None"/>
        <PagerStyle BorderStyle="None"/>
    </asp:GridView>
</asp:Content>
