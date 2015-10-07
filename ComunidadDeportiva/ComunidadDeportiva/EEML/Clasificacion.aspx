<%@ Page Title="" Language="C#" MasterPageFile="~/EstaEsMiLiga.Master" AutoEventWireup="true" CodeBehind="Clasificacion.aspx.cs" Inherits="ComunidadDeportiva.EEML.Clasificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    ESTA ES MI LIGA-Clasificación
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tituloPantalla">
        <asp:Label ID="LblTitulo" runat="server" Text="CLASIFICACIÓN"></asp:Label>
    </div>

    <asp:GridView ID="GrdClasificacion" runat="server" AutoGenerateColumns="false"
        AllowPaging="True" PageSize="30" Width="100%" 
        onrowdatabound="GrdClasificacion_RowDataBound" BorderColor="White" BorderWidth="0px" GridLines="None" 
        onpageindexchanging="GrdClasificacion_PageIndexChanging">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                <asp:Label ID="Label1" runat="server" Text="Equipo" ToolTip="Equipo"></asp:Label>
                </HeaderTemplate>
                <HeaderStyle HorizontalAlign="Left" BackColor="#EDF1ED" BorderStyle="None"/>
                <ItemTemplate>
                    <asp:Label ID="LblNombreEquipo" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                    <asp:Label ID="LblId" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80%" BorderStyle="None"/>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                <asp:Label ID="Label2" runat="server" Text="PS" ToolTip="Puntos de la última semana"></asp:Label>
                </HeaderTemplate>
                <HeaderStyle HorizontalAlign="Left" BackColor="#EDF1ED" BorderStyle="None"/>
                <ItemTemplate>
                    <asp:Label ID="LblPS" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" BorderStyle="None"/>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                <asp:Label ID="Label3" runat="server" Text="PT" ToolTip="Puntos totales"></asp:Label>
                </HeaderTemplate>
                <HeaderStyle HorizontalAlign="Left" BackColor="#EDF1ED" BorderStyle="None"/>
                <ItemTemplate>
                    <asp:Label ID="LblPT" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80%" BorderStyle="None"/>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BorderStyle="None"/>
        <PagerStyle BorderStyle="None"/>
    </asp:GridView>
</asp:Content>
