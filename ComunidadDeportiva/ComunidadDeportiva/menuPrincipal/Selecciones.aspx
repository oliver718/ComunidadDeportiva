<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Selecciones.aspx.cs" Inherits="ComunidadDeportiva.Selecciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Selecciones
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
            <asp:Label ID="LblTitulo" runat="server" Text="SELECCIONES"></asp:Label>
    </div>
    <br />
    <asp:Repeater ID="rptEquipos" runat="server">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
                <%if (cont % 5 == 0)
                  {%>
                    <tr>
                <%} %>
                <td>
                    <asp:HyperLink ID="fotoEnlace" runat="server" NavigateUrl='<%# getRutaForo(Eval("id")) %>'>
                        <asp:Image ID="escudo" runat="server" ImageUrl='<%# getRutaImagen(Eval("nombre")) %>' 
                            Width="100px" Height="100px" ToolTip='<%# Eval("nombre")%>'/>
                    </asp:HyperLink>
                </td>
                <%if (cont2 == 5)
                  {%>
                    </ tr>
                <%cont2 = 0;
                  } %>
                <%cont++; cont2++; %>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
