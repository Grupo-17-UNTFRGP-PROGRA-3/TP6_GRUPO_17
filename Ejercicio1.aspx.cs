using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_GRUPO_17.Clases;
using TP6_GRUPO_17.Conexion;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;

namespace TP6_GRUPO_17
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridView();
            }
        }

        private void CargarGridView()
        {
            GestionProductos gestionProductos = new GestionProductos();
            gvProductos.DataSource = gestionProductos.ObtenerTodosLosProductos();
            gvProductos.DataBind();
        }

        // Paginacion
        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }

        // Eliminar un producto
        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_it_id")).Text;
            int id = (int.Parse(idProducto));

            GestionProductos gestionProductos = new GestionProductos();
            gestionProductos.EliminarProducto(id);
            CargarGridView();
        }

        // Editar un producto
        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;
            CargarGridView();
        }

        // Cancelar edicion de producto
        protected void gvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProductos.EditIndex = -1;
            CargarGridView();
        }

        // Confirmacion de edicion de producto
        protected void gvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idProducto = Convert.ToInt32(((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_it_id")).Text);
            string nombre = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_et_Nombre")).Text;
            string cantXunid = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_et_CantXU")).Text;
            string precio = transformarAPuntoDecimal(((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_et_Precio")).Text);

            GestionProductos gestion = new GestionProductos();
            gestion.ActualizarProductos(idProducto, nombre, cantXunid, precio);
            gvProductos.EditIndex = -1;
            CargarGridView();
        }

        // Funciones auxiliares
        protected string transformarAPuntoDecimal(string precio)
        {
            string nuevoPrecio= "";
            foreach (char c in precio)
            {
              if (c == ',')
                {
                    nuevoPrecio += ".";
                }
              else
                {
                    nuevoPrecio += c;
                }
            }
            return nuevoPrecio;
        }
    }
}