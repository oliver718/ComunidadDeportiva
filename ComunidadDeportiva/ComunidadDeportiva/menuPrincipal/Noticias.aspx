<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="ComunidadDeportiva.Noticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Noticias
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
        <asp:Label ID="LblTitulo" runat="server" Text="ÚLTIMAS NOTICIAS"></asp:Label>
    </div>
    <asp:GridView ID="GrdNoticias" runat="server" AutoGenerateColumns="false" Width="100%" BorderStyle="None">
        <Columns>
            <asp:TemplateField HeaderStyle-BorderStyle="None">
                <ItemTemplate>
                    <div class="tituloContenido">
                        <asp:Label ID="lblTitulo" runat="server" Text='<%# Eval("titulo") %>'></asp:Label>
                        <div class="fechaComentario">
                            <asp:Label ID="LlbFecha" runat="server" Text='<%# getFecha(Eval("fecha")) %>'></asp:Label>
                        </div>
                    </div>
                    <hr />
                    <div class="descripcionContenido">
                        <asp:Label ID="lblContenido" runat="server" Text='<%# Eval("descripcion")%>'></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle Width="100%" BorderStyle="None"/>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:HyperLink ID="datos" runat="server" Text="Ver más" NavigateUrl="~/menuPrincipal/ArchivoNoticias.aspx"></asp:HyperLink>
</asp:Content>
