<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarProductos.aspx.cs" Inherits="TP6_GRUPO_17.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvSeleccionados" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowEditing="gvSeleccionados_RowEditing" OnRowUpdating="gvSeleccionados_RowUpdating">
                <Columns>
                    <asp:TemplateField AccessibleHeaderText="IDProd" HeaderText="ID Prod">
                        <ItemTemplate>
                            <asp:Label ID="lbl_gv_IdProducto" runat="server" Text='<%# Bind("IdProducto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre del Producto">
                        <ItemTemplate>
                            <asp:Label ID="lbl_gv_NombreProducto" runat="server" Text='<%# Bind("NombreProducto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Id Prov">
                        <ItemTemplate>
                            <asp:Label ID="lbl_gv_IdProv" runat="server" Text='<%# Bind("IdProveedor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio Unitario">
                        <ItemTemplate>
                            <asp:Label ID="lbl_gv_Precio" runat="server" Text='<%# Bind("PrecioUnidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_gv_Cantidad" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_gv_Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" HeaderText="Cambiar Cantidad" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            <asp:Label ID="lbl_PrecioTotal" runat="server" Text="Precio Final: "></asp:Label>
            <br />
        </div>
        <p>
&nbsp;
            &nbsp;
                        <asp:HyperLink ID="hpVolverInicio" runat="server" style="text-decoration: underline;" NavigateUrl="~/Ejercicio2.aspx" >Volver al Inicio</asp:HyperLink>
                    &nbsp;
            <asp:LinkButton ID="lbEliminarProductos" runat="server" OnClick="lbEliminarProductos_Click">Eliminar Productos seleccionados</asp:LinkButton>
        </p>
    </form>
</body>
</html>
