<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LigaBBVA.aspx.cs" Inherits="ComunidadDeportiva.LigaBBVA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Liga BBVA
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
            <asp:Label ID="LblTitulo" runat="server" Text="LIGA BBVA"></asp:Label>
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
                    <asp:HyperLink ID="fotoEnlace" runat="server" NavigateUrl='<%# getRutaForo(Eval("id")) %>' 
                        ImageUrl='<%# getRutaImagen(Eval("nombre")) %>' Text='<%# Eval("nombre")%>' 
                        ToolTip='<%# Eval("nombre")%>'>
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
