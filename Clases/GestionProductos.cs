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
            SqlConnection Conexion = accesoDatos.ObtenerConexion();

            if (Conexion != null)
            {
                resultado = accesoDatos.EjecutarEliminacion(id);

            }
            
            return resultado;
        }
        
        public void ActualizarProductos(int id, string nombre, string cantidad, string precio)
        {
            AccesoDatos accesoDatos=new AccesoDatos();
            string consulta = "UPDATE [Neptuno].[dbo].[Productos] SET NombreProducto = '" + nombre + "', CantidadPorUnidad = '" + cantidad + "'," +
                "PrecioUnidad = " + precio + " WHERE IdProducto = @IdProducto";
            SqlConnection Conexion = accesoDatos.ObtenerConexion();
            if (Conexion != null)
            {
                SqlCommand command = new SqlCommand(consulta, Conexion);
                command.Parameters.AddWithValue("@IdProducto", id);
                command.ExecuteNonQuery();
                Conexion.Close();
            }
        }
    }
}