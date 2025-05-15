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
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbEliminarProductos_Click(object sender, EventArgs e)
        {
            if (Session["tabla"] == null)
            {
                lbl_MensajeEliminados.Text = "No tiene productos seleccionados.";
                return;
            }

            int cantProductos = ((DataTable)Session["tabla"]).Rows.Count;
            Session["tabla"] = null;
            lbl_MensajeEliminados.Text = $"Los productos seleccionados fueron exitosamente eliminados ({cantProductos}).";
        }
    }
}