<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ComunidadDeportiva.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entra en la comunidad</title>
    <link href="Estilo.css" rel="stylesheet" type="text/css" />
</head>
<body class="bodyDefault">
    <form id="form1" runat="server">
        <div class="logoPrincipal">
            <asp:Image ID="ImgLogo" runat="server" ImageUrl="~/imagenes/logoPrincipal.png" />
        </div>
        <br /><br />
        <div class="Entrar">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TxtNombre" runat="server" Width="175px" Height="20px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtPassword" runat="server" Width="175px" Height="20px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="BtnEntrar" runat="server" Text="Entrar" Height="30px" 
                            onclick="BtnEntrar_Click" />
                    </td>
                </tr>
                <tr>  
                    <td>  
                        <asp:Button ID="BtnRegistrarme" runat="server" Text="Quiero una cuenta" 
                            CssClass="botonPrincipal" onclick="BtnRegistrarme_Click" 
                            BorderStyle="None"/>
                    </td>
                    <td>
                        <asp:Button ID="BtnOContraseña" runat="server" Text="He olvidado mi contraseña" 
                             CssClass="botonPrincipal" onclick="BtnOContraseña_Click" 
                            BorderStyle="None"/>
                    </td>
                </tr>
                </table>
            <asp:Label ID="LblMensaje" runat="server"></asp:Label>
            <div class="listaPrincipal">
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
            </div>
        </div>
    </form>
</body>
</html>
