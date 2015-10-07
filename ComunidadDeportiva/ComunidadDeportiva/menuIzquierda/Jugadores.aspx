<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Jugadores.aspx.cs" Inherits="ComunidadDeportiva.menuIzquierda.Jugadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Jugadores
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
        <div class="centrarTitulo">
            <asp:Label ID="LblTitulo" runat="server" Text="JUGADORES" ></asp:Label>
        </div>
        <div class="imagenTitulo">
            <asp:Image ID="ImgEquipo" Width="63px" Height="73" runat="server"/>
        </div>
    </div>
    <asp:GridView ID="GrdFotos" runat="server" AutoGenerateColumns="false"
        AllowPaging="True" PageSize="8" Width="100%" onpageindexchanging="GrdFotos_PageIndexChanging" 
        BorderColor="White" BorderWidth="0px" GridLines="None">
        <Columns>
            <asp:TemplateField HeaderStyle-BorderStyle="None">
                <ItemTemplate>
                    <table>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" Height="150px" Width="150px" ImageUrl='<%# getUrl(Eval("foto")) %>' />
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
                                        <b><asp:Label ID="LblTexto2" runat="server" Text="Fecha de nacimiento:"></asp:Label></b>
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
                                        <b><asp:Label ID="Label1" runat="server" Text="Demarcación:"></asp:Label></b>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("demarcacion") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
                    <hr />
                </ItemTemplate>
                <ItemStyle Width="100%"/>
                <HeaderStyle BorderStyle="None"></HeaderStyle>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BorderStyle="None"/>
        <PagerStyle BorderStyle="None"/>
    </asp:GridView>
</asp:Content>
