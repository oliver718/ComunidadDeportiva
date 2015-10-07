<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Comentarios.aspx.cs" Inherits="ComunidadDeportiva.menuIzquierda.Comentarios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Comentarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="Pdtpanel" runat="server">
        <ContentTemplate>
            <div class="tituloPantalla">
                <div class="centrarTitulo">
                    <asp:Label ID="LblTitulo" runat="server" Text="COMENTARIOS" ></asp:Label>
                </div>
                <div class="imagenTitulo">
                    <asp:Image ID="ImgEquipo" Width="63px" Height="73" runat="server"/>
                </div>
            </div>
            <div class="nombreTema">
                <asp:Label ID="LblTema" runat="server"></asp:Label>
            </div>
            <br />
            <asp:ImageButton ID="BtnAbrirPanel" runat="server" onclick="BtnAbrirPanel_Click" 
                ImageUrl="~/imagenes/escribir.png" Width="32px" Height="32px" ToolTip="Escribir comentario"/>
            <br />
            <asp:Panel ID="PnlCrearComentario" runat="server" CssClass="capaTotalVisible">
                <div class="dentroTotalVisible">
                    <asp:Label ID="Label1" runat="server" Text="Nuevo comentario:"></asp:Label>
                    <asp:TextBox ID="TxtComentario" runat="server" TextMode="MultiLine" 
                        MaxLength="5" Width="99%" Height="300px"></asp:TextBox>
                    <div class="botonesTotalVisible">
                        <asp:Button ID="BtnCrearComentario" runat="server" Text="Guardar" 
                            onclick="BtnCrearComentario_Click"/>
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" 
                            onclick="BtnCancelar_Click"/>
                    </div>
                </div>     
            </asp:Panel>
            <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>

            <asp:GridView ID="GrdComentarios" runat="server" AutoGenerateColumns="false"
                AllowPaging="True" onpageindexchanging="GrdComentarios_PageIndexChanging"
                PageSize="4" Width="100%" BorderColor="White" BorderWidth="0px" 
                GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="ajustarComentarioTotal">
                                <asp:Panel ID="PnlComentario" runat="server" CssClass="conjuntoComentario">
                                        <div class="tituloContenido">
                                            <asp:Label ID="lblUsuario" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                            <div class="fechaComentario">
                                                <asp:Label ID="lblFechaHola" runat="server" Text='<%# Eval("fechaCreacion") %>'></asp:Label>
                                            </div>
                                            <hr />
                                        </div>
                                        <div class="comentario">
                                            <asp:Label ID="LblComentario" runat="server" Text='<%# Eval("comentario") %>' Width="100%"></asp:Label>
                                        </div>
                                </asp:Panel>
                            </div>
                            <asp:RoundedCornersExtender ID="RndComentario" runat="server"
                                TargetControlID="PnlComentario"
                                Radius="10"
                                Corners="All" BorderColor="orange"/>
                        </ItemTemplate>
                        <ItemStyle Width="100%"/>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BorderStyle="None"/>
                <PagerStyle BorderStyle="None"/>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
