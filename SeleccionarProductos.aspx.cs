using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_GRUPO_17.Conexion;

namespace TP6_GRUPO_17
{
    public partial class WebForm1 : System.Web.UI.Page
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
            gvProductos2.DataSource = gestionProductos.ObtenerTodosLosProductos();
            gvProductos2.DataBind();
        }

        protected void gvProductos2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos2.PageIndex = e.NewPageIndex;
            CargarGridView();
        }

        protected void gvProductos2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow seleccionado = gvProductos2.SelectedRow;
            string nombreProducto = ((Label)seleccionado.FindControl("lblNombreProducto")).Text;

            lblMensaje.Text = $"Producto seleccionado: {nombreProducto}";

            DataTable tabla = (DataTable)Session["tabla"];

            DataTable aux = new DataTable();

            GestionProductos sel = new GestionProductos();

            aux = sel.ObtenerUnProducto(Convert.ToInt32(((Label)seleccionado.FindControl("lblIdProducto")).Text));

            if (tabla == null)
            {
                Session["tabla"] = (DataTable)aux;
            }
            else
            {
                tabla.Merge(aux);
            }
        }
    }
}