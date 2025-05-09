using System;
using System.Collections.Generic;
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
    }
}