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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tabla = (DataTable)Session["tabla"];                

                GestionProductos gestionProductos = new GestionProductos();
                gvSeleccionados.DataSource = tabla;
                gvSeleccionados.DataBind();
            }
        }
    }
}