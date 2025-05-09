using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_17.Conexion
{
    public class AccesoDatos
    {   
        // Propiedades
        string rutaProductos = @"Data Source=localhost\sqlexpress;Initial Catalog=Neptuno; Integrated Security=True";
        private string queryEliminarPorId = "DELETE FROM Productos WHERE IdProducto = @IdProducto";

        // Constructor
        public AccesoDatos()
        {

        }

        // Metodos
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

        public bool EjecutarEliminacion(int id)
        {
            try 
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                SqlConnection Conexion = accesoDatos.ObtenerConexion();
                SqlCommand command = new SqlCommand(queryEliminarPorId, Conexion);
                command.Parameters.AddWithValue("@IdProducto", id);
                command.ExecuteNonQuery();
                Conexion.Close();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}