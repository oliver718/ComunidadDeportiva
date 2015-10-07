<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="ComunidadDeportiva.RegistroUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrar usuario</title>
    <link href="Estilo.css" rel="stylesheet" type="text/css" />
</head>
<body class="bodyDefault">
    <form id="form1" runat="server">
        <div class="logoPrincipal">
            <asp:Image ID="ImgLogo" runat="server" ImageUrl="~/imagenes/logoPrincipal.png" />
        </div>
        <br /><br />
        <div class="Entrar">
            <div class="registroUsuario">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtNombre" runat="server" Width="169px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblContraseña" runat="server" Text="Contraseña:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtContraseña" runat="server" Width="169px" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblRContraseña" runat="server" Text="Repite contraseña:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtRContraseña" runat="server" Width="169px" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtEmail" runat="server" Width="169px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblClub" runat="server" Text="Mi Club:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DrpEquipo" runat="server" Width="175px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblSeleccion" runat="server" Text="Mi Selección:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DrpSeleccion" runat="server" Width="175px"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div class="botonRegistrar">
                    <asp:Button ID="BtnCrearCuenta" runat="server" Text="Crear Cuenta" 
                        onclick="BtnCrearCuenta_Click" />
                </div>
                <asp:Label ID="LblMensaje" runat="server"></asp:Label>
            </div>
            <%--<div class="listaPrincipal">
                <br /><br /><br />
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="Img1" runat="server" ImageUrl="~/imagenes/balonPrincipal.png" Width="48px" Height="48px"/>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="¿Te gusta el deporte?" CssClass="textoListaPrincipal"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br /><br />
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="Img2" runat="server" ImageUrl="~/imagenes/socialPrincipal.png" Width="48px" Height="48px"/>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="¿Te gusta hablar con gente y compartir ideas?" CssClass="textoListaPrincipal"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br /><br />
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="Img3" runat="server" ImageUrl="~/imagenes/premioPrincipal.png" Width="48px" Height="48px"/>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="¿Te gusta ganar premios haciendo lo que te gusta?" CssClass="textoListaPrincipal"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>--%>
        </div>
    </form>
</body>
</html>
