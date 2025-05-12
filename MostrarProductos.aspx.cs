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
                cargarGrilla();
                lbl_PrecioTotal.Visible = false;
            }
            calculoPrecioFinal();
        }

       private void calculoPrecioFinal()
        {
            if(gvSeleccionados.DataSource != null)
            { 
            DataTable dataTable = ((DataTable)Session["tabla"]);
            decimal precioFinal = 0.0M;
            int i = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                precioFinal +=  ((decimal)dr["PrecioUnidad"]) * Convert.ToInt32(dataTable.Rows[i]["Cantidad"]);
                i++;
            }
            lbl_PrecioTotal.Visible=true;
            lbl_PrecioTotal.Text = "Precio Total = $ " + precioFinal.ToString();
            }
        }

        protected void lbEliminarProductos_Click(object sender, EventArgs e)
        {
            Session["tabla"] = null;
            gvSeleccionados.DataSource = null;
            gvSeleccionados.DataBind();
            lbl_PrecioTotal.Visible = false;

        }

        protected void gvSeleccionados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSeleccionados.EditIndex = e.NewEditIndex;
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            gvSeleccionados.DataSource = (DataTable)Session["tabla"];
            gvSeleccionados.DataBind();
        }

        protected void gvSeleccionados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable aux = new DataTable();
            aux = (DataTable)Session["tabla"];

            int cantidadIngresada = Convert.ToInt32(((TextBox)gvSeleccionados.Rows[e.RowIndex].FindControl("txt_gv_Cantidad")).Text);

            if ( cantidadIngresada >= 1)
            {
                aux.Rows[e.RowIndex]["Cantidad"] = ((TextBox)gvSeleccionados.Rows[e.RowIndex].FindControl("txt_gv_Cantidad")).Text;
                Session["tabla"] = aux;
            }

            gvSeleccionados.EditIndex = -1;
            cargarGrilla();
            calculoPrecioFinal();
        }
    }
}