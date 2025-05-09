<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarProductos.aspx.cs" Inherits="TP6_GRUPO_17.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1229px;
        }
        .auto-style2 {
            width: 613px;
        }
        .auto-style3 {
            width: 614px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="position: relative">
        <div>

            <table class="auto-style1">
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvProductos2" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" 
                            BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AutoGenerateColumns="False"
                            AllowPaging="true" OnPageIndexChanging="gvProductos2_PageIndexChanging" AutoGenerateSelectButton="true"
                            PageSize="14" OnSelectedIndexChanged="gvProductos2_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="Id Producto">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdProducto" runat="server" Text='<%# Bind("IdProducto") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre Producto">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombreProducto" runat="server" Text='<%# Bind("NombreProducto") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id Proveedor">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdProveedor" runat="server" Text='<%# Bind("IdProveedor") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Precio Unitario">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrecioUnitario" runat="server" Text='<%# Bind("PrecioUnidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#333333" />
                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="White" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:HyperLink ID="hpVolverInicio" runat="server" style="text-decoration: underline;" NavigateUrl="~/Ejercicio2.aspx" >Volver al Inicio</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
