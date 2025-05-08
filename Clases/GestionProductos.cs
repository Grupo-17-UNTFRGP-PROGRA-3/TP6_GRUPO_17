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

        public void EliminarProductos(int id)
        {
           AccesoDatos datos = new AccesoDatos();
            datos.EliminarProductos(id);

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