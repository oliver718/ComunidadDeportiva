<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ArchivoNoticias.aspx.cs" Inherits="ComunidadDeportiva.menuPrincipal.ArchivoNoticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Archivo de noticias
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
        <asp:Label ID="LblTitulo" runat="server" Text="ARCHIVO DE NOTICIAS"></asp:Label>
    </div>
    <asp:GridView ID="GrdNoticias" runat="server" AutoGenerateColumns="false" Width="100%" 
        AllowPaging="True" PageSize="5" BorderStyle="None" onpageindexchanging="GrdNoticias_PageIndexChanging" 
        BorderColor="White" BorderWidth="0px" GridLines="None">
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
                <HeaderStyle BorderStyle="None"></HeaderStyle>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BorderStyle="None"/>
        <PagerStyle BorderStyle="None"/>
    </asp:GridView>
</asp:Content>
