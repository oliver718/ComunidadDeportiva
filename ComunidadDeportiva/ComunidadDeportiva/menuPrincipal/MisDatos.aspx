<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MisDatos.aspx.cs" Inherits="ComunidadDeportiva.MisDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Mis datos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="PdtDatos" runat="server">
        <ContentTemplate>
            <div class="tituloPantalla">
                <asp:Label ID="Label7" runat="server" Text="MIS DATOS"></asp:Label>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox> 
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox> 
                    </td>
                </tr>
            </table>
            <br />
            <asp:Panel ID="PnlConfirmarContraseña" runat="server" Visible="false" CssClass="capaTotalVisible">
                <div class="dentroTotalVisible">
                    <asp:Label ID="Label6" runat="server" Text="Contraseña:"></asp:Label>
                    <asp:TextBox ID="TxtCContraseña" runat="server" TextMode="Password"></asp:TextBox>
                    <div class="botonesTotalVisible">
                        <asp:Button ID="BtnAceptarDatos" runat="server" Text="Aceptar" 
                            onclick="BtnAceptarDatos_Click"/>
                    </div>
                </div>
            </asp:Panel>
            <br />
            <asp:Button ID="BtnModificarDatos" runat="server" Text="Modificar mis datos" 
                onclick="BtnModificarDatos_Click"/>
            <asp:Button ID="BtnModificarContraseña" runat="server" 
                Text="Modificar contraseña" onclick="BtnModificarContraseña_Click"/>
            <br /><br />
            <asp:Label ID="LblMensaje" runat="server"></asp:Label>
            <br /><br />
            <asp:Panel ID="PnlContraseña" runat="server" Visible="false" CssClass="capaTotalVisible">
                <div class="dentroTotalVisible">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Nueva contraseña:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtNContraseña" runat="server" TextMode="Password"></asp:TextBox> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Repita la nueva contraseña:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtRContraseña" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Antigüa contraseña:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtAContraseña" runat="server" TextMode="Password"></asp:TextBox> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="BtnAceptarContraseña" runat="server" Text="Aceptar" 
                                    onclick="BtnAceptarContraseña_Click"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
