using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.DTOs
{
    public class VentaReporteGETDtos
    {
        public int Id_Venta { get; set; }
        public int Carrito { get; set; }
        public DateTime Fecha { get; set; }
        public int CarritoID { get; set; }
        public int CarritoClienteID { get; set; }
        public int ClienteID { get; set; }
        public string ClienteName { get; set; }
        public string ClienteApellido { get; set; }
        public int ProductoID { get; set; }
        public string ProductoCodigo { get; set; }
        public string ProductoMarca { get; set; }
        public string ProductoNombre { get; set; }

        public decimal ProductPrecio { get; set; }
        public int CarritoYproductoID { get; set; }
    }
}
