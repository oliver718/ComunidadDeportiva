<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Foro.aspx.cs" Inherits="ComunidadDeportiva.menuIzquierda.Foro" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Temas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
        <div class="centrarTitulo">
            <asp:Label ID="LblTitulo" runat="server" Text="TEMAS" ></asp:Label>
        </div>
        <div class="imagenTitulo">
            <asp:Image ID="ImgEquipo" Width="63px" Height="73" runat="server"/>
        </div>
    </div>
    <asp:ImageButton ID="BtnAbrirPanel" runat="server" onclick="btnAbrirPanel_Click" 
        ImageUrl="~/imagenes/nuevo.jpg" Width="32px" Height="32px" ToolTip="Crear tema"/>
    <br /><br />
    <asp:Panel ID="PnlCrearTema" runat="server" CssClass="capaTotalVisible">
            <div class="dentroTotalVisible">
                <asp:Label ID="Label3" runat="server" Text="Nombre del tema:"></asp:Label>
                <asp:TextBox ID="TxtTema" runat="server" Width="300px"></asp:TextBox>
                <div class="botonesTotalVisible">
                    <asp:Button ID="BtnCrearTema" runat="server" Text="Guardar" 
                        onclick="BtnCrearTema_Click"/>
                    <asp:Button ID="BtnCerrar" runat="server" Text="Cerrar" 
                        onclick="BtnCerrar_Click"/>
                </div>
            </div>     
    </asp:Panel>
    <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GrdTemas" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" PageSize="10" Width="100%"
            onpageindexchanging="GrdTemas_PageIndexChanging" BorderColor="White" BorderWidth="0px" 
            GridLines="None">
            <Columns>
                <asp:TemplateField HeaderStyle-BorderStyle="None">
                    <ItemTemplate>
                    <div class="tituloContenido">
                        <asp:HyperLink ID="HprTema" runat="server" Text='<%# Eval("nombre") %>' NavigateUrl='<%# getRuta(Eval("id")) %>'></asp:HyperLink>
                        <div class="fechaComentario">
                            <asp:Label ID="lblFechaHora" runat="server" Text='<%# Eval("fechaCreacion") %>'></asp:Label>
                        </div>
                    </div>
                    <hr />
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="None"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BorderStyle="None"/>
            <PagerStyle BorderStyle="None"/>
        </asp:GridView>

</asp:Content>
