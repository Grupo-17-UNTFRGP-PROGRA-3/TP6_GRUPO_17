using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_17.Clases
{
    public class Producto
    {
        private int _idProducto;
        private string _nombreProducto;
        private int _idProveedor;
        private string _cantidadPorUnidad;
        private decimal _precioUnidad;
        private int _unidadesEnExistencia;
        private int _unidadesEnPedido;
        private int _nivelNuevoPedido;
        private bool _suspendido;

        public Producto()
        {

        }
        
        public Producto(int idProducto, string nombreProducto, int idProveedor, string cantidadPorUnidad, decimal precioUnidad, int unidadesEnExistencia, int unidadesEnPedido, int nivelNuevoPedido, bool suspendido)
        {
            _idProducto = idProducto;
            _nombreProducto = nombreProducto;
            _idProveedor = idProveedor;
            _cantidadPorUnidad = cantidadPorUnidad;
            _precioUnidad = precioUnidad;
            _unidadesEnExistencia = unidadesEnExistencia;
            _unidadesEnPedido = unidadesEnPedido;
            _nivelNuevoPedido = nivelNuevoPedido;
            _suspendido = suspendido;
        }
    }
}