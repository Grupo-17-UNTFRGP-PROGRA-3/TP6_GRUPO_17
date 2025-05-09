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

        private string queryActualizarProducto = "UPDATE [Neptuno].[dbo].[Productos] " +
                                                 "SET NombreProducto = @NombreProducto, " +
                                                 "CantidadPorUnidad = @CantidadPorUnidad, " +
                                                 "PrecioUnidad = @PrecioUnidad " +
                                                 "WHERE IdProducto = @IdProducto";

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

        public bool EjecutarActualizacion(int id, string nombre, string cantidad, string precio)
        {
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                SqlConnection Conexion = accesoDatos.ObtenerConexion();
                SqlCommand command = new SqlCommand(queryActualizarProducto, Conexion);
                command.Parameters.AddWithValue("@NombreProducto", nombre);
                command.Parameters.AddWithValue("@CantidadPorUnidad", cantidad);
                command.Parameters.AddWithValue("@PrecioUnidad", precio);
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