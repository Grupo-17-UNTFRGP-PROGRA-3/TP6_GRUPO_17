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
        // Constructor
        public GestionProductos()
        {
            
        }

        // Metodos
        private DataTable ObtenerTabla(string nombreTabla, string consultaSql)
        {
            DataSet dataSet = new DataSet();
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlDataAdapter sqlDataAdapter = accesoDatos.ObtenerAdaptador(consultaSql);
            sqlDataAdapter.Fill(dataSet, nombreTabla);
            return dataSet.Tables[nombreTabla];
        }

        public DataTable ObtenerTodosLosProductos()
        {
            return ObtenerTabla("Productos", "SELECT * FROM Productos");
        }

        public bool EliminarProducto(int id)
        {
            bool resultado = false;
            AccesoDatos accesoDatos = new AccesoDatos();

            resultado = accesoDatos.EjecutarEliminacion(id);
            
            return resultado;
        }
        
        public bool ActualizarProducto(int id, string nombre, string cantidad, string precio)
        {
            bool resultado = false;
            AccesoDatos accesoDatos = new AccesoDatos();

            resultado = accesoDatos.EjecutarActualizacion(id, nombre, cantidad, precio);

            return resultado;
        }
    }
}