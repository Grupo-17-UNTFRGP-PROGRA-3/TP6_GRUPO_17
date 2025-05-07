using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_17.Conexion
{
    public class GestionProductos
    {
        private DataTable ObtenerTabla(string nombreTabla, string consultaSql)
        {
            DataSet dataSet = new DataSet();
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlDataAdapter sqlDataAdapter = accesoDatos.ObtenerAdaptador(consultaSql);
            sqlDataAdapter.Fill(dataSet, nombreTabla);
            return dataSet.Tables[nombreTabla];
        }

        public DataTable ObtenerProductos()
        {
            return ObtenerTabla("Productos", "SELECT * FROM Productos");
        }
    }
}