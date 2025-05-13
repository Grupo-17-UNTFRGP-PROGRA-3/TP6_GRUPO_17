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
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                cargarGrilla();
            }
        }

       private decimal calculoPrecioFinal(DataTable tablaSeleccionados)
        {
            decimal precioFinal = 0.0M;
            foreach (DataRow dr in tablaSeleccionados.Rows)
            {
                precioFinal += ((decimal)dr["PrecioUnidad"]) * Convert.ToInt32(dr["Cantidad"]);
            }
            return precioFinal;
        }
        private void cargarGrilla()
        {
            DataTable tabla = Session["tabla"] as DataTable;
            gvSeleccionados.DataSource = tabla;
            gvSeleccionados.DataBind();

            if(tabla == null)
            {
                lblSinProductos.Visible = true;
                lbl_PrecioTotal.Visible = false;
                return;
            }

            lbl_PrecioTotal.Text = $"Precio Total = {calculoPrecioFinal(tabla).ToString("C")}";

            lblSinProductos.Visible = false;
            lbl_PrecioTotal.Visible = true;
        }

        protected void lbEliminarProductos_Click(object sender, EventArgs e)
        {
            Session["tabla"] = null;
            cargarGrilla();
        }

        protected void gvSeleccionados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSeleccionados.EditIndex = e.NewEditIndex;
            cargarGrilla();
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
        }

        protected void gvSeleccionados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSeleccionados.EditIndex = -1;
            cargarGrilla();
        }
    }
}