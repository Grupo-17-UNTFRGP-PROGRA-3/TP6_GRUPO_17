﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP6_GRUPO_17.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Trabajo Práctico N°6 - Grupo 17</h1>
            <nav>
                <a href="Ejercicio1.aspx">Ejercicio 1</a> |
                <a href="Ejercicio2.aspx">Ejercicio 2</a>
            </nav>
            <h2>Ejercicio 2</h2>
        </div>
         <div>
            <h1>Inicio</h1>
         </div>
         <div>
             <asp:HyperLink ID="hpSeleccionarProductos" runat="server" style="text-decoration: underline;" NavigateUrl="~/SeleccionarProductos.aspx">Seleccionar Productos</asp:HyperLink>
         </div>
         <div>
             <asp:LinkButton ID="lbEliminarProductos" runat="server" OnClick="lbEliminarProductos_Click">Eliminar Productos seleccionados</asp:LinkButton>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="lbl_MensajeEliminados" runat="server"></asp:Label>
         </div>
         <div>
            <asp:HyperLink ID="hpMostrarProductos" runat="server" style="text-decoration: underline" NavigateUrl="~/MostrarProductos.aspx">Mostrar Productos</asp:HyperLink>
         </div>
    </form>
</body>
</html>
