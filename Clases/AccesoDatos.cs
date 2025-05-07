using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_17.Conexion
{
    public class AccesoDatos
    {
        string rutaProductos = @"Data Source=localhost\sqlexpress;Initial Catalog=Neptuno; Integrated Security=True";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(rutaProductos);
            try
            {
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public SqlDataAdapter ObtenerAdaptador(string consultaSql)
        {
            SqlDataAdapter sqlDataAdapter;
            try
            {
                sqlDataAdapter = new SqlDataAdapter(consultaSql, ObtenerConexion());
                return sqlDataAdapter;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public void EliminarProductos(int id)
        {
            string consulta = "DELETE FROM Productos WHERE IdProducto = @IdProducto";
            SqlConnection Conexion = ObtenerConexion();
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