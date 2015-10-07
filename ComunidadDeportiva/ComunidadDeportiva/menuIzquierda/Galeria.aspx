<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Galeria.aspx.cs" Inherits="ComunidadDeportiva.menuIzquierda.Galeria" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Galería
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
        <div class="centrarTitulo">
            <asp:Label ID="LblTitulo" runat="server" Text="GALERÍA" ></asp:Label>
        </div>
        <div class="imagenTitulo">
            <asp:Image ID="ImgEquipo" Width="63px" Height="73" runat="server"/>
        </div>
    </div>
    <asp:GridView ID="GrdFotos" runat="server" AutoGenerateColumns="false"
        AllowPaging="True" PageSize="10" Width="100%" 
        onpageindexchanging="GrdFotos_PageIndexChanging" BorderColor="White" BorderWidth="0px" 
        GridLines="None">
        <Columns>
            <asp:TemplateField HeaderStyle-BorderStyle="None">
                <ItemTemplate>
                    <div class="centrarImagen">
                        <asp:Image ID="ImgEquipo" runat="server" Height="400px" Width="500px" ImageUrl='<%# getUrl(Eval("nombre")) %>' />
                        <br />
                        <asp:Label ID="LblDescripcion" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                    </div>
                    <br /><br />
                </ItemTemplate>
                <ItemStyle Width="100%"/>
                <HeaderStyle BorderStyle="None"></HeaderStyle>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BorderStyle="None"/>
        <PagerStyle BorderStyle="None"/>
    </asp:GridView>
</asp:Content>
